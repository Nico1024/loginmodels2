using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Loginnmodels2.Data
{
    public class MenuPages
    {
        public CaseMenu ParentMenu { get; set; }
        public int Sequence { get; set; }
        [Key] public string Name { get; set; }
        public bool is_single_page { get; set; }

        public List<Pages> Paginas { get; set; }
    }
}
