using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace prjBlablabla.Util
{
    public class FileUtil
    {
        public static object syncObj = new object();
        public static void WriteInLogFile(string linetoWrite)
        {
            try
            {
                lock (syncObj)
                {
                    //string fechaLog = "(" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ")"; //fecha en que se escribio la incidencia
                    //string logFilePath = ConfigurationManager.AppSettings["localLogPath"]; //ruta obtenida desde el app config
                    
                    //string logPath = logFilePath.Substring(0, logFilePath.LastIndexOf(@"\"));

                    //if (!System.IO.Directory.Exists(logPath))
                    //    System.IO.Directory.CreateDirectory(logPath);

                    //CreateOrWriteFile(logFilePath, fechaLog + "-" + linetoWrite);
                }
            }
            catch
            {
                throw;
            }
        }

        
        private static void CreateOrWriteFile(string FileName, string text)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(FileName, true))
            {
                file.WriteLine(text);
            }
        }
    }
}