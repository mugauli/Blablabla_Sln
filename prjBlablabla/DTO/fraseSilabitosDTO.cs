using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.DTO
{
    public class FraseSilabitosDTO
    {
        public int Id { get; set; }
        public string c1 { get; set; }
        public string c2 { get; set; }
        public string c3 { get; set; }
        public string p1 { get; set; }
        public string p2 { get; set; }
        public string orden { get; set; }
        public Nullable<short> acomodo { get; set; }
        public Nullable<bool> estado { get; set; }
        public Nullable<int> nivel { get; set; }
    }
}