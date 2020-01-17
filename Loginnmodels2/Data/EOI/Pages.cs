using System;
using System.ComponentModel.DataAnnotations;

namespace Loginnmodels2.Data
{
    public class Pages
    {

        public string name { get; set; }
        [Key] public Guid id { get; set; }
    }
}
