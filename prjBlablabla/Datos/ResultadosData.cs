using prjBlablabla.Common.Entities;
using prjBlablabla.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
                                                objResultado.Resultado,
                                                objResultado.Edad,
                                                objResultado.Sexo,
                                                objResultado.Tiempo,
                                                objResultado.Fecha,
                                                objResultado.Puntos
                                                );

                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<bool> { Code = -100, Message = ex.Message };
            }
        }

        public MethodResponseDTO<int[]> GetEscuelaResBy_EscuelaJuegoNivel(int idEscuela, int idJuego,int nivel, string fechaIni, string fechaFin)
        {
            try
            {
                var response = new MethodResponseDTO<int[]> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                   var res =  context.sp_ResBy_EscuelaJuegoNivel(idEscuela,idJuego,nivel,fechaIni,fechaFin).FirstOrDefault();
                   int correctas = res.Correcto ?? 0;
                   int incorrectas = res.Incorrecto ?? 0;

                   response.Result = new int[] { correctas, incorrectas };
                }

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<int[]> { Code = -100, Message = ex.Message };
            }
        }

        public MethodResponseDTO<int[]> GetGrupoGradoResBy_EscuelaJuegoNivel(int idEscuela, int idJuego, int nivel, string fechaIni, string fechaFin,int grado, string grupo)
        {
            try
            {
                var response = new MethodResponseDTO<int[]> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var res = context.sp_ResGradoGrupoBy_EscuelaJuegoNivel(idEscuela, idJuego, nivel,grado,grupo, fechaIni, fechaFin).FirstOrDefault();
                    int correctas = res.Correcto ?? 0;
                    int incorrectas = res.Incorrecto ?? 0;

                    response.Result = new int[] { correctas, incorrectas };
                }

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<int[]> { Code = -100, Message = ex.Message };
            }
        }

        public MethodResponseDTO<List<ResultadoPorNinoDTO>> GetninoResBy_EscuelaJuegoNivelGrupo(int idEscuela, int idJuego, int nivel,int grado,string grupo,string fechaIni, string fechaFin)
        {
            try
            {
                var response = new MethodResponseDTO<List<ResultadoPorNinoDTO>> { Code = 0 };
                var resultadosNino = new List<ResultadoPorNinoDTO>();
                using (var context = new BlablablaSitioEntities())
                {

                    var res = context.sp_ResultsNinoBy_EscuelaJuegoNivelGradoGrupo(idEscuela, idJuego, nivel,grado,grupo, fechaIni, fechaFin).ToList();
                    foreach (var r in res)
                    {
                        resultadosNino.Add(new ResultadoPorNinoDTO() { Grado = grado,
                                                                        Edad = (int)r.Edad,
                                                                        Sexo = r.Sexo,
                                                                        TotalEnsayos = (int)r.Total_de_Ensayos,
                                                                        Aciertos_x100 = (double)r.porcentaje_aciertos,
                                                                        Errores_x100 = (double)r.porcentaje_errores,
                                                                        Teimpo_reaccion = (double)r.Tiempo,
                                                                        Puntos = (int)r.Puntos
                        });
                    }

                }
                response.Result = resultadosNino;
                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<List<ResultadoPorNinoDTO>> { Code = -100, Message = ex.Message };
            }
        }

        public MethodResponseDTO<List<EntGroupChartResult>> GetGrupoResultsBy_EscuelaGrado(int idEscuela,int grado, string grupo, string fechaIni, string fechaFin)
        {
            try
            {
                var response = new MethodResponseDTO<List<EntGroupChartResult>> { Code = 0 };
                var resultadosGrupo = new List<EntGroupChartResult>();
                using (var context = new BlablablaSitioEntities())
                {

                    var res = context.sp_ResultsGrupoBy_EscuelaGrado(idEscuela,grado, grupo, fechaIni, fechaFin).ToList();
                    foreach (var r in res)
                    {

                        int juego = r.IdJuego;

                        resultadosGrupo.Add(new EntGroupChartResult()
                        {
                            Grado = grado,
                            Juego = "Juego " + r.IdJuego,
                            Nivel = r.Nivel,
                            Masculino = r.Sexo == "M" ? (int)r.TotalSexo: 0 ,
                            Femenino = r.Sexo == "F" ? (int)r.TotalSexo : 0,
                        });
                    }

                }
                response.Result = resultadosGrupo;
                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<List<EntGroupChartResult>> { Code = -100, Message = ex.Message };
            }
        }
    }
}