using prjBlablabla.Common.Entities;
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
            EntChartResult res;

            var periodosLst = new List<string>();
            var aciertosLst = new List<int>();
            var erroresLst = new List<int>();

            var filterQueryLst = new List<string>();
            periodosLst = EntPeriodoResult.GetPeriodos(fechaIni, fechaFin, out filterQueryLst);

            foreach (string filter in filterQueryLst)
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

            res = new EntChartResult(true,
                                   periodosLst.ToArray(),
                                   aciertosLst.ToArray(),
                                   erroresLst.ToArray());

            System.Web.Script.Serialization.JavaScriptSerializer TheSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var TheJson = TheSerializer.Serialize(res);
            return TheJson;

        }

    }
   }