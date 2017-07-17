using prjBlablabla.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.Datos
{
    public class GruposData
    {
        public MethodResponseDTO<List<GrupoDTO>> ObtenerGrupos()
        {
            try
            {
                var response = new MethodResponseDTO<List<GrupoDTO>> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbEscuelasLst = context.Grupo.Select(x => new GrupoDTO
                    {

                        ID = x.ID,
                        Nombre = x.Nombre,
                        EscuelaID = x.EscuelaID,
                        GradoID = x.GradoID
                    }).ToList();
                    response.Result = DbEscuelasLst;

                }
                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<List<GrupoDTO>> { Code = -100, Message = ex.Message };
            }
        }

        public MethodResponseDTO<List<GrupoDTO>> ObtenerGruposPorEscuela(int idEscuela)
        {
            try
            {
                
                var response = new MethodResponseDTO<List<GrupoDTO>> { Code = 0 };
                var grupos = new List<GrupoDTO>();
                using (var context = new BlablablaSitioEntities())
                {
                    var resultado = context.sp_GetGruposByEscuela(idEscuela).ToList();
                    foreach(var r in resultado)
                    {
                        grupos.Add(new GrupoDTO() { Nombre = r.Grupo, GradoID = r.Grado });
                    }

                }
                response.Result = grupos;
                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<List<GrupoDTO>> { Code = -100, Message = ex.Message };
            }
        }

        public MethodResponseDTO<bool> BorrarGrupo(int idGrupo)
        {
            try
            {
                var response = new MethodResponseDTO<bool> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {
                    var DbGrupo = context.Grupo.Find(idGrupo);

                    if (DbGrupo != null)
                    {
                        context.Grupo.Remove(DbGrupo);
                        context.SaveChanges();
                    }
                    else
                    {
                        response.Code = -800;
                        response.Message = "La frase que desa borrar no existe.";
                    }
                    context.SaveChanges();
                }

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<bool> { Code = -100, Message = ex.Message };
            }
        }

        public MethodResponseDTO<bool> GuardarGrupo(GrupoDTO Grupo)
        {
            try
            {
                var response = new MethodResponseDTO<bool> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbGrupo = context.Grupo.Find(Grupo.ID);

                    if (DbGrupo != null)
                    {

                        DbGrupo.Nombre = Grupo.Nombre;
                        DbGrupo.EscuelaID = Grupo.EscuelaID;
                        DbGrupo.GradoID = Grupo.GradoID;
                        context.SaveChanges();


                    }
                    else
                    {
                        var objGrupo = new Grupo
                        {
                            Nombre = Grupo.Nombre,
                            EscuelaID=Grupo.EscuelaID,
                            GradoID=Grupo.GradoID

                    };
                        context.Grupo.Add(objGrupo);
                    }

                    context.SaveChanges();


                }

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<bool> { Code = -100, Message = ex.Message };
            }
        }
    }
}