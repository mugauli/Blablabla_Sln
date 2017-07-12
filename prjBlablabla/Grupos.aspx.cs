using prjBlablabla.Datos;
using prjBlablabla.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjBlablabla
{
    public partial class Grupos : System.Web.UI.Page
    {
        int idEscuela;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idEscuela"] != null)
            {
                //lblEscuela.Text = GetEscuelaName();
                idEscuela = int.Parse(Request.QueryString["idEscuela"]);
                FillGradoDropDoen();
                GetAllGruposByEscuela(idEscuela);
               
            }
               //mandar error 
        }

        //private string GetEscuelaName()
        //{
        //    var datostablaGrado = new GradosData().ObtenerGrados();
        //}

        private void FillGradoDropDoen()
        {
            var datostablaGrado = new GradosData().ObtenerGrados();
            if (datostablaGrado.Code == 0)
            {
                ddListGrado.DataTextField = "Descripcion";
                ddListGrado.DataValueField = "ID";
                ddListGrado.DataSource = datostablaGrado.Result;
                ddListGrado.DataBind();
            }
        }
        protected void GuardarGrupo_Click(object sender, EventArgs e)
        {
            var grupo = new GrupoDTO
            {
                ID = int.Parse(IdGrupo.Value),
                Nombre = nombre.Text,
                GradoID = int.Parse(ddListGrado.SelectedValue),
                EscuelaID= idEscuela
            };

            var objfrase = new GruposData().GuardarGrupo(grupo);

            if (objfrase.Code != 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", objfrase.Message, true);
            else
            {
                GetAllGruposByEscuela(idEscuela);
                //BorrarFormulario();
            }
        }
        protected void btnBorrarGrupo_Click(object sender, EventArgs e)
        {
            var objEscuela = new GruposData().BorrarGrupo(int.Parse(IdGrupo.Value));

            if (objEscuela.Code != 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", objEscuela.Message, true);
            else
                GetAllGruposByEscuela(idEscuela);
        }
        public void GetAllGruposByEscuela(int idEscuela)
        {
            string table = string.Empty;
            var datostablaGrupo = new GruposData().ObtenerGruposPorEscuela(idEscuela);

            if (datostablaGrupo.Code == 0)
            {
                foreach (var a in datostablaGrupo.Result)
                {
                    table += @" <tr>"
                                  + "<td>" + a.ID + "</td>"
                                  + "<td>" + a.GradoID + " "+ a.Nombre + "</td>"
                                  + "<td>"
                                     + "<button type='button'  class='btn btn-success csBtnEditarGrupo' data-toggle='modal' data-target='#addGrupo' data-id='" + a.ID + "' data-nombre='" + a.Nombre + "' data-grado='" + a.GradoID + "'><i class='fa fa-pencil'></i></button>"
                                     + "<button type='button'  class='btn btn-danger csBtnBorrarGrupo' data-toggle='modal' data-target='#borrarGrupo' data-id='" + a.ID + "' ><i class='fa fa-trash-o'></i></button>"
                                     
                                  + "</td>"
                              + " </tr>";
                }
                ltlTableGrupos.Text = table;
            }
        }

    
    }
}