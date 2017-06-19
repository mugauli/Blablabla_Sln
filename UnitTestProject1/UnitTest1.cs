using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
