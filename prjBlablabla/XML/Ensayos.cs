using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace prjBlablabla.XML
{
    public class Ensayos
    {
        [XmlElement("Ensayo")]
        public List<Ensayo> EnsayosList { get; set; }
    }

    public class Ensayo
    {
        [XmlElement("Juego")]
        public int Juego { get; set; }
        [XmlElement("Nivel")]
        public int Nivel { get; set; }
        [XmlElement("Consecutivo")]
        public int Consecutivo { get; set; }
        [XmlElement("Correcto")]
        public int Correcto { get; set; }
        [XmlElement("Tiempo")]
        public int Tiempo { get; set; }
        [XmlElement("Puntos")]
        public int Puntos { get; set; }
    }
}