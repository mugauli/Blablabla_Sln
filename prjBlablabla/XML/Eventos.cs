using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace prjBlablabla.XML
{
    [XmlRoot("Eventos")]
    public class Eventos
    {
        [XmlElement("Fecha")]
        public string Fecha { get; set; }
        [XmlElement("Alumno")]
        public Alumno Alumno { get; set; }
        [XmlElement("Ensayos")]
        public Ensayos Ensayos { get; set; }
    }
}