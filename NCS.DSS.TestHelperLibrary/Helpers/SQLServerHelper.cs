using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.TestHelperLibrary.Helpers
{
    public class SQLServerHelper
    {
        private SqlConnection Connection;
        private Dictionary<string, string> ReplacementDict = new Dictionary<string, string>();

        public void  AddReplacementRule ( string original, string replacement)
        {
            ReplacementDict[original] = replacement;
            //if (!ReplacementDict.ContainsKey(original) )
            //{
            //    ReplacementDict.Add(original, replacement);
            //}
        }

        public void SetConnection(string connectionString)
        {
            connectionString.Should().NotBeNullOrEmpty();
            Connection = new SqlConnection(connectionString);
        }

        public Boolean OpenConnection()
        {
            if (Connection.ConnectionString != string.Empty)
            {
                try
                {
                    Connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
            return ( Connection.State == System.Data.ConnectionState.Open );
        }

        public Boolean CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Dispose();
                return true;
            }
            return false;
        }

        string checkForReplacements( string fieldName)
        {
            string returnString = fieldName;
            foreach ( var item in ReplacementDict)
            {
                if (item.Key == fieldName)
                {
                    returnString = item.Value;
                }
            }
            return returnString;
        }

        public bool InsertRecordFromJson(string table, string json )
        {
            string sqlString = "insert into [" + table + "] (";
            string sqlValuesString = ") VALUES (";
            bool firstOne = true;
            // check if connected
            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                //translate json into sql insert statement  
                Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                foreach (var item in dict)
                {
                    sqlString += (firstOne ? "" : ",") + checkForReplacements(item.Key);
                    sqlValuesString += (firstOne ? "" : ",") + "'" + item.Value + "'";
                    firstOne = false;
                }
                sqlString += sqlValuesString + ")";

                try
                {
                    SqlCommand newCommand = new SqlCommand(sqlString, Connection);
                    newCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return true;
        }

        public bool CheckRecordExists(string table, string primaryKey, string recordId)
        {
            bool success = false;
            string sqlString = "select * from [" + table + "] where " + checkForReplacements(primaryKey) + " = '" + recordId + "'"; 
            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try
                {
                    SqlCommand myCommand = new SqlCommand(sqlString, Connection);
                    using (var myReader = myCommand.ExecuteReader())
                    { 
                        while (myReader.Read())
                        {
                            if (myReader[checkForReplacements(primaryKey)].ToString() == recordId)
                            {
                                success = true;
                                break;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            }

            return success;

        }

        public bool DeleteRecord(string table, string primaryKey, string recordId)
        {
            bool success = false;
            string sqlString = "delete from [" + table + "] where " + checkForReplacements(primaryKey) + " = '" + recordId + "'";
            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try
                {
                    using (SqlCommand myCommand = new SqlCommand(sqlString, Connection))
                    {
                        var result = myCommand.ExecuteNonQuery();
                        success = (result == 1);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            }

            return success;
        }


        public void test()
        {
            SqlConnection myConnection = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=testdb;User Id=TestUser;Password = password; ");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from Table_1",
                                                         myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine(myReader["ID"].ToString());
                    Console.WriteLine(myReader["Description"].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
