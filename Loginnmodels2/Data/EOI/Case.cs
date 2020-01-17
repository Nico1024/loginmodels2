using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Loginnmodels2.Data
{
    public class Case
    {
        [Key] public string Name { get; set; }
        public List<Pages> ListOf_Pages { get; set; }
        public string database_id { get; set; }
        public bool is_valid { get; set; }
    }
}
