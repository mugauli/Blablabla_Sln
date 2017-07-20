using prjBlablabla.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.Datos
{
    public class FrasesData
    {
        #region Guardar Frases
        public MethodResponseDTO<bool> GuardarFrasesTorre(List<FraseTorreDTO> frases)
        {
            try
            {
                var response = new MethodResponseDTO<bool> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {
                    foreach (var objFrase in frases)
                    {
                        var DbFrase = context.ctFrases.Find(objFrase.Id);

                        if (DbFrase != null)
                        {

                            DbFrase.enun1 = objFrase.enun1;
                            DbFrase.enun2 = objFrase.enun2;
                            DbFrase.correcta = objFrase.correcta;
                            DbFrase.opcion1 = objFrase.opcion1;
                            DbFrase.opcion2 = objFrase.opcion2;
                            DbFrase.opcion3 = objFrase.opcion3;
                            DbFrase.nivel = objFrase.nivel;
                            DbFrase.estado = objFrase.estado;
                            context.SaveChanges();
                        }
                        else
                        {
                            var objCtFrase = new ctFrases
                            {
                                Id = objFrase.Id,
                                enun1 = objFrase.enun1,
                                enun2 = objFrase.enun2,
                                correcta = objFrase.correcta,
                                opcion1 = objFrase.opcion1,
                                opcion2 = objFrase.opcion2,
                                opcion3 = objFrase.opcion3,
                                nivel = objFrase.nivel,
                                estado = objFrase.estado
                            };
                            context.ctFrases.Add(objCtFrase);
                            context.SaveChanges();
                        }

                        context.SaveChanges();
                    }


                }

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<bool> { Code = -100, Message = ex.Message };
            }
        }
        public MethodResponseDTO<bool> GuardarFrasesSilabitos(List<FraseSilabitosDTO> frases)
        {
            try
            {
                var response = new MethodResponseDTO<bool> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbFrasesLts = context.ctFrasesSilabitos.ToList();

                    foreach (var frase in frases)
                    {
                        var DbFrase = context.ctFrasesSilabitos.Find(frase.Id);

                        if (DbFrase != null)
                        {

                            DbFrase.c1 = frase.c1;
                            DbFrase.c2 = frase.c2;
                            DbFrase.c3 = frase.c3;
                            DbFrase.p1 = frase.p1;
                            DbFrase.p2 = frase.p2;
                            DbFrase.orden = frase.orden;
                            DbFrase.acomodo = frase.acomodo;
                            DbFrase.estado = frase.estado;
                            DbFrase.nivel = frase.nivel;
                        }
                        else
                        {
                            var objCtFrase = new ctFrasesSilabitos
                            {
                                c1 = frase.c1,
                                c2 = frase.c2,
                                c3 = frase.c3,
                                p1 = frase.p1,
                                p2 = frase.p2,
                                orden = frase.orden,
                                acomodo = frase.acomodo,
                                estado = frase.estado,
                                nivel = frase.nivel
                            };
                            context.ctFrasesSilabitos.Add(objCtFrase);
                        }

                        context.SaveChanges();
                    }


                }

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<bool> { Code = -100, Message = ex.Message };
            }
        }
        public MethodResponseDTO<bool> GuardarFrasesBosque(List<FrasesBosqueDTO> frases)
        {
            try
            {
                var response = new MethodResponseDTO<bool> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {
                    foreach (var frase in frases)
                    {
                        var DbFrase = context.ctFrasesBosque.Find(frase.Id);

                        if (DbFrase != null)
                        {
                            DbFrase.Frase = frase.Frase;
                            DbFrase.Opcion1 = frase.Opcion1;
                            DbFrase.Opcion2 = frase.Opcion2;
                            DbFrase.Correcta = frase.Correcta;
                            DbFrase.Nivel = frase.Nivel;
                            DbFrase.Estado = frase.Estado;


                        }
                        else
                        {
                            var objCtFrase = new ctFrasesBosque
                            {
                                Frase = frase.Frase,
                                Opcion1 = frase.Opcion1,
                                Opcion2 = frase.Opcion2,
                                Correcta = frase.Correcta,
                                Nivel = frase.Nivel,
                                Estado = frase.Estado
                            };
                            context.ctFrasesBosque.Add(objCtFrase);
                        }

                        context.SaveChanges();
                    }


                }

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<bool> { Code = -100, Message = ex.Message };
            }
        }
        public MethodResponseDTO<bool> GuardarFrasesCastillo(List<FraseCastilloDTO> frases)
        {
            try
            {
                var response = new MethodResponseDTO<bool> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbFrasesLts = context.ctFrasesSilabitos.ToList();

                    foreach (var frase in frases)
                    {
                        var DbFrase = context.ctFrasesCastillo.Find(frase.Id);

                        if (DbFrase != null)
                        {
                            DbFrase.Enunciado1 = frase.Enunciado1;
                            DbFrase.Enunciado2 = frase.Enunciado2;
                            DbFrase.Correcta = frase.Correcta;
                            DbFrase.Nivel = frase.Nivel;
                            DbFrase.Estado = frase.Estado;
                        }
                        else
                        {
                            var objCtFrase = new ctFrasesCastillo
                            {
                                Enunciado1 = frase.Enunciado1,
                                Enunciado2 = frase.Enunciado2,
                                Correcta = frase.Correcta,
                                Nivel = frase.Nivel,
                                Estado = frase.Estado
                            };
                            context.ctFrasesCastillo.Add(objCtFrase);
                        }

                        context.SaveChanges();
                    }


                }

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<bool> { Code = -100, Message = ex.Message };
            }
        }
        public MethodResponseDTO<bool> GuardarFrasesLago(List<FraseLagoDTO> frases)
        {
            try
            {
                var response = new MethodResponseDTO<bool> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbFrasesLts = context.ctFrasesSilabitos.ToList();

                    foreach (var frase in frases)
                    {

                        var DbFrase = context.ctFrasesLago.Find(frase.Id);

                        if (DbFrase != null)
                        {

                            DbFrase.Enunciado = frase.Enunciado;
                            DbFrase.Eleccion = frase.Eleccion;
                            DbFrase.Nivel = frase.Nivel;
                            DbFrase.Estado = frase.Estado;

                        }
                        else
                        {
                            var objCtFrase = new ctFrasesLago
                            {
                                Enunciado = frase.Enunciado,
                                Eleccion = frase.Eleccion,
                                Nivel = frase.Nivel,
                                Estado = frase.Estado

                            };
                            context.ctFrasesLago.Add(objCtFrase);
                        }

                        context.SaveChanges();
                    }


                }

                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<bool> { Code = -100, Message = ex.Message };
            }
        }

        #endregion

        #region Obtener Frases

        public MethodResponseDTO<List<FraseTorreDTO>> ObtenerFrasesTorre(int IdNivel)
        {
            try
            {
                var response = new MethodResponseDTO<List<FraseTorreDTO>> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbFrasesLts = context.ctFrases.Where(x => x.estado == true && x.nivel == IdNivel).
                            Select(x => new FraseTorreDTO
                            {
                                Id = x.Id,
                                enun1 = x.enun1,
                                enun2 = x.enun2,
                                correcta = x.correcta,
                                opcion1 = x.opcion1,
                                opcion2 = x.opcion2,
                                opcion3 = x.opcion3
                            }).ToList();

                    response.Result = DbFrasesLts;

                }
                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<List<FraseTorreDTO>> { Code = -100, Message = ex.Message };
            }
        }

        public MethodResponseDTO<List<FraseSilabitosDTO>> ObtenerFrasesSilabitos(int IdNivel)
        {
            try
            {
                var response = new MethodResponseDTO<List<FraseSilabitosDTO>> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbFrasesLts = context.ctFrasesSilabitos.Where(x => x.estado == true && x.nivel == IdNivel).
                            Select(x => new FraseSilabitosDTO
                            {
                                Id = x.Id,
                                c1 = x.c1,
                                c2 = x.c2,
                                c3 = x.c3,
                                p1 = x.p1,
                                p2 = x.p2,
                                orden = x.orden,
                                acomodo = x.acomodo,
                                estado = x.estado,
                                nivel = x.nivel
                            }).ToList();

                    response.Result = DbFrasesLts;

                }
                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<List<FraseSilabitosDTO>> { Code = -100, Message = ex.Message };
            }
        }

        public MethodResponseDTO<List<FrasesBosqueDTO>> ObtenerFrasesBosque(int IdNivel)
        {
            try
            {
                var response = new MethodResponseDTO<List<FrasesBosqueDTO>> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbFrasesLts = context.ctFrasesBosque.Where(x => x.Estado == true && x.Nivel == IdNivel).
                            Select(x => new FrasesBosqueDTO
                            {
                                Id = x.Id,
                                Frase = x.Frase,
                                Opcion1 = x.Opcion1,
                                Opcion2 = x.Opcion2,
                                Correcta = x.Correcta,
                                Nivel = x.Nivel,
                                Estado = x.Estado
                            }).ToList();

                    response.Result = DbFrasesLts;

                }
                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<List<FrasesBosqueDTO>> { Code = -100, Message = ex.Message };
            }
        }

        public MethodResponseDTO<List<FraseCastilloDTO>> ObtenerFrasesCastillo(int IdNivel)
        {
            try
            {
                var response = new MethodResponseDTO<List<FraseCastilloDTO>> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbFrasesLts = context.ctFrasesCastillo.Where(x => x.Estado == true && x.Nivel == IdNivel).
                            Select(x => new FraseCastilloDTO
                            {
                                Id = x.Id,
                                Enunciado1 = x.Enunciado1,
                                Enunciado2 = x.Enunciado2,
                                Correcta = x.Correcta,
                                Nivel = x.Nivel,
                                Estado = x.Estado
                            }).ToList();

                    response.Result = DbFrasesLts;

                }
                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<List<FraseCastilloDTO>> { Code = -100, Message = ex.Message };
            }
        }

        public MethodResponseDTO<List<FraseLagoDTO>> ObtenerFrasesLago(int IdNivel)
        {
            try
            {
                var response = new MethodResponseDTO<List<FraseLagoDTO>> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbFrasesLts = context.ctFrasesLago.Where(x => x.Estado == true && x.Nivel == IdNivel).
                            Select(x => new FraseLagoDTO
                            {
                                Id = x.Id,
                                Enunciado = x.Enunciado,
                                Eleccion = x.Eleccion,
                                Nivel = x.Nivel,
                                Estado = x.Estado

                            }).ToList();

                    response.Result = DbFrasesLts;

                }
                return response;
            }
            catch (Exception ex)
            {
                return new MethodResponseDTO<List<FraseLagoDTO>> { Code = -100, Message = ex.Message };
            }
        }
        #endregion

        #region Borrar frases

        /// <summary>
        /// Borrar frase por tipo 
        /// 1: Torre
        /// 2: Silabitos
        /// 3: Bosque
        /// 4: Castillo
        /// 5: Lago
        /// </summary>
        /// <param name="idfrase"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public MethodResponseDTO<bool> BorrarFrase(int idfrase, int tipo)
        {
            try
            {
                var response = new MethodResponseDTO<bool> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    if (tipo == 1)
                    {
                        var DbFrase = context.ctFrases.Find(idfrase);

                        if (DbFrase != null)
                        {
                            DbFrase.estado = false;
                            context.SaveChanges();
                        }
                        else
                        {

                            response.Code = -800;
                            response.Message = "La frase que desa borrar no existe.";
                        }
                    }
                    else if (tipo == 2)
                    {
                        var DbFrase = context.ctFrasesSilabitos.Find(idfrase);

                        if (DbFrase != null)
                        {
                            DbFrase.estado = false;
                            context.SaveChanges();
                        }
                        else
                        {

                            response.Code = -800;
                            response.Message = "La frase que desa borrar no existe.";
                        }
                    }
                    else if (tipo == 3)
                    {
                        var DbFrase = context.ctFrasesBosque.Find(idfrase);

                        if (DbFrase != null)
                        {
                            DbFrase.Estado = false;
                            context.SaveChanges();
                        }
                        else
                        {

                            response.Code = -800;
                            response.Message = "La frase que desa borrar no existe.";
                        }
                    }
                    else if (tipo == 4)
                    {
                        var DbFrase = context.ctFrasesCastillo.Find(idfrase);

                        if (DbFrase != null)
                        {
                            DbFrase.Estado = false;
                            context.SaveChanges();
                        }
                        else
                        {

                            response.Code = -800;
                            response.Message = "La frase que desa borrar no existe.";
                        }
                    }
                    else if (tipo == 5)
                    {
                        var DbFrase = context.ctFrasesLago.Find(idfrase);

                        if (DbFrase != null)
                        {
                            DbFrase.Estado = false;
                            context.SaveChanges();
                        }
                        else
                        {

                            response.Code = -800;
                            response.Message = "La frase que desa borrar no existe.";
                        }
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

        #endregion

    }
}