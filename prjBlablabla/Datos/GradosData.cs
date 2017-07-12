using prjBlablabla.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.Datos
{
    public class GradosData
    {
        public MethodResponseDTO<List<GradoDTO>> ObtenerGrados()
        {
            try
            {
                var response = new MethodResponseDTO<List<GradoDTO>> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbGradosLst = context.Grado.Select(x => new GradoDTO
                    {

                        ID = x.ID,
                         Grado=x.Grado1,
                         Descripcion = x.Descripción
                    }).ToList();
                    response.Result = DbGradosLst;

                }
                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<List<GradoDTO>> { Code = -100, Message = ex.Message };
            }
        }
    }
}