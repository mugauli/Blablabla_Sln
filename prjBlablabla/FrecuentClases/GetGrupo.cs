using prjBlablabla.Common.Entities;
using prjBlablabla.Datos;
using prjBlablabla.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBlablabla.Common.GetClases
{
    public static class GetGrupo
    {
        public static MethodResponseDTO<EntGroupResult> ByEscuela(int idEscuela)
        {
            try
            {
                EntGroupResult res;
                var datostablaGrupos = new GruposData().ObtenerGruposPorEscuela(idEscuela);
                if (datostablaGrupos.Code == 0)
                {
                    if (datostablaGrupos.Result.Count > 0)
                    {
                        List<string> grupos = datostablaGrupos.Result.Select(x => x.GradoID + " " + x.Nombre).ToList();
                        res = new EntGroupResult(true, grupos.ToArray());
                    }
                    else
                        res = new EntGroupResult(true, new string[] { "-Sin grupos disponibles-" });
                }
                else
                {
                    res = new EntGroupResult(false, new string[] { datostablaGrupos.Message });
                }

                return new MethodResponseDTO<EntGroupResult> { Result = res};
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<EntGroupResult> { Code = -100, Message = ex.Message };
            }

        }
    }
}
