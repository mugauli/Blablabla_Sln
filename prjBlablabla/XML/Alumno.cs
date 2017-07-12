using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace prjBlablabla.XML
{
    public class Alumno
    {
        [XmlElement("Nombre")]
        public string Nombre { get; set; }
        [XmlElement("Grado")]
        public int Grado { get; set; }
        [XmlElement("Grupo")]
        public string Grupo { get; set; }
        [XmlElement("Sexo")]
        public string Sexo { get; set; }
        [XmlElement("Edad")]
        public int Edad { get; set; }
        [XmlElement("NLista")]
        public int NLista { get; set; }

    }
}