using EgnHelper;

public class Program
{
    static void Main(string[] args)
    {
        ValidateFromUser(new EgnValidator());

    }

    public static void ValidateFromUser(IEgnValidator validator)
    {
        var egn = Console.ReadLine();
        Console.WriteLine("Valid :" + validator.IsValid(egn));
    }
}