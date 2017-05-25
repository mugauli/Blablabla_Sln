using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.DTO
{
    public class AlumnoDTO
    {
        public int id_alumnos { get; set; }
        public int id_escuela_alumnos { get; set; }
        public string nombre_alumnos { get; set; }
        public short apellidoP_alumnos { get; set; }
        public string apellidoM_alumnos { get; set; }
        public string fecha_nac_alumnos { get; set; }
        public int no_lista_alumnos { get; set; }
    }
}