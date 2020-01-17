using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Loginnmodels2.Data
{
    public class UserHasCases : Model
    {
        public User usr {get; set;}
        public Case connected_case { get; set; }
        public int Sequence { get; set; }
        
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Int64 int_counter { get; set; }
    }
}
