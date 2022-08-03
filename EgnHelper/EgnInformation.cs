using System.Globalization;

namespace Egnhelper
{
    public class EgnInformation
    {
        public EgnInformation(DateTime dateOfBirth,Sex sex)
        {
            DateOfBirth = dateOfBirth;
            Sex = sex;
        }
        public DateTime DateOfBirth { get; }

        public Sex Sex { get; }

        public override string ToString()
        {
            var sexAsSex = this.Sex switch
            {
                Sex.Male => "мъж",
                Sex.Female => "жена",
                _ => string.Empty
            };

            var suffix = this.Sex switch
            {
                Sex.Male => string.Empty,
                Sex.Female => "а",
                _ => string.Empty
            };


            return $"ЕГН на {sexAsSex},pоден{suffix} на {DateOfBirth.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("bg-BG"))} г.";
        }
    }
}