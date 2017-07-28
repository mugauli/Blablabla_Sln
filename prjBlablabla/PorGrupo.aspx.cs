using prjBlablabla.Common.Entities;
using prjBlablabla.Common.GetClases;
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
    public partial class PorGrupo : System.Web.UI.Page
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
            var resultado = GetGrupo.ByEscuela(idEscuela);

            if (resultado.Code != 0)
                resultado.Message ="Al obtener los grupos, Detalle: " + resultado.Message;
           
            System.Web.Script.Serialization.JavaScriptSerializer TheSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var TheJson = TheSerializer.Serialize(resultado);
            return TheJson;
        }

        [WebMethod]
        public static string ResultadosPor_EscuelaGrado(int idEscuela, string gradoGrupo, string fechaIni, string fechaFin)
        {
            var periodosLst = new List<string>();
            var grado_grupo = gradoGrupo.Split(' ');
            var filterQueryLst = new List<string>();
            var resLst = new List<EntGroupChartResult>();

            ResultToGroupo res; 

            periodosLst = EntPeriodoResult.GetPeriodos(fechaIni, fechaFin, out filterQueryLst);
            var i = 0;
            foreach (string filter in filterQueryLst)
            {
                var filterSplit = filter.Split('|');
                var datostablaResGrupo = new ResultadosData().GetGrupoResultsBy_EscuelaGrado(idEscuela, Convert.ToInt32(grado_grupo[0]), grado_grupo[1], filterSplit[0].Trim(), filterSplit[1].Trim(),periodosLst[i],"Escuela");

                if (datostablaResGrupo.Code == 0)
                {
                    foreach (var r in datostablaResGrupo.Result)
                    {
                        resLst.Add(r);
                    }
                }
                else
                {
                    
                }
                i++;
            }
          
            res = new ResultToGroupo(true, periodosLst.ToArray(), resLst.ToArray());
            System.Web.Script.Serialization.JavaScriptSerializer TheSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var TheJson = TheSerializer.Serialize(res);
            return TheJson;

        }

        public class ResultToGroupo
        {
            public bool success { get; private set; }
            public string[] periodos { get; private set; }
            public int[] aciertos { get; private set; }
            public int[] errores { get; private set; }
            public EntGroupChartResult[] result { get; private set; }

            public ResultToGroupo(bool succes_, string[] periodos_, EntGroupChartResult[] resultados_)
            {
                success = succes_;
                periodos = periodos_;
                result = resultados_;              

                var accLts = new List<int>();
                var errLts = new List<int>();

                foreach (var a in resultados_)
                {
                    accLts.Add(Convert.ToInt32(a.PromedioAciertos));
                    errLts.Add(Convert.ToInt32(a.PromedioErrores));

                }

                aciertos = accLts.ToArray();
                errores = accLts.ToArray();
            }
        }
    }


}