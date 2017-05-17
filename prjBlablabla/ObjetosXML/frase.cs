using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace prjBlablabla.ObjetosXML
{
    public class frase
    {
        public List<opcion> opcion;

        [XmlAttribute]
        public int id;
        [XmlAttribute]
        public string enun1;
        [XmlAttribute]
        public string Name;
        [XmlAttribute]
        public string enun2;

    }
}