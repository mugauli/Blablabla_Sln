using prjBlablabla.Datos;
using prjBlablabla.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjBlablabla
{
    public partial class PorNino : System.Web.UI.Page
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
        public static string GetGruposByEscuela(int idEscuela)
        {
            ResultToGroup res;
            var datostablaGrupos = new GruposData().ObtenerGruposPorEscuela(idEscuela);
            if (datostablaGrupos.Code == 0)
            {
                if(datostablaGrupos.Result.Count > 0)
                {
                    List<string> grupos = datostablaGrupos.Result.Select(x => x.GradoID + " " + x.Nombre).ToList();
                    res = new ResultToGroup(true, grupos.ToArray());
                }
                else
                    res = new ResultToGroup(true, new string[] {"-Sin grupos disponibles-"});
            }
            else
            {
                res = new ResultToGroup( false, new string[]{ datostablaGrupos.Message});
            }

            System.Web.Script.Serialization.JavaScriptSerializer TheSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var TheJson = TheSerializer.Serialize(res);
            return TheJson;
        }

        [WebMethod]
        public static string GetNinoRes_By_EscuelaJuegoNivelGrupo(int idEscuela,string gradoGrupo,int juego,int nivel,string fechaIni, string fechaFin)
        {
            ResultToNino res;
            var resLst = new List<ResultadoPorNinoDTO>();
            var periodosLst = new List<string>();
            var grado_grupo = gradoGrupo.Split(' ');
            var filterQueryLst = new List<string>();
            periodosLst = GetPeriodos(fechaIni, fechaFin, out filterQueryLst);
            

            foreach (string filter in filterQueryLst)
            {
                var filterSplit = filter.Split('|');
                var datostablaResNino = new ResultadosData().GetninoResBy_EscuelaJuegoNivelGrupo(idEscuela, juego, nivel, Convert.ToInt32(grado_grupo[0]), grado_grupo[1], filterSplit[0].Trim(), filterSplit[1].Trim());

                if (datostablaResNino.Code == 0)
                {
                    if (datostablaResNino.Result.Count == 0)
                    {
                        res = new ResultToNino(false, periodosLst.ToArray(), resLst.ToArray());
                    }
                    else
                    {
                        foreach (var r in datostablaResNino.Result)
                        {
                            r.Juego = "Juego " + juego;
                            r.Nivel = nivel;

                            resLst.Add(r);
                        }


                    }

                }
                else
                {
                    res = new ResultToNino(false, periodosLst.ToArray(), resLst.ToArray());
                }
            }

            res = new ResultToNino(true, periodosLst.ToArray(), resLst.ToArray());


            System.Web.Script.Serialization.JavaScriptSerializer TheSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var TheJson = TheSerializer.Serialize(res);
            return TheJson;
        }

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
        public class ResultToGroup
        {
            public bool success { get; private set; }
            public string[] grupos { get; private set; }

            public ResultToGroup(bool succes_, string[] grupos_)
            {
                success = succes_;
                grupos = grupos_;
            }
        }

        public class ResultToNino
        {
            public bool success { get; private set; }
            public string[] periodos { get; private set; }
            public ResultadoPorNinoDTO[] result { get; private set; }

            public ResultToNino(bool succes_, string[] periodos_,ResultadoPorNinoDTO[] resultados_)
            {
                success = succes_;
                periodos = periodos_;
                result = resultados_;
            }
        }
    }
}