using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestconSampleClass
{

    internal class NorwegianIds
    {
        internal List<NorwegianId> NorwegianIdsCollection = new List<NorwegianId>();
    }

    internal partial class NorwegianId
    {
        public NorwegianId(string idNumber)
        {
            IdNumber = idNumber;
            if (!string.IsNullOrWhiteSpace(IdNumber))
            {
                _birthDate = GetBirthDateFromIdNumber(IdNumber).ToString("dd.MM.yyyy");
                _type = GetTypeFromIdNumber(IdNumber);
                _gender = GetGenderFromIdNumber(IdNumber);
            }
        }

        private string _idNumber;

        public string IdNumber
        {
            get { return _idNumber; }
            set
            {
                if (isValid(value))
                    _idNumber = value;
            }
        }

        private string _type;

        public string Type
        {
            get { return _type; }
        }

        private string _gender;

        public string Gender
        {
            get { return _gender; }
        }

        private string _birthDate;

        public string BirthDate
        {
            get { return _birthDate; }
        }

        private bool isValid(string idNumber)
        {
            try
            {
                if (!(idNumber.All(char.IsDigit)))
                {
                    Console.WriteLine("Id number should contain only digits: {0}!", idNumber);
                    return false;
                }

                if (!(idNumber.Length == 11))
                {
                    Console.WriteLine("Id number should contain 11 digits: {0}!", idNumber);
                    return false;
                }

                return ComputeIdNumberCheck(idNumber);
            }
            catch
            {
                Console.WriteLine("Invalid Id number: {0}!",idNumber);
                return false;
            }
        }
    }
}
