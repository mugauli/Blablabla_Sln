using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;
using prjBlablabla.DTO;
using prjBlablabla.Datos;
using LinqToExcel;
using NPOI.XSSF.UserModel;
using System.Data;
using NPOI.SS.UserModel;

namespace prjBlablabla
{
    public partial class ImportarArchivo : System.Web.UI.Page
    {
        static XSSFWorkbook hssfworkbook;
        static DataSet dataSet1 = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Se agrega la propiedad para evitar recibir basura.
            levelId.Attributes.Add("readonly", "readonly");
            gameId.Attributes.Add("readonly", "readonly");
        }

        protected void cargarImagen_Click(object sender, EventArgs e)
        {
            lblError.Text = String.Empty;

            if (fileUploader1.HasFile)
            {
                //Verificar el archivo a guardar
                if (rbFrases.Checked)
                {
                    //metodo propio guardar archivo
                    GuardarArchivo(fileUploader1.PostedFile);
                }
                else
                {
                    //metodo propio guardar archivo
                    GuardarArchivoSilabitos(fileUploader1.PostedFile);
                }
            }
            else
                MensajeError("Seleccione un archivo del disco duro.");


        }

        private void GuardarArchivo(HttpPostedFile file)
        {
            if (file.FileName.EndsWith("xls") || file.FileName.EndsWith("xlsx"))
            {
                string archivo = string.Empty;
                try
                {
                    // Se carga la ruta física de la carpeta temp del sitio
                    string ruta = Server.MapPath("/tempExcel2");

                    // Si el directorio no existe, crearlo
                    if (!Directory.Exists(ruta))
                        Directory.CreateDirectory(ruta);

                    archivo = String.Format("{0}\\{1}", ruta, DateTime.Now.ToString("ddMMyyyyhhmmss") + file.FileName);

                    // Verificar que el archivo no exista
                    if (File.Exists(archivo))
                        File.Delete(archivo);

                    file.SaveAs(archivo);
                    GuardarDatosExcel(archivo);

                }
                catch (Exception ex)
                {
                    MensajeError("Al borrar archivo: " + archivo + " StackTrace: " + ex.Message + " " + (ex.InnerException == null ? "" : ex.InnerException.Message));
                }
            }
            else
            {
                MensajeError("Formato de archivo inválido.");
            }

        }

        private void GuardarArchivoSilabitos(HttpPostedFile file)
        {
            if (file.FileName.EndsWith("xls") || file.FileName.EndsWith("xlsx"))
            {
                string archivo = string.Empty;
                try
                {
                    // Se carga la ruta física de la carpeta temp del sitio
                    string ruta = Server.MapPath("/tempExcelSilabitos");

                    // Si el directorio no existe, crearlo
                    if (!Directory.Exists(ruta))
                        Directory.CreateDirectory(ruta);

                    archivo = String.Format("{0}\\{1}", ruta, file.FileName);

                    // Verificar que el archivo no exista
                    if (File.Exists(archivo))
                        File.Delete(archivo);

                    file.SaveAs(archivo);

                    GuardarDatosExcelSilabitos(archivo);
                }
                catch (Exception ex)
                {
                    MensajeError("Al borrar archivo: " + archivo + " StackTrace: " + ex.Message + " " + (ex.InnerException == null ? "" : ex.InnerException.Message));
                }


            }
            else
            {
                MensajeError("Formato de imagen inválido.");
            }

        }

