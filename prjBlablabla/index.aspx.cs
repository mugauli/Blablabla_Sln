using prjBlablabla.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjBlablabla
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillEscuelasDropDown();
            }

        }

        private void FillEscuelasDropDown()
        {
            var datostablaEscuela = new EscuelasData().ObtenerEscuelas();
            if (datostablaEscuela.Code == 0)
            {
                ddListEscuelas.DataTextField = "Nombre";
                ddListEscuelas.DataValueField = "ID";
                ddListEscuelas.DataSource = datostablaEscuela.Result;
                ddListEscuelas.DataBind();
            }
        }

        [WebMethod]
        public static string GetEscuelaRes_By_EscuelaJuegoNivel(int idEscuela, int idJuego, int nivel, string fechaIni, string fechaFin)
        {
            ResultToChart res;

            var periodosLst = new List<string>();
            var aciertosLst = new List<int>();
            var erroresLst = new List<int>();

            var filterQueryLst = new List<string>();
            periodosLst = GetPeriodos(fechaIni,fechaFin, out filterQueryLst);

            foreach(string filter in filterQueryLst)
            {
                var filterSplit = filter.Split('|');
                var response = new ResultadosData().GetEscuelaResBy_EscuelaJuegoNivel(idEscuela, idJuego, nivel, filterSplit[0].Trim(), filterSplit[1].Trim());
                if (response.Code != 0)
                {
                    
                }
                else
                {
                    aciertosLst.Add(response.Result[0]);
                    erroresLst.Add(response.Result[1]);
                }
            }

            res = new ResultToChart(true,
                                   periodosLst.ToArray(),
                                   aciertosLst.ToArray(),
                                   erroresLst.ToArray());


            //var ej1 = new int[] { 5, 9, 3, 8, 10, 10 };
            //var ej2 = new int[] { 5, 1, 7, 2, 0,0 };


            //res = new ResultToChart(true,
            //                       periodosLst.ToArray(),
            //                       ej1.ToArray(),
            //                       ej2.ToArray());
            System.Web.Script.Serialization.JavaScriptSerializer TheSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var TheJson = TheSerializer.Serialize(res);
            return TheJson;

        }

        /// <summary>
        /// Obtiene los periodos quincenales entre las fechas recibidas.
        /// </summary>
        /// <param name="fechaIni">Rango Inicial de fechas</param>
        /// <param name="fechaFin">Rango Final de fechas</param>
        /// <returns></returns>
        private static List<string> GetPeriodos(string fechaIni, string fechaFin, out List<string> filterQuery)
        {
            var periodosLst = new List<string>();
            var filters = new List<string>();
            var dateStart = Convert.ToDateTime(fechaIni);
            var dateEnd = Convert.ToDateTime(fechaFin);

            var ready = false;

            var monthStart = dateStart.Month;
            var monthEnd = dateEnd.Month;

            var yearStart = dateStart.Year;
            var yearEnd = dateEnd.Year;

            var dayIni = dateStart.Day;
            var dayEnd = dateEnd.Day;

            var strI = "";
            var strF = "";

            while (ready == false)
            {
                if (monthStart == monthEnd)
                {//mismo mes
                    if (yearStart == yearEnd)//mismo año
                    {
                        if ((dayIni <= 15 && dayEnd <= 15))
                        {
                            periodosLst.Add("1/" + monthStart);

                            strI = dayIni + "/" + monthStart + "/" + yearStart;
                            strF = dayEnd + "/" + monthEnd + "/" + yearEnd;
                            filters.Add(strI + " | " + strF);
                        }
                        else if ((dayIni > 15 && dayEnd > 15))
                        {
                            periodosLst.Add("2/" + monthStart);

                            strI = dayIni + "/" + monthStart + "/" + yearStart;
                            strF = dayEnd + "/" + monthEnd + "/" + yearEnd;
                            filters.Add(strI + " | " + strF);
                        }
                        else if ((dayIni <= 15 && dayEnd > 15))
                        {
                            periodosLst.Add("1/" + monthStart);
                            periodosLst.Add("2/" + monthStart);

                            strI = dayIni + "/" + monthStart + "/" + yearStart;
                            strF = 15 + "/" + monthEnd + "/" + yearEnd;
                            filters.Add(strI + " | " + strF);

                            strI = 16 + "/" + monthStart + "/" + yearStart;
                            strF = dayEnd + "/" + monthEnd + "/" + yearEnd;
                            filters.Add(strI + " | " + strF);
                        }
                        ready = true;
                    }
                    else//Año diferente
                    {
                        if (dayIni <= 15)
                        {
                            periodosLst.Add("1/" + monthStart);
                            periodosLst.Add("2/" + monthStart);

                            strI = 1 + "/" + monthStart + "/" + yearStart;
                            strF = 15 + "/" + monthStart + "/" + yearStart;
                            filters.Add(strI + " | " + strF);

                            strI = 16 + "/" + monthStart + "/" + yearStart;
                            strF = 31 + "/" + monthStart + "/" + yearStart;
                            filters.Add(strI + " | " + strF);
                        }
                        else
                        {
                            periodosLst.Add("2/" + monthStart);

                            strI = 16 + "/" + monthStart + "/" + yearStart;
                            strF = 31 + "/" + monthStart + "/" + yearStart;
                            filters.Add(strI + " | " + strF);
                        }

                        //aumento en el contador de meses y años
                        yearStart = monthStart == 12 ? yearStart += 1 : yearStart;
                        monthStart = monthStart == 12 ? 1 : monthStart += 1;
                    }

                }
                else
                {
                    if (dayIni <= 15)
                    {
                        periodosLst.Add("1/" + monthStart);
                        periodosLst.Add("2/" + monthStart);

                        strI = 1 + "/" + monthStart + "/" + yearStart;
                        strF = 15 + "/" + monthStart + "/" + yearStart;
                        filters.Add(strI + " | " + strF);

                        strI = 16 + "/" + monthStart + "/" + yearStart;
                        strF = 31 + "/" + monthStart + "/" + yearStart;
                        filters.Add(strI + " | " + strF);
                    }
                    else
                    {
                        periodosLst.Add("2/" + monthStart);
                        strI = 16 + "/" + monthStart + "/" + yearStart;
                        strF = 31 + "/" + monthStart + "/" + yearStart;
                        filters.Add(strI + " | " + strF);
                    }
                    //aumento en el contador de meses y años
                    yearStart = monthStart == 12 ? yearStart += 1 : yearStart;
                    monthStart = monthStart == 12 ? 1 : monthStart += 1;
                }
            }

            filterQuery = filters;
            return periodosLst;
        }

        public class ResultToChart
        {
            public bool success { get; private set; }
            public string[] periodos { get; private set; }
            public int[] aciertos { get; private set; }
            public int[] errores { get; private set; }

            public ResultToChart(bool succes_, string[] periodos_,int[] aciertos_, int[] errores_)
            {
                success = succes_;
                periodos = periodos_;
                aciertos = aciertos_;
                errores = errores_;
            }
        }
    }
   }