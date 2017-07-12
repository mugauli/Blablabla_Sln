using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace prjBlablabla.XML
{
    [XmlRoot("Estadistica")]
    public class Estadistica
    {
        [XmlElement("Eventos")]
        public List<Eventos> Eventos { get; set; }
    }
}