        private void GuardarDatosExcel(string path)
        {
            var cont = 1;
            //Leemos el archivo de excel

            try
            {


                var fracesLts = new List<FraseTorreDTO>();


                using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new XSSFWorkbook(file);

                    xlsxToDT();

                    var table = dataSet1.Tables[0];

                    foreach (DataRow row in table.Rows)
                    {
                        var objFrase = new FraseTorreDTO();


                        objFrase.Id = int.Parse(row[0].ToString());
                        objFrase.enun1 = row[1].ToString();
                        objFrase.enun2 = row[2].ToString();
                        objFrase.correcta = short.Parse(row[3].ToString());
                        objFrase.opcion1 = row[4].ToString();
                        objFrase.opcion2 = row[5].ToString();
                        objFrase.opcion3 = row[6].ToString();
                        objFrase.nivel = findID(levelId.Text);
                        //objFrase.juego = findID(gameId.Text);
                        fracesLts.Add(objFrase);
                        cont++;

                    }


                }


                File.Delete(path);

                var gFrases = new FrasesData().GuardarFrasesTorre(fracesLts);

                if (gFrases.Code != 0)
                    MensajeError("Al guardar frases, Detalle: " + gFrases.Message);
                else
                    lblError.Text = "Archivo cargado con éxito.";


            }
            catch (Exception ex)
            {
                //Se borra el archivo  
                //app.Workbooks.Close();
                System.IO.File.Delete(path);

                MensajeError("Al leer archivo en la linea: " + cont + " Detalle: " + ex.Message + " " + (ex.InnerException == null ? "" : ex.InnerException.Message));
            }


        }

        private void GuardarDatosExcelSilabitos(string path)
        {

            //Leemos el archivo de excel
            Excel.Application app = new Excel.Application();
            Excel.Workbook workBook = app.Workbooks.Open(path);
            Excel.Worksheet workSheet = workBook.ActiveSheet;
            Excel.Range range = workSheet.UsedRange;

            var fracesLts = new List<FraseSilabitosDTO>();
            var cont = 1;
            try
            {
                for (int i = 2; i <= range.Rows.Count; i++)
                {
                    var objFrase = new FraseSilabitosDTO();


                    objFrase.Id = int.Parse(((Excel.Range)range.Cells[i, 1]).Text);
                    objFrase.c1 = ((Excel.Range)range.Cells[i, 2]).Text;
                    objFrase.c2 = ((Excel.Range)range.Cells[i, 3]).Text;
                    objFrase.c3 = ((Excel.Range)range.Cells[i, 4]).Text;
                    objFrase.p1 = ((Excel.Range)range.Cells[i, 5]).Text;
                    objFrase.p1 = ((Excel.Range)range.Cells[i, 6]).Text;
                    objFrase.orden = ((Excel.Range)range.Cells[i, 7]).Text;
                    objFrase.acomodo = short.Parse(((Excel.Range)range.Cells[i, 8]).Text);
                    objFrase.nivel = int.Parse(((Excel.Range)range.Cells[i, 9]).Text);
                    fracesLts.Add(objFrase);
                    cont++;

                }
                //Se borra el archivo                    
                app.Workbooks.Close();
                System.IO.File.Delete(path);

                var gFrases = new FrasesData().GuardarFrasesSilabitos(fracesLts);

                if (gFrases.Code != 0)
                    MensajeError("Al guardar frases de Silabitos, Detalle: " + gFrases.Message);
                else
                    lblError.Text = "Archivo cargado con éxito.";


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

        #region NPOI

        static void xlsxToDT()
        {
            DataTable dt = new DataTable();
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            IRow headerRow = sheet.GetRow(0);
            IEnumerator rows = sheet.GetRowEnumerator();

            int colCount = headerRow.LastCellNum;
            int rowCount = sheet.LastRowNum;

            for (int c = 0; c < colCount; c++)
            {

                dt.Columns.Add(headerRow.GetCell(c).ToString());
            }

            bool skipReadingHeaderRow = rows.MoveNext();
            while (rows.MoveNext())
            {
                IRow row = (XSSFRow)rows.Current;
                DataRow dr = dt.NewRow();

                for (int i = 0; i < colCount; i++)
                {
                    ICell cell = row.GetCell(i);

                    if (cell != null)
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }

            hssfworkbook = null;
            sheet = null;
            dataSet1.Tables.Add(dt);
        }

        /// <summary>
        /// Busca el Numero del Juego o Nivel sore la cadena de texto recibida ej: "Juego 3"  -> 3 
        /// </summary>
        /// <param name="fullText">Texto recibido, tomado del control</param>
        /// <returns>Nivel / Juego</returns>
        static int findID(string fullText)
        {
            string searchID = fullText.Substring(5).Trim();
            return Convert.ToInt32(searchID);

        }
        #endregion
    }
}