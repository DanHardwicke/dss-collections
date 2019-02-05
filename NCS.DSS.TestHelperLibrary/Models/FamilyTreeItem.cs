﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.Collections.SysIntTests.Models
{
    class FamilyTreeItem
    {
        public FamilyTreeItem (string key, string value)
        {
            Key = key;
            Value =  value;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
