using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Loginnmodels2.Data
{
    public class User
    {
        [Key] public string user_name { get; set; }
        
        
    }
}
