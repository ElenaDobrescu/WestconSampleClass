using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestconSampleClass;

namespace WestconSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var idObjList = new NorwegianIds();

            var idObj = new NorwegianId("12345678912");
            if (!(idObj.IdNumber == null))
                idObjList.NorwegianIdsCollection.Add(idObj);

            idObj = new NorwegianId("12345678901");
            if (!(idObj.IdNumber == null))
                idObjList.NorwegianIdsCollection.Add(idObj);

            idObj = new NorwegianId("34567789021");
            if (!(idObj.IdNumber == null))
                idObjList.NorwegianIdsCollection.Add(idObj);

            //if (!(idObj.IdNumber == null))
            //    Console.WriteLine("IdNumber:{0}, type:{1}, gender:{2}, birthdate:{3}", idObj.IdNumber, idObj.Type, idObj.Gender, idObj.BirthDate);

            Console.ReadLine();
        }
    }
}