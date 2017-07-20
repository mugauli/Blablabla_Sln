using prjBlablabla.Datos;
using prjBlablabla.DTO;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace prjBlablabla
{
    public partial class DatosBosque : System.Web.UI.Page
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

            var frase = new FrasesBosqueDTO
            {
                Id = int.Parse(IdFrase.Value),
                Frase = Frase.Text,
                Opcion1 = Opcion1.Text,
                Opcion2 = Opcion2.Text,
                Correcta = correcta.Text == "1",
                Nivel = Convert.ToByte(ddlNivelGd.SelectedItem.Value),
                Estado = true
            };

            var objfrase = new FrasesData().GuardarFrasesBosque(new List<FrasesBosqueDTO> { frase });

            if (objfrase.Code != 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", objfrase.Message, true);
            else
            {
                llenarTabla(Convert.ToInt16(ddlNivelGd.SelectedItem.Value));
                BorrarFormulario();
            }
        }

        protected void BorrarFrase_Click(object sender, EventArgs e)
        {
            var objfrase = new FrasesData().BorrarFrase(int.Parse(IdFraseBorrar.Value), int.Parse(TipoFraseBorrar.Value));

            if (objfrase.Code != 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", objfrase.Message, true);
            else
                llenarTabla(Convert.ToInt16(ddlNivelGd.SelectedItem.Value));
        }

        protected void llenarTabla(int IdNivel)
        {
            string table = string.Empty;

            var datostablaFrase = new FrasesData().ObtenerFrasesBosque(IdNivel);

            if (datostablaFrase.Code == 0)
            {
                foreach (var a in datostablaFrase.Result)
                {
                    table += @" <tr>"
                                  + "<td>" + a.Id + "</td>"
                                  + "<td>" + a.Frase + "</td>"
                                  + "<td>" + a.Opcion1 + "</td>"
                                  + "<td>" + a.Opcion2 + "</td>"
                                  + "<td>" + (a.Correcta.Value ? "2" : "1") + "</td>"
                                  + "<td>"
                                     + "<button type='button' id='btnEditarFrase' class='btn btn-success csBtnEditarFrase' data-toggle='modal' data-target='#addFrase' data-id='" + a.Id + "' data-enun1='" + a.Frase + "' data-enun2='" + a.Opcion1 + "' data-correcta='" + a.Opcion2 + "' data-opcion1='" + a.Correcta + "'><i class='fa fa-pencil'></i></button>"
                                     + "<button type='button' id='btnBorrarFrase' class='btn btn-danger csBtnBorrarFrase' data-toggle='modal' data-target='#borrarFrase' data-id='" + a.Id + "' data-tipo='1' ><i class='fa fa-trash-o'></i></button>"
                                  + "</td>"
                              + " </tr>";
                }
                ltFrasesBosque.Text = table;
            }
        }

        protected void BorrarFormulario()
        {
            IdFrase.Value = "0";
            Frase.Text = "";
            Opcion1.Text = "";
            Opcion2.Text = "";
            correcta.Text = "";
            

        }
    }
}