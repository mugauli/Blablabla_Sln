using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBlablabla.Common.Entities
{
    public static class EntPeriodoResult
    {
        /// <summary>
        /// Obtiene los periodos quincenales entre las fechas recibidas.
        /// </summary>
        /// <param name="fechaIni">Rango Inicial de fechas</param>
        /// <param name="fechaFin">Rango Final de fechas</param>
        /// <returns></returns>
        public static List<string> GetPeriodos(string fechaIni, string fechaFin, out List<string> filterQuery)
        {
            var periodosLst = new List<string>();
            var filters = new List<string>();
            var dateStart = Convert.ToDateTime(fechaIni);
            var dateEnd = Convert.ToDateTime(fechaFin);

            var ready = false;

            var monthStart = dateStart.Month;
            var monthEnd = dateEnd.Month;

            var yearStart = dateStart.Year;
            var yearEnd = dateEnd.Year;

            var dayIni = dateStart.Day;
            var dayEnd = dateEnd.Day;

            var strI = "";
            var strF = "";

            while (ready == false)
            {
                if (monthStart == monthEnd)
                {//mismo mes
                    if (yearStart == yearEnd)//mismo año
                    {
                        if ((dayIni <= 15 && dayEnd <= 15))
                        {
                            periodosLst.Add("1/" + monthStart);

                            strI = dayIni + "/" + monthStart + "/" + yearStart;
                            strF = dayEnd + "/" + monthEnd + "/" + yearEnd;
                            filters.Add(strI + " | " + strF);
                        }
                        else if ((dayIni > 15 && dayEnd > 15))
                        {
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
                else
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

            filterQuery = filters;
            return periodosLst;
        }
    }
}
