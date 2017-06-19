using prjBlablabla.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.Datos
{
    public class FrasesData
    {
        #region frasescomunes
        public MethodResponseDTO<bool> GuardarFrases(List<fraseDTO> frases)
        {
            try
            {
                var response = new MethodResponseDTO<bool> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbFrasesLts = context.ctFrases.ToList();

                    foreach (var objFrase in frases)
                    {



                        var frase = DbFrasesLts.Where(x => x.Id == objFrase.Id && x.nivel == objFrase.nivel && x.juego == objFrase.juego).ToList();

                        if (frase.Count > 0)
                        {
                            var DbFrase = context.ctFrases.Find(objFrase.Id);
                            DbFrase.enun1 = objFrase.enun1;
                            DbFrase.enun2 = objFrase.enun2;
                            DbFrase.correcta = objFrase.correcta;
                            DbFrase.opcion1 = objFrase.opcion1;
                            DbFrase.opcion2 = objFrase.opcion2;
                            DbFrase.opcion3 = objFrase.opcion3;
                            DbFrase.nivel = objFrase.nivel;
                            DbFrase.juego = objFrase.juego;
                            DbFrase.estado = true;
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
                                juego = objFrase.juego,
                                estado = true
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
        public MethodResponseDTO<bool> GuardarFrase(fraseDTO frase)
        {
            try
            {
                var response = new MethodResponseDTO<bool> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbFrase = context.ctFrases.Find(frase.Id);

                    if (DbFrase != null)
                    {

                        DbFrase.enun1 = frase.enun1;
                        DbFrase.enun2 = frase.enun2;
                        DbFrase.correcta = frase.correcta;
                        DbFrase.opcion1 = frase.opcion1;
                        DbFrase.opcion2 = frase.opcion2;
                        DbFrase.opcion3 = frase.opcion3;
                        DbFrase.estado = true;
                        context.SaveChanges();


                    }
                    else
                    {
                        var objCtFrase = new ctFrases
                        {
                            Id = frase.Id,
                            enun1 = frase.enun1,
                            enun2 = frase.enun2,
                            correcta = frase.correcta,
                            opcion1 = frase.opcion1,
                            opcion2 = frase.opcion2,
                            opcion3 = frase.opcion3,
                            estado = true
                        };
                        context.ctFrases.Add(objCtFrase);
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
        public MethodResponseDTO<List<fraseDTO>> ObtenerFrases()
        {
            try
            {
                var response = new MethodResponseDTO<List<fraseDTO>> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbFrasesLts = context.ctFrases.Where(x => x.estado == true).
                            Select(x => new fraseDTO
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
                return new MethodResponseDTO<List<fraseDTO>> { Code = -100, Message = ex.Message };
            }
        }
        #endregion

        #region shared
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
                    else
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

        #region silabitos
        public MethodResponseDTO<bool> GuardarFrasesSilabitos(List<fraseSilabitosDTO> frases)
        {
            try
            {
                var response = new MethodResponseDTO<bool> { Code = 0 };
                using (var context = new BlablablaSitioEntities())
                {

                    var DbFrasesLts = context.ctFrasesSilabitos.ToList();

                    foreach (var objFrase in frases)
                    {



                        var frase = DbFrasesLts.Where(x => x.Id == objFrase.Id).ToList();

                        if (frase.Count > 0)
                        {
                            var DbFrase = context.ctFrases.Find(objFrase.Id);
                            //DbFrase.enun1 = objFrase.enun1;
                            //DbFrase.enun2 = objFrase.enun2;
                            //DbFrase.correcta = objFrase.correcta;
                            //DbFrase.opcion1 = objFrase.opcion1;
                            //DbFrase.opcion2 = objFrase.opcion2;
                            //DbFrase.opcion3 = objFrase.opcion3;
                            context.SaveChanges();


                        }
                        else
                        {
                            var objCtFrase = new ctFrases
                            {
                                //Id = objFrase.Id,
                                //enun1 = objFrase.enun1,
                                //enun2 = objFrase.enun2,
                                //correcta = objFrase.correcta,
                                //opcion1 = objFrase.opcion1,
                                //opcion2 = objFrase.opcion2,
                                //opcion3 = objFrase.opcion3
                            };
                            context.ctFrases.Add(objCtFrase);
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


    }
}