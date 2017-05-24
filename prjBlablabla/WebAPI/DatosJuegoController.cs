using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace prjBlablabla.WebAPI
{
    public class DatosJuegoController : ApiController
    {
        // GET api/<controller>
        public string GetSilabitos()
        {
            return "GETsilabitos";
        }

        public string GetTorreTesoro()
        {
            try
            {
                //var nodo = new Node(1108);

                var xmlReturn = @"<?xml version='1.0' encoding='UTF-8'?>
                            <frases>";


                //foreach (Node feFrase in nodo.Children)
                //{

                //    xmlReturn += @"<frase id='" + (feFrase.GetProperty("Id") != null ? feFrase.GetProperty("Id").Value : "Id") + "' " +
                //                      "enun1='" + (feFrase.GetProperty("Enunciado_frase") != null ? feFrase.GetProperty("Enunciado_frase").Value : "0") + "' " +
                //                      "enun2='" + (feFrase.GetProperty("Segundo_enunciado") != null ? feFrase.GetProperty("Segundo_enunciado").Value : "0") + "' ";


                //    string opciones = string.Empty;
                //    foreach (Node feOpcion in feFrase.Children)
                //    {
                //        //opciones += feOpcion.Name;
                //        if (feOpcion.GetProperty("correcta") != null)
                //        {
                //            if ((feOpcion.GetProperty("correcta").Value).ToString() == "1") xmlReturn += "correcta='1'>";
                //            opciones += "  <opcion correct='" + (feOpcion.GetProperty("correcta").Value).ToString() + "'>" + (feOpcion.GetProperty("descripcion") != null ? feOpcion.GetProperty("descripcion").Value : "0") + "</opcion>";
                //        }
                //    }
                //    xmlReturn += opciones;
                //    xmlReturn += "</frase>";

                //}

                //xmlReturn += "</frases>";

                return xmlReturn;
            }
            catch (Exception ex)
            {
                return ex.Message + (ex.InnerException == null ? "" : " Innerexception: " + ex.InnerException.Message) + " StackTrace: " + (ex.StackTrace);

            }
        }
    }
}