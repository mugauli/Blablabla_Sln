using prjBlablabla.Datos;
using prjBlablabla.DTO;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace prjBlablabla
{
    public partial class DatosSilabitos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                llenarTabla(1);
            }

        }

        protected void GuardarFrase_Click(object sender, EventArgs e)
        {
            var Fraselts = new List<FraseSilabitosDTO>();
            var frase = new FraseSilabitosDTO
            {
                Id = int.Parse(IdFrase.Value),
                c1 = C1.Text,
                c2 = C2.Text,
                c3 = C3.Text,
                p1 = P1.Text,
                p2 = P2.Text,   
                orden = Orden.Text,
                acomodo = Convert.ToInt16(Acomodo.Text),
                nivel = Convert.ToInt16(ddlNivelGd.SelectedItem.Value),
                estado = true
            };
            Fraselts.Add(frase);
            var objfrase = new FrasesData().GuardarFrasesSilabitos(Fraselts);

            if (objfrase.Code != 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", objfrase.Message, true);
            else
            {
                llenarTabla(Convert.ToInt16(ddlNivel.SelectedItem.Value));
                BorrarFormulario();
            }
        }

        protected void BorrarFrase_Click(object sender, EventArgs e)
        {
            var objfrase = new FrasesData().BorrarFrase(int.Parse(IdFraseBorrar.Value),2);

            if (objfrase.Code != 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", objfrase.Message, true);
            else
                llenarTabla(Convert.ToInt16(ddlNivel.SelectedItem.Value));
        }

        protected void llenarTabla(int IdNivel)
        {
            string table = string.Empty;

            var datostablaFrase = new FrasesData().ObtenerFrasesSilabitos(IdNivel);

            if (datostablaFrase.Code == 0)
            {
                foreach (var a in datostablaFrase.Result)
                {
                    table += @" <tr>"
                                  + "<td>" + a.Id + "</td>"
                                  + "<td>" + a.c1 + "</td>"
                                  + "<td>" + a.c2 + "</td>"
                                  + "<td>" + a.c3 + "</td>"
                                  + "<td>" + a.p1 + "</td>"
                                  + "<td>" + a.p2 + "</td>"
                                  + "<td>" + a.orden + "</td>"
                                  + "<td>" + a.acomodo + "</td>"
                                  + "<td>"
                                     + "<button type='button' id='btnEditarFrase' class='btn btn-success csBtnEditarFrase' data-toggle='modal' data-target='#addFrase' data-id='" + a.Id + "' data-c1='" + a.c1 + "' data-c2='" + a.c2 + "' data-c3='" + a.c3 + "' data-p1='" + a.p1 + "' data-p2='" + a.p2 + "' data-orden='" + a.orden + "' data-acomodo='" + a.acomodo + "'><i class='fa fa-pencil'></i></button>"
                                     + "<button type='button' id='btnBorrarFrase' class='btn btn-danger csBtnBorrarFrase' data-toggle='modal' data-target='#borrarFrase' data-id='" + a.Id + "' data-tipo='1' ><i class='fa fa-trash-o'></i></button>"
                                  + "</td>"
                              + " </tr>";
                }
                ltFrasesSilabitos.Text = table;
            }
        }

        protected void BorrarFormulario()
        {
            IdFrase.Value = "0";
            C1.Text = "";
            C2.Text = "";
            C3.Text = "";
            P1.Text = "";
            P2.Text = "";
            Orden.Text = "";
            Acomodo.Text = "";
        }

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarTabla(Convert.ToInt16(ddlNivel.SelectedItem.Value));
        }
    }
}