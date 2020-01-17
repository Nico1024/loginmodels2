using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Loginnmodels2.Data
{
    public class CaseMenu
    {
        public Case ParentCase { get; set; }
        public List<Pages> Paginas { get; set; }
        [Key] public Guid Id { get; set; }
    }
}
