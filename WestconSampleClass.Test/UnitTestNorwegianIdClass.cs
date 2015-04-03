using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WestconSampleClass;

namespace WestconSampleClass.Test
{
    [TestClass]
    public class UnitTestNorwegianIdClass
    {
        [TestMethod]
        public void TestNorwegianClass()
        {
            NorwegianId idObj = new NorwegianId("12345678901");
            string idNumber = "12345678901";
            Assert.AreEqual(idNumber, idObj.IdNumber);
        }
    }
}
