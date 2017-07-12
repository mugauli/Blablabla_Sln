using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml.Serialization;
using prjBlablabla.XML;

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


    }
}
