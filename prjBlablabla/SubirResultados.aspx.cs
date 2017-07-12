using prjBlablabla.Datos;
using prjBlablabla.DTO;
using prjBlablabla.XML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace prjBlablabla
{
    public partial class SubirResultados : System.Web.UI.Page
    {
        int idEscuela;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillEscuelasDropDown();
        }

        protected void cargarResultado_Click(object sender, EventArgs e)
        {
            lblError.Text = String.Empty;

            if (fileUploader1.HasFiles)
            {
                if (fileUploader1.PostedFiles.Count <= 10)
                    if(validateAllXML(fileUploader1.PostedFiles.ToList()))
                        GuardarArchivo(fileUploader1.PostedFiles.ToList());
                    else
                        MensajeError("Algun(os) archivo(s) seleccionado(s) no cumplen con el formato XML.");
                else
                    MensajeError("El máximo de archivos por subida es de 10.");
            }
            else
                MensajeError("Seleccione un archivo del disco duro.");
        }

        private bool validateAllXML(List<HttpPostedFile> list)
        {
            var succes = true;
            foreach (HttpPostedFile file in list)
            {
                if (!file.FileName.EndsWith("xml"))
                {
                    succes = false;
                    break;
                }
            }

            return succes;
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

        private void MensajeError(string v)
        {
            lblError.Text = "Error: " + v;
        }

        private void GuardarArchivo(List<HttpPostedFile> files)
        {


            foreach (HttpPostedFile file in files)
            {
                try
                {
                    // Se carga la ruta física de la carpeta temp del sitio
                    string ruta = Server.MapPath("~/tempXML");

                    // Si el directorio no existe, crearlo
                    if (!Directory.Exists(ruta))
                        Directory.CreateDirectory(ruta);

                    string archivo = String.Format("{0}\\{1}", ruta, file.FileName);

                    // Verificar que el archivo no exista
                    if (File.Exists(archivo))
                        File.Delete(archivo);

                    file.SaveAs(archivo);
                    GuardarDatosXML(archivo);
                }
                catch (Exception ex)
                {
                    MensajeError("Al borrar archivo StackTrace: " + ex.Message + " " + (ex.InnerException == null ? "" : ex.InnerException.Message));
                }
            }

        }


        private void GuardarDatosXML(string path)
        {
            var cont = 1;
            try
            {
                var resultadosLst = new List<ResultadoDTO>();
                Estadistica result;

                XmlSerializer serializer = new XmlSerializer(typeof(Estadistica));
                using (TextReader reader = new StringReader(File.ReadAllText(path)))
                {
                   result = (Estadistica)serializer.Deserialize(reader);
                }

                foreach (Eventos evnt in result.Eventos)
                {
                    foreach(Ensayo ensy in evnt.Ensayos.EnsayosList)
                    {
                        var res = new ResultadoDTO()
                        {
                            IdEscuela = int.Parse(ddListEscuelas.SelectedItem.Value),
                            NLista = evnt.Alumno.NLista,
                            Grado = evnt.Alumno.Grado,
                            Grupo = evnt.Alumno.Grupo,
                            IdJuego = ensy.Juego,
                            Nivel = ensy.Nivel,
                            Consecutivo = ensy.Consecutivo,
                            Resultado = ensy.Correcto,
                        };
                        

                        resultadosLst.Add(res);
                    }
                }


                File.Delete(path);

                var gFrases = new ResultadosData().GuardarResultado(resultadosLst);
                if (gFrases.Code != 0)
                    MensajeError("Al guardar los resultados, Detalle: " + gFrases.Message);
                else
                    lblError.Text = "Archivos cargados con éxito.";


            }
            catch (Exception ex)
            {
                //Se borra el archivo  
                //app.Workbooks.Close();
                System.IO.File.Delete(path);

                MensajeError("Al leer archivo en la linea: " + cont + " Detalle: " + ex.Message + " " + (ex.InnerException == null ? "" : ex.InnerException.Message));
            }


        }

        protected void ddListEscuelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;

            // Save the selected employee's name, because we will remove
            // the employee's name from the list.
            int val = int.Parse(ddl.SelectedItem.Value);

        }
    }
}