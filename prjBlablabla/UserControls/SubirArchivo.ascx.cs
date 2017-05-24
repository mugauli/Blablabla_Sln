using prjBlablabla.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;

namespace prjBlablabla.UserControls
{
    public partial class SubirArchivo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = String.Empty;
        }


        public string SubirArchivo2(HttpPostedFileBase ArchivoExcel)
        {
            try
            {
                if (ArchivoExcel == null || ArchivoExcel.ContentLength == 0)
                {
                    //Avisar que no hay un archivo

                }

                if (ArchivoExcel.FileName.EndsWith("xls") || ArchivoExcel.FileName.EndsWith("xlsx"))
                {

                    var path = Server.MapPath("~/Content/AtencionExcel.xlsx");
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);

                    ArchivoExcel.SaveAs(path);
                    //Leemos el archivo de excel
                    Excel.Application app = new Excel.Application();
                    Excel.Workbook workBook = app.Workbooks.Open(path);
                    Excel.Worksheet workSheet = workBook.ActiveSheet;
                    Excel.Range range = workSheet.UsedRange;




                }
                else
                {

                }


                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message + (ex.InnerException == null ? "" : " Innerexception: " + ex.InnerException.Message) + " StackTrace: " + (ex.StackTrace);

            }
        }

        protected void cargarImagen_Click(object sender, EventArgs e)
        {
            lblError.Text = String.Empty;

            if (fileUploader1.HasFile)
                //metodo propio guardar archivo
                GuardarArchivo(fileUploader1.PostedFile);
            else
                MensajeError("Seleccione un archivo del disco duro.");

        }

        private void GuardarArchivo(HttpPostedFile file)
        {
            if (file.FileName.EndsWith("xls") || file.FileName.EndsWith("xlsx"))
            {
                try
                {
                    // Se carga la ruta física de la carpeta temp del sitio
                    string ruta = Server.MapPath("~/temp");

                    // Si el directorio no existe, crearlo
                    if (!Directory.Exists(ruta))
                        Directory.CreateDirectory(ruta);

                    string archivo = String.Format("{0}\\{1}", ruta, file.FileName);

                    // Verificar que el archivo no exista
                    if (File.Exists(archivo))
                        File.Delete(archivo);

                    file.SaveAs(archivo);

                    GuardarDatosExcel(archivo);
                }
                catch (Exception ex)
                {
                    MensajeError("Al borrar archivo StackTrace: " + ex.Message + " " + (ex.InnerException == null ? "" : ex.InnerException.Message));
                }


            }
            else
            {
                MensajeError("Formato de imagen inválido.");
            }

        }

        private void GuardarDatosExcel(string path)
        {

            //Leemos el archivo de excel
            Excel.Application app = new Excel.Application();
            Excel.Workbook workBook = app.Workbooks.Open(path);
            Excel.Worksheet workSheet = workBook.ActiveSheet;
            Excel.Range range = workSheet.UsedRange;

            var fraces = new List<fraseDTO>();
            var cont = 1;
            try
            {
                for (int i = 2; i <= range.Rows.Count; i++)
                {
                    var objFrase = new fraseDTO();


                    objFrase.Id = int.Parse(((Excel.Range)range.Cells[i, 1]).Text);
                    objFrase.enun1 = ((Excel.Range)range.Cells[i, 2]).Text;
                    objFrase.enun2 = ((Excel.Range)range.Cells[i, 3]).Text;
                    objFrase.correcta = short.Parse(((Excel.Range)range.Cells[i, 4]).Text);
                    objFrase.opcion1 = ((Excel.Range)range.Cells[i, 5]).Text;
                    objFrase.opcion2 = ((Excel.Range)range.Cells[i, 6]).Text;
                    objFrase.opcion3 = ((Excel.Range)range.Cells[i, 7]).Text;

                    fraces.Add(objFrase);
                    cont++;

                }
                //Se borra el archivo                    
                app.Workbooks.Close();
                System.IO.File.Delete(path);

            }
            catch (Exception ex)
            {
                //Se borra el archivo  
                app.Workbooks.Close();
                System.IO.File.Delete(path);

                MensajeError("Al leer archivo en la linea: " + cont + " Detalle: " + ex.Message + " " + (ex.InnerException == null ? "" : ex.InnerException.Message));
            }


        }

        private void MensajeError(string v)
        {
            lblError.Text = "Error: " + v;
        }
    }
}