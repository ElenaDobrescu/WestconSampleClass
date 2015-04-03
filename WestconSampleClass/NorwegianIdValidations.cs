using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestconSampleClass
{
    internal partial class NorwegianId
    {
        private enum type { fødselsnummer, dnummer};

        private enum gender { mann, kvinne };

        private static string GetTypeFromIdNumber(string idNumber)
        {
            if (!(idNumber.All(char.IsDigit)) || !(idNumber.Length == 11))
                throw new InvalidIdNumberExeption("Incorrect format of Id number!");

            var typeDigit = Convert.ToInt16(idNumber.Substring(0, 1));
            if (typeDigit > 3)
            {
                return type.dnummer.ToString();
            }
            else
                return type.fødselsnummer.ToString();
        }

        private static DateTime GetBirthDateFromIdNumber(string idNumber)
        {
            if (!(idNumber.All(char.IsDigit)) || !(idNumber.Length == 11))
                throw new InvalidIdNumberExeption("Incorrect format of Id number!");

            var birthDate = idNumber.Substring(0, 6);

            var typeDigit = Convert.ToInt16(idNumber.Substring(0, 1));
            if (typeDigit > 3)
            {
                var str = Convert.ToString(Convert.ToInt16(idNumber.Substring(0, 1)) - 4);
                birthDate = str + idNumber.Substring(1, 6);
            }

            DateTime dt;
            if (DateTime.TryParseExact(birthDate, "ddMMyy", CultureInfo.InstalledUICulture, DateTimeStyles.None, out dt))
                return dt;
            else
                throw new InvalidIdNumberExeption("GetBirthDateFromIdNumber: Birthdate does not have a correct format!");
        }


        private static string GetGenderFromIdNumber(string idNumber)
        {
            if (!(idNumber.All(char.IsDigit)) || !(idNumber.Length == 11))
                throw new InvalidIdNumberExeption("Incorrect format of Id number!");

            var typeDigit = Convert.ToInt16(idNumber.Substring(0, 1));
            if (typeDigit > 3)
            {
                if (Convert.ToInt16(idNumber.Substring(10, 1)) % 2 == 0)
                    return gender.kvinne.ToString();
                else
                    return gender.mann.ToString();
            }
            else
            {
                if (Convert.ToInt16(idNumber.Substring(8, 1)) % 2 == 0)
                    return gender.kvinne.ToString();
                else
                    return gender.mann.ToString();
            }
        }

        private static bool ComputeIdNumberCheck(string idNumber)
        {
            var typeDigit = Convert.ToInt16(idNumber.Substring(0, 1));
            if (typeDigit > 3)
                return ComputeDNummerCheck(idNumber);
            else
                return ComputeFødselsnummerCheck(idNumber);
        }

        private static bool ComputeFødselsnummerCheck(string idNumber)
        {
            var bd = GetBirthDateFromIdNumber(idNumber);

            int individualDigits = Convert.ToInt16(idNumber.Substring(6, 3));

            if ((bd.Year >= 1900 && bd.Year <= 1999 && individualDigits <= 499) ||
                (bd.Year >= 1854 && bd.Year <= 1899 && individualDigits >= 500 && individualDigits <= 749) ||
                (bd.Year >= 2000 && bd.Year <= 2039 && individualDigits >= 500 && individualDigits <= 999) ||
                (bd.Year >= 1940 && bd.Year <= 1999 && individualDigits >= 900 && individualDigits <= 999))
            {
                return ValidateControlDigits(idNumber);
            }
            return false;
        }

        private static bool ComputeDNummerCheck(string idNumber)
        {
            return ValidateControlDigits(idNumber);
        }

        private static bool ValidateControlDigits(string idNumber)
        {
            int[] controlDigits = new int[2]
            {
                Convert.ToInt16(idNumber.Substring(9,1)),
                Convert.ToInt16(idNumber.Substring(10,1))
            };

            int[] first9Digits = new int[9];
            for (int i = 0; i < 9; i++)
            {
                first9Digits[i] = Convert.ToInt16(idNumber.Substring(i,1));
            }

            return checkControlDigits(controlDigits, first9Digits);
        }

        private static bool checkControlDigits(int[] cD, int[] f9D)
        {
            int k1 = 11 - ((3 * f9D[0] + 7 * f9D[1] + 6 * f9D[2] + 1 * f9D[3] + 8 * f9D[4] + 9 * f9D[5] + 4 * f9D[6] + 5 * f9D[7] + 2 * f9D[8]) % 11);
            
            if (k1 == 11)
                k1 = 0;

            if (k1 != cD[0])
                return false;

            int k2 = 11 - ((5  * f9D[0] + 4 * f9D[1] + 3 * f9D[2] + 2 * f9D[3] + 7 * f9D[4] + 6 * f9D[5] + 5 * f9D[6] + 4 * f9D[7] + 3 * f9D[8] + 2 * k1 ) % 11);
            
            if (k2 == 11)
                k2 = 0;

            if (k2 != cD[1])
                return false;

            return true;
        }
    }
}
