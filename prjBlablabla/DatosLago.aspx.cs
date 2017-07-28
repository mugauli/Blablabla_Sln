using prjBlablabla.Datos;
using prjBlablabla.DTO;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace prjBlablabla
{
    public partial class DatosLago : System.Web.UI.Page
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
            var frase = new FraseLagoDTO
            {
                Id = int.Parse(IdFrase.Value),
                Enunciado = Enunciado.Text,
                Eleccion = Eleccion.Checked,               
                Nivel = Convert.ToByte(ddlNivelGd.SelectedItem.Value),
                Estado = true
            };

            var objfrase = new FrasesData().GuardarFrasesLago(new List<FraseLagoDTO> { frase });

            if (objfrase.Code != 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", objfrase.Message, true);
            else
            {
                llenarTabla(Convert.ToByte(ddlNivel.SelectedItem.Value));
                BorrarFormulario();
            }
        }

        protected void BorrarFrase_Click(object sender, EventArgs e)
        {
            var objfrase = new FrasesData().BorrarFrase(int.Parse(IdFraseBorrar.Value), int.Parse(TipoFraseBorrar.Value));

            if (objfrase.Code != 0)
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", objfrase.Message, true);
            else
                llenarTabla(Convert.ToByte(ddlNivel.SelectedItem.Value));
        }

        protected void llenarTabla(int IdNivel)
        {
            string table = string.Empty;

            var datostablaFrase = new FrasesData().ObtenerFrasesLago(IdNivel);

            if (datostablaFrase.Code == 0)
            {
                foreach (var a in datostablaFrase.Result)
                {
                    table += @" <tr>"
                                  + "<td>" + a.Id + "</td>"
                                  + "<td>" + a.Enunciado + "</td>"
                                  + "<td>" + (a.Eleccion ? "SI" : "NO") + "</td>"
                                  + "<td>"
                                     + "<button type='button' id='btnEditarFrase' class='btn btn-success csBtnEditarFrase' data-toggle='modal' data-target='#addFrase' data-id='" + a.Id + "' data-enun1='" + a.Enunciado + "' data-enun2='" + a.Eleccion + "'><i class='fa fa-pencil'></i></button>"
                                     + "<button type='button' id='btnBorrarFrase' class='btn btn-danger csBtnBorrarFrase' data-toggle='modal' data-target='#borrarFrase' data-id='" + a.Id + "' data-tipo='1' ><i class='fa fa-trash-o'></i></button>"
                                  + "</td>"
                              + " </tr>";
                }
                ltFrasesLagoTable.Text = table;
            }
        }

        protected void BorrarFormulario()
        {
            IdFrase.Value = "0";
            Enunciado.Text = "";
            Eleccion.Checked = false;
        }

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarTabla(Convert.ToInt16(ddlNivel.SelectedItem.Value));
        }
    }
}