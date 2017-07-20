using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.DTO
{
    public class FraseLagoDTO
    {
        public int Id { get; set; }
        public string Enunciado { get; set; }
        public bool Eleccion { get; set; }
        public byte Nivel { get; set; }
        public bool Estado { get; set; }
    }
}