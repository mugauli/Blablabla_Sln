using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.DTO
{
    public class FraseCastilloDTO
    {
        public int Id { get; set; }
        public string Enunciado1 { get; set; }
        public string Enunciado2 { get; set; }
        public bool Correcta { get; set; }
        public byte Nivel { get; set; }
        public bool Estado { get; set; }
    }
}