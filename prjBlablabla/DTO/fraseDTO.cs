using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.DTO
{
    public class fraseDTO
    {
        public int Id { get; set; }
        public string enun1 { get; set; }
        public string enun2 { get; set; }
        public short correcta { get; set; }
        public string opcion1 { get; set; }
        public string opcion2 { get; set; }
        public string opcion3 { get; set; }
        public int nivel { get; set; }
        public int juego { get; set; }
    }
}