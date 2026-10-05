namespace Lab04_AdditionalTasks;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Додаткове завдання про кур'єра Глово: ");
        Courier courier = new Courier();
        courier.ShowDelivery(25, 40, 15);
        courier.ShowDelivery(30);
        courier.ShowDelivery();
        courier.ShowDelivery(10, 20, 30, 40, 50);
        courier.ShowDelivery(10, 20, 30, 40, 50, 60);
        Console.WriteLine();
        
        Console.WriteLine("Додаткове завдання про інопланетянина:");
        Alien alien1 = new Alien("Інопланетянин_1");
        Alien alien2 = new Alien("Інопланетянин_2");
        Alien alien3 = new Alien("Інопланетянка_1", AlienGender.Жіноча);
        Console.WriteLine("Інформація про першого інопланетянина: ");
        alien1.PrintAlienInfo();
        Console.WriteLine("Інформація про другого інопланетянина: ");
        alien2.PrintAlienInfo();
        Console.WriteLine("Інформація про третього інопланетянина: ");
        alien3.PrintAlienInfo();
    }
}

public class Courier
{
    public void ShowDelivery(params int[] minutes)
    {
        int totalMinutes = 0;
        foreach (int minute in minutes) totalMinutes += minute;

        Console.WriteLine($"Сумарний час: {totalMinutes} хв, кількість замовлень: {minutes.Length}");
    }
}

public enum AlienGender
{
    Чоловіча,
    Жіноча
}

public class Alien
{
    public const string RACE = "Раса";
    public readonly AlienGender Gender;
    public const AlienGender GENDER_DEFAULT = AlienGender.Чоловіча;
    public string Name { get; set; }

    public Alien(string name, AlienGender gender = GENDER_DEFAULT) 
    {
        this.Name = name;
        this.Gender = gender;
    }
    
    public void PrintAlienInfo()
    {
        Console.WriteLine($"Раса: {RACE}, стать: {Gender}, ім'я: {Name}");
    }
}