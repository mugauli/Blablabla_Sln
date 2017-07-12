using prjBlablabla.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.Datos
{
    public class ResultadosData
    {
        public MethodResponseDTO<bool> GuardarResultado(List<ResultadoDTO> Resultados)
        {
            try
            {
                var response = new MethodResponseDTO<bool> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {
                    foreach (var objResultado in Resultados)
                    {
                        context.sp_AddResultado(objResultado.IdEscuela,
                                                objResultado.NLista,
                                                objResultado.Grado,
                                                objResultado.Grupo,
                                                objResultado.IdJuego,
                                                objResultado.Nivel,
                                                objResultado.Consecutivo,
                                                objResultado.Resultado);

                    }
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