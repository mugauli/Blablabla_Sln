//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
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