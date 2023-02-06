using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopFeriaVirtual.Application.Validations
{
    public class RutValidation
    {
        public static bool IsValid(string rutToValidate)
        {
            if (string.IsNullOrEmpty(rutToValidate)) return false;
            string rutNoDots = rutToValidate.Replace(".", string.Empty).ToLower();


            string dvRut = string.Empty;
            var splittedRut = rutNoDots.Split('-');

            string extractedRut = string.Empty;
            if (splittedRut.Length == 2)
            {
                extractedRut = splittedRut[0];
                dvRut = splittedRut[1];
            }
            else
            {
                extractedRut = rutNoDots.Substring(0, rutNoDots.Length - 1);
                dvRut = rutNoDots.Substring(rutNoDots.Length - 1);
            }
            if (!int.TryParse(extractedRut, out int rutNumber)) return false;

            string expectedDv = GetExpectedVerifierDigit(rutNumber);
            if(dvRut != expectedDv) return false;
            
            return true;
        }

        private static string GetExpectedVerifierDigit(int rut)
        {
            int[] series = { 2, 3, 4, 5, 6, 7 };
            int i = 0;
            int accum = 0;

            while(rut > 0 )
            {
                //Get the last digit
                int digit = rut % 10;
                accum += digit * series[i];

                //Remove last digit, since its now decimal
                rut /= 10;

                i = i < series.Length - 1 ? i + 1 : 0;
            }
            int result = 11 - (accum % 11);

            switch (result)
            {
                case 10:
                    return "k";
                case 11:
                    return "0";
                default:
                    return result.ToString();
            }
        }

    }
}
