using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace NCS.DSS.TestHelperLibrary.Helpers
{
    public class SQLServerHelper
    {
        private SqlConnection Connection;
        private Dictionary<string, string> ReplacementDict = new Dictionary<string, string>();

        public void  AddReplacementRule ( string original, string replacement)
        {
            ReplacementDict[original] = replacement;
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

        public DataSet ExecuteStoredProcedure(string procName)
        {
            DataSet ds = new DataSet(procName);

            if (Connection.State == System.Data.ConnectionState.Open || OpenConnection())
            {
                try
                {
                    SqlCommand myCommand = new SqlCommand(procName, Connection);
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.Add("@TouchPointId", SqlDbType.VarChar).Value = "9000000001";
                    myCommand.Parameters.Add("@TaxYear", SqlDbType.VarChar).Value = "1920";

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = myCommand;
                    da.Fill(ds);
             
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return ds;
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
    }
}
