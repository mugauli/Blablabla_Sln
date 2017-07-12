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
    public partial class Escuelas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllEscuelas();
        }

        public void GetAllEscuelas()
        {
            string table = string.Empty;
            var datostablaEscuela = new EscuelasData().ObtenerEscuelas();

            if (datostablaEscuela.Code == 0)
            {
                foreach (var a in datostablaEscuela.Result)
                {
                    table += @" <tr>"
                                  + "<td>" + a.ID + "</td>"
                                  + "<td>" + a.Nombre + "</td>"
                                  + "<td>" + a.Direccion + "</td>"
                                  + "<td>"
                                     + "<button type='button' id='btnEditarFrase' class='btn btn-success csBtnEditarEscuela' data-toggle='modal' data-target='#addEscuela' data-id='" + a.ID + "' data-nombre='" + a.Nombre + "' data-direccion='" + a.Direccion + "'><i class='fa fa-pencil'></i></button>"
                                     + "<button type='button' id='btnBorrarFrase' class='btn btn-danger csBtnBorrarEscuela' data-toggle='modal' data-target='#borrarEscuela' data-id='" + a.ID + "' ><i class='fa fa-trash-o'></i></button>"
                                     + "<button type='button'  class='btn btn-info csBtnGrupos' data-toggle='modal'  data-id='" + a.ID + "' ><i class='fa fa-bars'></i></button>"
                                  + "</td>"
                              + " </tr>";
                }
                ltlTableEscuelas.Text = table;
            }
        }

        protected void btnBorrarEscuela_Click(object sender, EventArgs e)
        {
            var objEscuela = new EscuelasData().BorrarEscuela(int.Parse(IdEscuelaBorrar.Value));

            if (objEscuela.Code != 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", objEscuela.Message, true);
            else
                GetAllEscuelas();
        }

        protected void GuardarEscuela_Click(object sender, EventArgs e)
        {
            var escuela = new EscuelaDTO
            {
                ID = int.Parse(IdEscuela.Value),
                Nombre = nombre.Text,
                Direccion = direccion.Text,
                
            };

            var objfrase = new EscuelasData().GuardarEscuela(escuela);

            if (objfrase.Code != 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", objfrase.Message, true);
            else
            {
                GetAllEscuelas();
                BorrarFormulario();
            }
        }

        protected void BorrarFormulario()
        {
            nombre.Text = "";
            direccion.Text = "";
        }
    }
}