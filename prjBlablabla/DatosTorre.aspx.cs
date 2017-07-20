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
    public partial class DatosTorre : System.Web.UI.Page
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
            var Fraselts = new List<FraseTorreDTO>();
            var frase = new FraseTorreDTO
            {
                Id = int.Parse(IdFrase.Value),
                enun1 = enun1.Text,
                enun2 = enun2.Text,
                correcta = short.Parse(correcta.Text),
                opcion1 = opcion1.Text,
                opcion2 = opcion2.Text,
                opcion3 = opcion3.Text,
                nivel = Convert.ToInt16(ddlNivelGd.SelectedItem.Value),
                estado = true
            };

            Fraselts.Add(frase);
            var objfrase = new FrasesData().GuardarFrasesTorre(Fraselts);

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
            var objfrase = new FrasesData().BorrarFrase(int.Parse(IdFraseBorrar.Value), 1);

            if (objfrase.Code != 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", objfrase.Message, true);
            else
                llenarTabla(Convert.ToInt16(ddlNivel.SelectedItem.Value));
        }

        protected void llenarTabla(int IdNivel)
        {
            string table = string.Empty;

            var datostablaFrase = new FrasesData().ObtenerFrasesTorre(IdNivel);

            if (datostablaFrase.Code == 0)
            {
                foreach (var a in datostablaFrase.Result)
                {
                    table += @" <tr>"
                                  + "<td>" + a.Id + "</td>"
                                  + "<td>" + a.enun1 + "</td>"
                                  + "<td>" + a.enun2 + "</td>"
                                  + "<td>" + a.correcta + "</td>"
                                  + "<td>" + a.opcion1 + "</td>"
                                  + "<td>" + a.opcion2 + "</td>"
                                  + "<td>" + a.opcion3 + "</td>"
                                  + "<td>"
                                     + "<button type='button' id='btnEditarFrase' class='btn btn-success csBtnEditarFrase' data-toggle='modal' data-target='#addFrase' data-id='" + a.Id + "' data-enun1='" + a.enun1 + "' data-enun2='" + a.enun2 + "' data-correcta='" + a.correcta + "' data-opcion1='" + a.opcion1 + "' data-opcion2='" + a.opcion2 + "' data-opcion3='" + a.opcion3 + "'><i class='fa fa-pencil'></i></button>"
                                     + "<button type='button' id='btnBorrarFrase' class='btn btn-danger csBtnBorrarFrase' data-toggle='modal' data-target='#borrarFrase' data-id='" + a.Id + "' data-tipo='1' ><i class='fa fa-trash-o'></i></button>"
                                  + "</td>"
                              + " </tr>";
                }
                ltfraseComunesTable.Text = table;
            }
        }

        protected void BorrarFormulario()
        {
            IdFrase.Value = "0";
            enun1.Text = "";
            enun2.Text = "";
            correcta.Text = "";
            opcion1.Text = "";
            opcion2.Text = "";
            opcion3.Text = "";
        }

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarTabla(Convert.ToInt16(ddlNivel.SelectedItem.Value));
        }
    }
}