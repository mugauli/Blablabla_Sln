using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.ObjetosXML
{
    public class Person
    {
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public Person(string surName, string name, string date)
        {
            this.SurName = surName;
            this.Name = name;
            this.Date = date;
        }
    }
}