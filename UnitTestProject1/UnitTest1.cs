using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml.Serialization;
using prjBlablabla.XML;
using System.Collections.Generic;
using prjBlablabla.DTO;
using prjBlablabla.Datos;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void findLevelID()
        {
            string fullText = "Nivel 3";
            int endIndex = fullText.Length - 1;
            string levelID = fullText.Substring(5).Trim();
           Console.WriteLine( Convert.ToInt32(levelID));
        }

        [TestMethod]
        public void xmlParese()
        {
            string testData = @"<Estadistica>
                                  <Eventos>
                                    <Fecha>16012017</Fecha>
                                    <Alumno>
                                      <Nombre>Nombre 1</Nombre>
                                      <Grado>2</Grado>
                                      <Grupo>A</Grupo>
                                      <Sexo>M</Sexo>
                                      <Edad>8</Edad>
                                      <NLista>28</NLista>
                                    </Alumno>
                                    <Ensayos>
                                      <Ensayo>
                                        <Juego>4</Juego>
                                        <Nivel>2</Nivel>
                                        <Consecutivo>1</Consecutivo>
                                        <Correcto>1</Correcto>
                                        <Tiempo>35</Tiempo>
                                        <Puntos>100</Puntos>
                                      </Ensayo>
                                      <Ensayo>
                                        <Juego>4</Juego>
                                        <Nivel>2</Nivel>
                                        <Consecutivo>1</Consecutivo>
                                        <Correcto>1</Correcto>
                                        <Tiempo>35</Tiempo>
                                        <Puntos>100</Puntos>
                                      </Ensayo>
                                      <Ensayo>
                                        <Juego>4</Juego>
                                        <Nivel>2</Nivel>
                                        <Consecutivo>1</Consecutivo>
                                        <Correcto>1</Correcto>
                                        <Tiempo>35</Tiempo>
                                        <Puntos>100</Puntos>
                                      </Ensayo>
                                    </Ensayos>
                                  </Eventos>
                                     <Eventos>
                                        <Fecha>17012017</Fecha>
                                        <Alumno>
                                          <Nombre>Nombre 1</Nombre>
                                          <Grado>2</Grado>
                                          <Grupo>A</Grupo>
                                          <Sexo>M</Sexo>
                                          <Edad>8</Edad>
                                          <NLista>28</NLista>
                                        </Alumno>
                                        <Ensayos>
                                          <Ensayo>
                                            <Juego>4</Juego>
                                            <Nivel>2</Nivel>
                                            <Consecutivo>1</Consecutivo>
                                            <Correcto>1</Correcto>
                                            <Tiempo>35</Tiempo>
                                            <Puntos>100</Puntos>
                                          </Ensayo>
                                          <Ensayo>
                                            <Juego>4</Juego>
                                            <Nivel>2</Nivel>
                                            <Consecutivo>1</Consecutivo>
                                            <Correcto>1</Correcto>
                                            <Tiempo>35</Tiempo>
                                            <Puntos>100</Puntos>
                                          </Ensayo>
                                          <Ensayo>
                                            <Juego>4</Juego>
                                            <Nivel>2</Nivel>
                                            <Consecutivo>1</Consecutivo>
                                            <Correcto>1</Correcto>
                                            <Tiempo>35</Tiempo>
                                            <Puntos>100</Puntos>
                                          </Ensayo>
                                        </Ensayos>
                                      </Eventos>
                                      <Eventos>
                                        <Fecha>18012017</Fecha>
                                        <Alumno>
                                          <Nombre>Nombre 1</Nombre>
                                          <Grado>2</Grado>
                                          <Grupo>A</Grupo>
                                          <Sexo>M</Sexo>
                                          <Edad>8</Edad>
                                          <NLista>28</NLista>
                                        </Alumno>
                                        <Ensayos>
                                          <Ensayo>
                                            <Juego>4</Juego>
                                            <Nivel>2</Nivel>
                                            <Consecutivo>1</Consecutivo>
                                            <Correcto>1</Correcto>
                                            <Tiempo>35</Tiempo>
                                            <Puntos>100</Puntos>
                                          </Ensayo>
                                          <Ensayo>
                                            <Juego>4</Juego>
                                            <Nivel>2</Nivel>
                                            <Consecutivo>1</Consecutivo>
                                            <Correcto>1</Correcto>
                                            <Tiempo>35</Tiempo>
                                            <Puntos>100</Puntos>
                                          </Ensayo>
                                          <Ensayo>
                                            <Juego>4</Juego>
                                            <Nivel>2</Nivel>
                                            <Consecutivo>1</Consecutivo>
                                            <Correcto>1</Correcto>
                                            <Tiempo>35</Tiempo>
                                            <Puntos>100</Puntos>
                                          </Ensayo>
                                        </Ensayos>
                                      </Eventos>
                                      <Eventos>
                                        <Fecha>19012017</Fecha>
                                        <Alumno>
                                          <Nombre>Nombre 1</Nombre>
                                          <Grado>2</Grado>
                                          <Grupo>A</Grupo>
                                          <Sexo>M</Sexo>
                                          <Edad>8</Edad>
                                          <NLista>28</NLista>
                                        </Alumno>
                                        <Ensayos>
                                          <Ensayo>
                                            <Juego>4</Juego>
                                            <Nivel>2</Nivel>
                                            <Consecutivo>1</Consecutivo>
                                            <Correcto>1</Correcto>
                                            <Tiempo>35</Tiempo>
                                            <Puntos>100</Puntos>
                                          </Ensayo>
                                          <Ensayo>
                                            <Juego>4</Juego>
                                            <Nivel>2</Nivel>
                                            <Consecutivo>1</Consecutivo>
                                            <Correcto>1</Correcto>
                                            <Tiempo>35</Tiempo>
                                            <Puntos>100</Puntos>
                                          </Ensayo>
                                          <Ensayo>
                                            <Juego>4</Juego>
                                            <Nivel>2</Nivel>
                                            <Consecutivo>1</Consecutivo>
                                            <Correcto>1</Correcto>
                                            <Tiempo>35</Tiempo>
                                            <Puntos>100</Puntos>
                                          </Ensayo>
                                        </Ensayos>
                                      </Eventos>
                                </Estadistica>";

            XmlSerializer serializer = new XmlSerializer(typeof(Estadistica));
            using (TextReader reader = new StringReader(testData))
            {
                Estadistica result = (Estadistica)serializer.Deserialize(reader);
                Console.WriteLine("Resultado->:" + result.Eventos[0].Ensayos.EnsayosList[0].Puntos);
            }

            //NLista,Grado,Grupo,IdEscuela,Juego,Nivel,Consecutivo,Correcto
        }

        [TestMethod]
        public void dateConvert()
        {
            try
            {
                string strDate = "16012017";
                string strDateC = strDate.Substring(0, 2) + "/" + strDate.Substring(2, 2) + "/" + strDate.Substring(4, 4);
                DateTime date = Convert.ToDateTime(strDateC);
                Console.WriteLine("fecha convertida {0} - {1}",strDateC, date.ToShortDateString());
            } catch (Exception ex) { 
                Console.WriteLine("Error al convertir:" + ex.Message);



            }
        }

        [TestMethod]
        public void months()
        {
            string fechaIni = "01/01/2017";
            string fechaFin = "15/01/2018";

            var dateStart = Convert.ToDateTime(fechaIni);
            var dateEnd = Convert.ToDateTime(fechaFin);

            //var dateSpan = DateTimeSpan.CompareDates(dateStart,dateEnd);
            //Console.WriteLine("Years: " + dateSpan.Years);
            //Console.WriteLine("Months: " + dateSpan.Months);
            var ready = false;

            var monthStart = dateStart.Month;
            var monthEnd = dateEnd.Month;

            var yearStart = dateStart.Year;
            var yearEnd = dateEnd.Year;

            var dayIni = dateStart.Day;
            var dayEnd = dateEnd.Day;

            var periodosLst = new List<string>();
            var filters = new List<string>();

            var strI = "";
            var strF = "";

            while (ready==false)
            {
               if(monthStart == monthEnd){//mismo mes
                    if (yearStart == yearEnd)//mismo año
                    {
                        if ((dayIni <= 15 && dayEnd <=15)){
                            periodosLst.Add("1/" + monthStart);

                            strI = dayIni + "/" + monthStart + "/" + yearStart;
                            strF = dayEnd + "/" + monthEnd + "/" + yearEnd;
                            filters.Add(strI + " | " + strF);
                        }
                        else if ((dayIni > 15 && dayEnd > 15)){
                            periodosLst.Add("2/" + monthStart);

                            strI = dayIni + "/" + monthStart + "/" + yearStart;
                            strF = dayEnd + "/" + monthEnd + "/" + yearEnd;
                            filters.Add(strI + " | " + strF);
                        }
                        else if ((dayIni <= 15 && dayEnd > 15))
                        {
                            periodosLst.Add("1/" + monthStart);
                            periodosLst.Add("2/" + monthStart);

                            strI = dayIni + "/" + monthStart + "/" + yearStart;
                            strF = 15 + "/" + monthEnd + "/" + yearEnd;
                            filters.Add(strI + " | " + strF);

                            strI = 16 + "/" + monthStart + "/" + yearStart;
                            strF = dayEnd + "/" + monthEnd + "/" + yearEnd;
                            filters.Add(strI + " | " + strF);
                        }
                        ready = true;
                    }
                    else//Año diferente
                    {
                        if (dayIni <= 15)
                        {
                            periodosLst.Add("1/" + monthStart);
                            periodosLst.Add("2/" + monthStart);

                            strI = 1 + "/" + monthStart + "/" + yearStart;
                            strF = 15 + "/" + monthStart + "/" + yearStart;
                            filters.Add(strI + " | " + strF);

                            strI = 16 + "/" + monthStart + "/" + yearStart;
                            strF = 31 + "/" + monthStart + "/" + yearStart;
                            filters.Add(strI + " | " + strF);
                        }
                        else
                        {
                            periodosLst.Add("2/" + monthStart);

                            strI = 16 + "/" + monthStart + "/" + yearStart;
                            strF = 31 + "/" + monthStart + "/" + yearStart;
                            filters.Add(strI + " | " + strF);
                        }

                        //aumento en el contador de meses y años
                        yearStart = monthStart == 12 ? yearStart += 1 : yearStart;
                        monthStart = monthStart == 12 ? 1 : monthStart += 1;
                    }
                    
                }
                else{
                        if (dayIni <= 15)
                        {
                            periodosLst.Add("1/" + monthStart);
                            periodosLst.Add("2/" + monthStart);

                            strI = 1 + "/" + monthStart + "/" + yearStart;
                            strF = 15 + "/" + monthStart + "/" + yearStart;
                            filters.Add(strI + " | " + strF);

                            strI = 16 + "/" + monthStart + "/" + yearStart;
                            strF = 31 + "/" + monthStart + "/" + yearStart;
                            filters.Add(strI + " | " + strF);
                    }
                        else
                        {
                            periodosLst.Add("2/" + monthStart);
                            strI = 16 + "/" + monthStart + "/" + yearStart;
                            strF = 31 + "/" + monthStart + "/" + yearStart;
                            filters.Add(strI + " | " + strF);
                    }
                        //aumento en el contador de meses y años
                        yearStart = monthStart == 12 ? yearStart+=1 : yearStart;
                        monthStart = monthStart == 12 ? 1 : monthStart+=1;
                }
            }

            foreach(string s in periodosLst)
            {
                Console.WriteLine("Periodo:"+s);
            }
            Console.WriteLine("---------------");
            foreach (string s in filters)
            {
                Console.WriteLine("Filtro Query:" + s);
            }
        }

        [TestMethod]
        public void spTest()
        {
            var response = new MethodResponseDTO<List<ResultadoPorNinoDTO>> { Code = 0 };
            var resultadosNino = new List<ResultadoPorNinoDTO>();
            using (var context = new BlablablaSitioEntities())
            {

                var res = context.sp_ResNinoBy_EscuelaJuegoNivelGradoGrupo(1, 4, 2, 2, "A", "16/1/2017", "31/1/2017").ToList();
                foreach (var r in res)
                {
                    resultadosNino.Add(new ResultadoPorNinoDTO()
                    {
                        Grado = 2,
                        Edad = (int)r.Edad,
                        Sexo = r.Sexo,
                        TotalEnsayos = (int)r.Total_de_Ensayos,
                        Aciertos_x100 = (double)r.porcentaje_aciertos,
                        Errores_x100 = (double)r.porcentaje_errores,
                        Teimpo_reaccion = (double)r.Tiempo
                    });
                }

            }
        }
    }

    
}
