﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    
    public partial class BlablablaSitioEntities : DbContext
    {
        public BlablablaSitioEntities()
            : base("name=BlablablaSitioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<ctFrases> ctFrases { get; set; }
        public DbSet<ctFrasesBosque> ctFrasesBosque { get; set; }
        public DbSet<ctFrasesCastillo> ctFrasesCastillo { get; set; }
        public DbSet<ctFrasesLago> ctFrasesLago { get; set; }
        public DbSet<ctFrasesSilabitos> ctFrasesSilabitos { get; set; }
        public DbSet<Escuela> Escuela { get; set; }
        public DbSet<Escuelas> Escuelas { get; set; }
        public DbSet<Grado> Grado { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Resultados> Resultados { get; set; }
    
        public virtual int sp_AddResultado(Nullable<int> idEscuela, Nullable<int> nLista, Nullable<int> grado, string grupo, Nullable<int> idJuego, Nullable<int> nivel, Nullable<int> consecutivo, Nullable<int> resultado, Nullable<int> edad, string sexo, Nullable<int> tiempo, Nullable<System.DateTime> fecha, Nullable<int> puntos)
        {
            var idEscuelaParameter = idEscuela.HasValue ?
                new ObjectParameter("IdEscuela", idEscuela) :
                new ObjectParameter("IdEscuela", typeof(int));
    
            var nListaParameter = nLista.HasValue ?
                new ObjectParameter("NLista", nLista) :
                new ObjectParameter("NLista", typeof(int));
    
            var gradoParameter = grado.HasValue ?
                new ObjectParameter("Grado", grado) :
                new ObjectParameter("Grado", typeof(int));
    
            var grupoParameter = grupo != null ?
                new ObjectParameter("Grupo", grupo) :
                new ObjectParameter("Grupo", typeof(string));
    
            var idJuegoParameter = idJuego.HasValue ?
                new ObjectParameter("IdJuego", idJuego) :
                new ObjectParameter("IdJuego", typeof(int));
    
            var nivelParameter = nivel.HasValue ?
                new ObjectParameter("Nivel", nivel) :
                new ObjectParameter("Nivel", typeof(int));
    
            var consecutivoParameter = consecutivo.HasValue ?
                new ObjectParameter("Consecutivo", consecutivo) :
                new ObjectParameter("Consecutivo", typeof(int));
    
            var resultadoParameter = resultado.HasValue ?
                new ObjectParameter("Resultado", resultado) :
                new ObjectParameter("Resultado", typeof(int));
    
            var edadParameter = edad.HasValue ?
                new ObjectParameter("Edad", edad) :
                new ObjectParameter("Edad", typeof(int));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var tiempoParameter = tiempo.HasValue ?
                new ObjectParameter("Tiempo", tiempo) :
                new ObjectParameter("Tiempo", typeof(int));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var puntosParameter = puntos.HasValue ?
                new ObjectParameter("Puntos", puntos) :
                new ObjectParameter("Puntos", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddResultado", idEscuelaParameter, nListaParameter, gradoParameter, grupoParameter, idJuegoParameter, nivelParameter, consecutivoParameter, resultadoParameter, edadParameter, sexoParameter, tiempoParameter, fechaParameter, puntosParameter);
        }
    
        public virtual ObjectResult<sp_GetGruposByEscuela_Result> sp_GetGruposByEscuela(Nullable<int> idEscuela)
        {
            var idEscuelaParameter = idEscuela.HasValue ?
                new ObjectParameter("IdEscuela", idEscuela) :
                new ObjectParameter("IdEscuela", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetGruposByEscuela_Result>("sp_GetGruposByEscuela", idEscuelaParameter);
        }
    
        public virtual ObjectResult<sp_ResBy_EscuelaJuegoNivel_Result> sp_ResBy_EscuelaJuegoNivel(Nullable<int> idEscuela, Nullable<int> idJuego, Nullable<int> nivel, string fechaini, string fechafin)
        {
            var idEscuelaParameter = idEscuela.HasValue ?
                new ObjectParameter("IdEscuela", idEscuela) :
                new ObjectParameter("IdEscuela", typeof(int));
    
            var idJuegoParameter = idJuego.HasValue ?
                new ObjectParameter("IdJuego", idJuego) :
                new ObjectParameter("IdJuego", typeof(int));
    
            var nivelParameter = nivel.HasValue ?
                new ObjectParameter("Nivel", nivel) :
                new ObjectParameter("Nivel", typeof(int));
    
            var fechainiParameter = fechaini != null ?
                new ObjectParameter("fechaini", fechaini) :
                new ObjectParameter("fechaini", typeof(string));
    
            var fechafinParameter = fechafin != null ?
                new ObjectParameter("fechafin", fechafin) :
                new ObjectParameter("fechafin", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ResBy_EscuelaJuegoNivel_Result>("sp_ResBy_EscuelaJuegoNivel", idEscuelaParameter, idJuegoParameter, nivelParameter, fechainiParameter, fechafinParameter);
        }
    
        public virtual ObjectResult<sp_ResGradoGrupoBy_EscuelaJuegoNivel_Result> sp_ResGradoGrupoBy_EscuelaJuegoNivel(Nullable<int> idEscuela, Nullable<int> idJuego, Nullable<int> nivel, Nullable<int> grado, string grupo, string fechaini, string fechafin)
        {
            var idEscuelaParameter = idEscuela.HasValue ?
                new ObjectParameter("IdEscuela", idEscuela) :
                new ObjectParameter("IdEscuela", typeof(int));
    
            var idJuegoParameter = idJuego.HasValue ?
                new ObjectParameter("IdJuego", idJuego) :
                new ObjectParameter("IdJuego", typeof(int));
    
            var nivelParameter = nivel.HasValue ?
                new ObjectParameter("Nivel", nivel) :
                new ObjectParameter("Nivel", typeof(int));
    
            var gradoParameter = grado.HasValue ?
                new ObjectParameter("Grado", grado) :
                new ObjectParameter("Grado", typeof(int));
    
            var grupoParameter = grupo != null ?
                new ObjectParameter("Grupo", grupo) :
                new ObjectParameter("Grupo", typeof(string));
    
            var fechainiParameter = fechaini != null ?
                new ObjectParameter("fechaini", fechaini) :
                new ObjectParameter("fechaini", typeof(string));
    
            var fechafinParameter = fechafin != null ?
                new ObjectParameter("fechafin", fechafin) :
                new ObjectParameter("fechafin", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ResGradoGrupoBy_EscuelaJuegoNivel_Result>("sp_ResGradoGrupoBy_EscuelaJuegoNivel", idEscuelaParameter, idJuegoParameter, nivelParameter, gradoParameter, grupoParameter, fechainiParameter, fechafinParameter);
        }
    
        public virtual ObjectResult<sp_ResNinoBy_EscuelaJuegoNivelGradoGrupo_Result> sp_ResNinoBy_EscuelaJuegoNivelGradoGrupo(Nullable<int> idEscuela, Nullable<int> idJuego, Nullable<int> nivel, Nullable<int> grado, string grupo, string fechaini, string fechafin)
        {
            var idEscuelaParameter = idEscuela.HasValue ?
                new ObjectParameter("IdEscuela", idEscuela) :
                new ObjectParameter("IdEscuela", typeof(int));
    
            var idJuegoParameter = idJuego.HasValue ?
                new ObjectParameter("IdJuego", idJuego) :
                new ObjectParameter("IdJuego", typeof(int));
    
            var nivelParameter = nivel.HasValue ?
                new ObjectParameter("Nivel", nivel) :
                new ObjectParameter("Nivel", typeof(int));
    
            var gradoParameter = grado.HasValue ?
                new ObjectParameter("Grado", grado) :
                new ObjectParameter("Grado", typeof(int));
    
            var grupoParameter = grupo != null ?
                new ObjectParameter("Grupo", grupo) :
                new ObjectParameter("Grupo", typeof(string));
    
            var fechainiParameter = fechaini != null ?
                new ObjectParameter("fechaini", fechaini) :
                new ObjectParameter("fechaini", typeof(string));
    
            var fechafinParameter = fechafin != null ?
                new ObjectParameter("fechafin", fechafin) :
                new ObjectParameter("fechafin", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ResNinoBy_EscuelaJuegoNivelGradoGrupo_Result>("sp_ResNinoBy_EscuelaJuegoNivelGradoGrupo", idEscuelaParameter, idJuegoParameter, nivelParameter, gradoParameter, grupoParameter, fechainiParameter, fechafinParameter);
        }
    
        public virtual ObjectResult<sp_ResultsEscuelaBy_GradoGrupo_Result> sp_ResultsEscuelaBy_GradoGrupo(Nullable<int> idEscuela, Nullable<int> grado, string grupo, string fechaini, string fechafin)
        {
            var idEscuelaParameter = idEscuela.HasValue ?
                new ObjectParameter("IdEscuela", idEscuela) :
                new ObjectParameter("IdEscuela", typeof(int));
    
            var gradoParameter = grado.HasValue ?
                new ObjectParameter("Grado", grado) :
                new ObjectParameter("Grado", typeof(int));
    
            var grupoParameter = grupo != null ?
                new ObjectParameter("Grupo", grupo) :
                new ObjectParameter("Grupo", typeof(string));
    
            var fechainiParameter = fechaini != null ?
                new ObjectParameter("fechaini", fechaini) :
                new ObjectParameter("fechaini", typeof(string));
    
            var fechafinParameter = fechafin != null ?
                new ObjectParameter("fechafin", fechafin) :
                new ObjectParameter("fechafin", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ResultsEscuelaBy_GradoGrupo_Result>("sp_ResultsEscuelaBy_GradoGrupo", idEscuelaParameter, gradoParameter, grupoParameter, fechainiParameter, fechafinParameter);
        }
    
        public virtual ObjectResult<sp_ResultsGrupoBy_EscuelaGrado_Result> sp_ResultsGrupoBy_EscuelaGrado(Nullable<int> idEscuela, Nullable<int> grado, string grupo, string fechaini, string fechafin)
        {
            var idEscuelaParameter = idEscuela.HasValue ?
                new ObjectParameter("IdEscuela", idEscuela) :
                new ObjectParameter("IdEscuela", typeof(int));
    
            var gradoParameter = grado.HasValue ?
                new ObjectParameter("Grado", grado) :
                new ObjectParameter("Grado", typeof(int));
    
            var grupoParameter = grupo != null ?
                new ObjectParameter("Grupo", grupo) :
                new ObjectParameter("Grupo", typeof(string));
    
            var fechainiParameter = fechaini != null ?
                new ObjectParameter("fechaini", fechaini) :
                new ObjectParameter("fechaini", typeof(string));
    
            var fechafinParameter = fechafin != null ?
                new ObjectParameter("fechafin", fechafin) :
                new ObjectParameter("fechafin", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ResultsGrupoBy_EscuelaGrado_Result>("sp_ResultsGrupoBy_EscuelaGrado", idEscuelaParameter, gradoParameter, grupoParameter, fechainiParameter, fechafinParameter);
        }
    
        public virtual ObjectResult<sp_ResultsNinoBy_EscuelaJuegoNivelGradoGrupo_Result> sp_ResultsNinoBy_EscuelaJuegoNivelGradoGrupo(Nullable<int> idEscuela, Nullable<int> idJuego, Nullable<int> nivel, Nullable<int> grado, string grupo, string fechaini, string fechafin)
        {
            var idEscuelaParameter = idEscuela.HasValue ?
                new ObjectParameter("IdEscuela", idEscuela) :
                new ObjectParameter("IdEscuela", typeof(int));
    
            var idJuegoParameter = idJuego.HasValue ?
                new ObjectParameter("IdJuego", idJuego) :
                new ObjectParameter("IdJuego", typeof(int));
    
            var nivelParameter = nivel.HasValue ?
                new ObjectParameter("Nivel", nivel) :
                new ObjectParameter("Nivel", typeof(int));
    
            var gradoParameter = grado.HasValue ?
                new ObjectParameter("Grado", grado) :
                new ObjectParameter("Grado", typeof(int));
    
            var grupoParameter = grupo != null ?
                new ObjectParameter("Grupo", grupo) :
                new ObjectParameter("Grupo", typeof(string));
    
            var fechainiParameter = fechaini != null ?
                new ObjectParameter("fechaini", fechaini) :
                new ObjectParameter("fechaini", typeof(string));
    
            var fechafinParameter = fechafin != null ?
                new ObjectParameter("fechafin", fechafin) :
                new ObjectParameter("fechafin", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ResultsNinoBy_EscuelaJuegoNivelGradoGrupo_Result>("sp_ResultsNinoBy_EscuelaJuegoNivelGradoGrupo", idEscuelaParameter, idJuegoParameter, nivelParameter, gradoParameter, grupoParameter, fechainiParameter, fechafinParameter);
        }
    }
}
