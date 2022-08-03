using EgnHelper;

namespace Egnhelper
{
    public class EgnExtraxtInformation
    {

        public EgnInformation Extract(string egn)
        {
            var egnValidator = new EgnValidator();
            
            if(!egnValidator.IsValid(egn))
            {
                throw new ArgumentException("Invalid EGN provider.", nameof(egn));
            }

            Sex sex = Sex.Unknow;
            if (int.Parse(egn[8].ToString()) % 2 == 0)
            {
                sex = Sex.Male;
            }
            else
            {
                sex = Sex.Female;
            }

            int partYear = int.Parse(egn.Substring(0, 2));

            int monthPart = int.Parse(egn.Substring(2, 2));

            int dayPart = int.Parse(egn.Substring(4, 2));

            int month = monthPart;
            int year = partYear;
            int day = dayPart;

            if (monthPart >= 21 && monthPart <= 32)
            {
                month = monthPart - 20;
                year = partYear + 1800;
            }

            if (monthPart >= 41 && monthPart <= 52)
            {
                month = monthPart - 40;
                year = partYear + 2000;
            }

            else if (monthPart >= 1 && monthPart <= 12)
            {
                year = partYear + 1900;
            }
           var dateOfBirth = new DateTime(year,month,day);

            return new EgnInformation(dateOfBirth,sex);
        }
    }
}