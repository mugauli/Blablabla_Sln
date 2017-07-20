using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.DTO
{
    public class FrasesBosqueDTO
    {
        public int Id { get; set; }
        public string Frase { get; set; }
        public string Opcion1 { get; set; }
        public string Opcion2 { get; set; }
        public Nullable<bool> Correcta { get; set; }
        public byte Nivel { get; set; }
        public bool Estado { get; set; }
    }
}