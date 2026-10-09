namespace Lab5;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("#1.1:");
        // PharmacyItem medicineBad = new PharmacyItem();
        Medicine medicine = new Medicine("аспірін", 10, 45.5);
        PharmacyItem item = medicine;
        Console.WriteLine($"Через змінну типу PharmacyItem: {item.GetStorageInfo()}");
 
        Console.WriteLine("#1.2:");
        Medicine medicineDefault = new Medicine();
        medicineDefault.Show();
        medicine.Show();
        Console.WriteLine();
 
        Console.WriteLine("#1.4:");
        string medicineName = "Мілукант";
        char[] abbreviationChars = new char[3];
        for (int i = 0; i < abbreviationChars.Length; i++)
        {
            abbreviationChars[i] = char.ToUpper(medicineName[i]);
        }
        string abbreviation = new string(abbreviationChars);
        string lineString = new string('-', 20);
        Console.WriteLine($"Код ліків: {abbreviation}");
        Console.WriteLine($"Роздільник: {lineString}\n");
 
        Console.WriteLine("#1.5:");
        string text = "Аспірін,Мілукант,Дуфалак";
        Console.WriteLine($"text: {text}");
        string subText = text.Substring(0, 11);
        string textReplaced = text.Replace(',', ';');
        string[] textParts = text.Split(',');
        Console.WriteLine($"Результат виконання Substring(0, 11) = {subText}");
        Console.WriteLine($"Результат виконання Replace(',', ';') = {textReplaced}");
        Console.WriteLine($"Split(',') = {textParts.Length} елементи, перший: {textParts[0]}");
        Console.WriteLine($"text після методів не змінився: {text}");
        Console.WriteLine($"Індексатор text[1] = {text[1]}");
        // text[0] = 'p';
        Console.WriteLine();
 
        Console.WriteLine("#1.6:");
        string s1 = "Мілукант";
        string s2 = "Мілукант";
        string s3 = new StringBuilder("Мілу").Append("кант").ToString();
        Console.WriteLine($"s1 і s2 (однакові літерали) - одне посилання: {object.ReferenceEquals(s1, s2)}");
        Console.WriteLine($"s1 і s3 (s3 створений у ході виконання програми) - одне посилання: {object.ReferenceEquals(s1, s3)}");
        string s4 = string.Intern(s3);
        Console.WriteLine($"s1 і s4 (після Intern) - одне посилання: {object.ReferenceEquals(s1, s4)}\n");
 
        Console.WriteLine("#1.7:");
        Console.WriteLine($"s1.Equals(s3) = {s1.Equals(s3)}");
        Console.WriteLine($"s1 == s3 = {s1 == s3}");
        Console.WriteLine($"ReferenceEquals(s1, s3) = {object.ReferenceEquals(s1, s3)}");
        Medicine medicine2 = new Medicine("аспірін", 10, 45.5);
        Console.WriteLine($"medicine.Equals(medicine2) (однакові дані, різні об'єкти) = {medicine.Equals(medicine2)}\n");
 
        Console.WriteLine("#1.8: скріншот");
 
        Console.WriteLine("Додатково (ініціалізатор об'єкта):");
        Medicine medicineInitializer = new Medicine { recommendationsMedicine = "Приймати після їжі" };
        medicineInitializer.Show();
        Console.WriteLine($"Рекомендації: {medicineInitializer.recommendationsMedicine}\n");
 
        Console.WriteLine("#2.1:");
        Tablet tablet = new Tablet("Нурофен", 20, 120.0, 200);
        Syrup syrup = new Syrup("Пектолван плющ", 5, 150.0, 100);
        tablet.Show();
        Console.WriteLine();
 
        Console.WriteLine("#2.2:");
        CommonMethod(medicine);
        CommonMethod(tablet);
        CommonMethod(syrup);
        Console.WriteLine();
 
        Console.WriteLine("#2.3:");
        Medicine[] medicineItems = { new Medicine("Фаніган", 10, 45.5), tablet, syrup };
        foreach (Medicine medicineItem in medicineItems)
        {
            medicineItem.Show();
        }
        Console.ReadLine();
    }
    
    static void CommonMethod(Medicine medicine)
    {
        medicine.Show();
    }
}

abstract class PharmacyItem
{
    public abstract string GetStorageInfo();
}

partial class Medicine : PharmacyItem
{
    protected string medicineName;
    protected int numberOfMedicine;
    protected double priceOfMedicine;
    public string recommendationsMedicine { get; set; }

    internal Medicine() : this("НЕВИЗАНЧЕНО", 0, 0.0)
    {
    }

    internal Medicine(string medicineName, int numberOfMedicine, double priceOfMedicine)
    {
        this.medicineName = medicineName;
        this.numberOfMedicine = numberOfMedicine;
        this.priceOfMedicine = priceOfMedicine;
    }
 
    public override string GetStorageInfo()
    {
        return "Зберігати в сухому місці";
    }
}

partial class Medicine
{
    public virtual void Show()
    {
        Console.WriteLine($"Ліки: {medicineName}, кількість: {numberOfMedicine}, ціна: {priceOfMedicine} грн");
    }
}

class Tablet : Medicine
{
    int dosageMg;

    public Tablet(string name, int number, double price, int dosageMg) : base(name, number, price)
    {
        this.dosageMg = dosageMg;
    }
 
    public override void Show()
    {
        base.Show();
        Console.WriteLine($" - це Таблетка, дозування: {dosageMg} мг");
    }
}

sealed class Syrup : Medicine
{
    int volumeMl;
 
    public Syrup(string name, int number, double price, int volumeMl) : base(name, number, price)
    {
        this.volumeMl = volumeMl;
    }
 
    public override void Show() 
    {
        base.Show();
        Console.WriteLine($"- це Сироп, об'єм: {volumeMl} мл"); 
    }
}
 
// class Bottle : Syrup { }