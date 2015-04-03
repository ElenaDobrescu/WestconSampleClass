using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WestconSampleClass
{
    class InvalidIdNumberExeption : Exception
    {
        public InvalidIdNumberExeption() { }
        public InvalidIdNumberExeption(string message):base(message) { }
        public InvalidIdNumberExeption(string message, params object[] args):base(string.Format(message, args)) { }
    }
}
