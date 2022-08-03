using System.Globalization;
using System.Text.RegularExpressions;

namespace EgnHelper
{
    public class EgnValidator : IEgnValidator
    {
        private int[] weights = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
        public bool IsValid(string egn)
        {
            if(egn == null)
            {
                throw new ArgumentNullException(nameof(egn));
            }
           
            if (!Regex.IsMatch(egn,"[0-9]{10}"))
            {
                return false;
            }

            int partYear = int.Parse(egn.Substring(0,2));

            int monthPart = int.Parse(egn.Substring(2,2));

            int dayPart = int.Parse(egn.Substring(4,2));

            int month = monthPart;
            int year = partYear;
            int day = dayPart;

            if(monthPart >= 21 && monthPart <= 32)
            {
                month = monthPart - 20;
                year = partYear + 1800;
            }

            if(monthPart >= 41 && monthPart <= 52)
            {
                month = monthPart - 40;
                year = partYear + 2000;
            }

            else if(monthPart >= 1 && monthPart <= 12)
            {
                year = partYear + 1900;
            }
            else
            {
                return false;
            }

            if (!DateTime.TryParseExact($"{year}-{month}-{day}", 
                "yyyy-M-d",CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _))
            {
                return false;
            }
            var checksum = 0;
            for (int i = 0; i <= 8; i++)
            {
                var digit = int.Parse(egn[i].ToString());
                checksum += digit * weights[i];
                
            }
            var lastDigit = checksum % 11;
            if(lastDigit == 10)
            {
                lastDigit = 0;
            }

            if(int.Parse(egn[9].ToString()) != lastDigit)
            {
                return false;
            }

            return true;
        }
    }
}