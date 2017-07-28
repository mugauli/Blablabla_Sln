using prjBlablabla.Datos;
using prjBlablabla.DTO;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace prjBlablabla
{
    public partial class DatosCastillo : System.Web.UI.Page
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
            var frase = new FraseCastilloDTO
            {
                Id = int.Parse(IdFrase.Value),
                Enunciado1 = enun1.Text,
                Enunciado2 = enun2.Text,
                Correcta = correcta.Text == "1",
                Nivel = Convert.ToByte(ddlNivelGd.SelectedItem.Value),
                Estado = true
            };

            var objfrase = new FrasesData().GuardarFrasesCastillo(new List<FraseCastilloDTO> { frase });

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
            var objfrase = new FrasesData().BorrarFrase(int.Parse(IdFraseBorrar.Value),4);

            if (objfrase.Code != 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", objfrase.Message, true);
            else
                llenarTabla(Convert.ToInt16(ddlNivelGd.SelectedItem.Value));
        }

        protected void llenarTabla(int IdNivel)
        {
            string table = string.Empty;

            var datostablaFrase = new FrasesData().ObtenerFrasesCastillo(IdNivel);

            if (datostablaFrase.Code == 0)
            {
                foreach (var a in datostablaFrase.Result)
                {
                    table += @" <tr>"
                                  + "<td>" + a.Id + "</td>"
                                  + "<td>" + a.Enunciado1 + "</td>"
                                  + "<td>" + a.Enunciado2 + "</td>"
                                  + "<td>" + (a.Correcta ? "2" : "1") + "</td>"
                                  + "<td>"
                                     + "<button type='button' id='btnEditarFrase' class='btn btn-success csBtnEditarFrase' data-toggle='modal' data-target='#addFrase' data-id='" + a.Id + "' data-enun1='" + a.Enunciado1 + "' data-enun2='" + a.Enunciado2 + "' data-correcta='" + a.Correcta + "'><i class='fa fa-pencil'></i></button>"
                                     + "<button type='button' id='btnBorrarFrase' class='btn btn-danger csBtnBorrarFrase' data-toggle='modal' data-target='#borrarFrase' data-id='" + a.Id + "' data-tipo='1' ><i class='fa fa-trash-o'></i></button>"
                                  + "</td>"
                              + " </tr>";
                }
                ltFasesCastillosTable.Text = table;
            }
        }

        protected void BorrarFormulario()
        {
            IdFrase.Value = "0";
            enun1.Text = "";
            enun2.Text = "";
            correcta.Text = "";
        }

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarTabla(Convert.ToInt16(ddlNivel.SelectedItem.Value));
        }
    }
}