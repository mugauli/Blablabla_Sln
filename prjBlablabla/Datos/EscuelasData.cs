using prjBlablabla.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.Datos
{
    public class EscuelasData
    {
        public MethodResponseDTO<List<EscuelaDTO>> ObtenerEscuelas()
        {
            try
            {
                var response = new MethodResponseDTO<List<EscuelaDTO>> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbEscuelasLst = context.Escuela.Select(x => new EscuelaDTO
                    {
                        
                       ID= x.ID,
                       Nombre = x.Nombre,
                       Direccion = x.Dirección
                    }).ToList();
                    response.Result = DbEscuelasLst;

                }
                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<List<EscuelaDTO>> { Code = -100, Message = ex.Message };
            }
        }

        public MethodResponseDTO<bool> BorrarEscuela(int idEscuela)
        {
            try
            {
                var response = new MethodResponseDTO<bool> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {
                    var DbEscuela = context.Escuela.Find(idEscuela);
                        
                    if (DbEscuela != null)
                    {
                        context.Escuela.Remove(DbEscuela);
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

        public MethodResponseDTO<bool> GuardarEscuela(EscuelaDTO Escuela)
        {
            try
            {
                var response = new MethodResponseDTO<bool> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbEscuela = context.Escuela.Find(Escuela.ID);

                    if (DbEscuela != null)
                    {

                        DbEscuela.Nombre = Escuela.Nombre;
                        DbEscuela.Dirección = Escuela.Direccion;
                        context.SaveChanges();


                    }
                    else
                    {
                        var objEscuela = new Escuela
                        {
                            Nombre = Escuela.Nombre,
                            Dirección = Escuela.Direccion
                        
                        };
                        context.Escuela.Add(objEscuela);
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