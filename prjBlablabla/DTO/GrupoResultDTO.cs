using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.DTO
{
    public class GrupoResultDTO
    {
        public string Escuela { get; set; }
        public int Grado { get; set; }
        public int Masculino { get; set; }
        public int Femenino { get; set; }
        public string SemanaMes { get; set; }
        public string Juego { get; set; }
        public int Nivel { get; set; }
        public double PromedioAciertos { get; set; }
        public double PromedioErrores { get; set; }
    }
}