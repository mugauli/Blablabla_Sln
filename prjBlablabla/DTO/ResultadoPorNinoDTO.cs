using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.DTO
{
    public class ResultadoPorNinoDTO
    {
        public int Grado { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Periodo { get; set; }
        public string Juego { get; set; }
        public int Nivel { get; set; }
        public int TotalEnsayos { get; set; }
        public double Aciertos_x100 { get; set; }
        public double Errores_x100 { get; set; }
        public double Teimpo_reaccion { get; set; }


    }
}