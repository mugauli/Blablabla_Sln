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
    public partial class DatosJuego : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                llenarTabla();
            }

        }

        protected void GuardarFrase_Click(object sender, EventArgs e)
        {
            var frase = new fraseDTO
            {
                Id = int.Parse(IdFrase.Value),
                enun1 = enun1.Text,
                enun2 = enun2.Text,
                correcta = short.Parse(correcta.Text),
                opcion1 = opcion1.Text,
                opcion2 = opcion2.Text,
                opcion3 = opcion3.Text
            };

            var objfrase = new FrasesData().GuardarFrase(frase);

            if (objfrase.Code != 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", objfrase.Message, true);
            else
            {
                llenarTabla();
                BorrarFormulario();
            }
        }

        protected void BorrarFrase_Click(object sender, EventArgs e)
        {
            var objfrase = new FrasesData().BorrarFrase(int.Parse(IdFraseBorrar.Value), int.Parse(TipoFraseBorrar.Value));

            if (objfrase.Code != 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", objfrase.Message, true);
            else
                llenarTabla();
        }

        protected void llenarTabla()
        {
            string table = string.Empty;

            var datostablaFrase = new FrasesData().ObtenerFrases();

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
                                     + "<button type='button' id='btnEditarFrase' class='btn btn-success csBtnEditarFrase' data-toggle='modal' data-target='#addFrase' data-id='" + a.Id + "' data-enun1='"+a.enun1+"' data-enun2='"+a.enun2+"' data-correcta='"+a.correcta+"' data-opcion1='"+a.opcion1+"' data-opcion2='"+a.opcion2+"' data-opcion3='"+a.opcion3+"'><i class='fa fa-pencil'></i></button>"
                                     + "<button type='button' id='btnBorrarFrase' class='btn btn-danger csBtnBorrarFrase' data-toggle='modal' data-target='#borrarFrase' data-id='" + a.Id + "' data-tipo='1' ><i class='fa fa-trash-o'></i></button>"
                                  + "</td>"
                              + " </tr>";
                }
                ltlTableFrases.Text = table;
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

    }
}