//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjBlablabla.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grupo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int EscuelaID { get; set; }
        public int GradoID { get; set; }
    
        public virtual Escuela Escuela { get; set; }
        public virtual Grado Grado { get; set; }
    }
}
