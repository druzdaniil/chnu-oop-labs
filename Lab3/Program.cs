namespace Lab3;

class Program
{
    static void Main(string[] args)
    {
        Medicine medicine1 = new Medicine("Мілукант", 120, 319.99);
        
        Console.WriteLine("#1:");
        Console.WriteLine($"Отримання значення medicineName: {medicine1.GetMedicineName()}");
        medicine1.SetMedicineName("Дуфалак");
        Console.WriteLine($"Отримання значення medicineName після встановлення сеттером: {medicine1.GetMedicineName()}\n");
        
        Console.WriteLine("#2:");
        Console.WriteLine($"Отримання значення numberOfMedicine: {medicine1.GetNumberOfMedicine()}");
        medicine1.SetNumberOfMedicine(50);
        Console.WriteLine($"Отримання значення numberOfMedicine після встановлення сеттером-виразом: {medicine1.GetNumberOfMedicine()}\n");

        Console.WriteLine("#3:");
        Console.WriteLine($"Отримання значення priceOfMedicine: {medicine1.PriceOfMedicine}");
        medicine1.PriceOfMedicine = 224.99;
        Console.WriteLine($"Отримання значення priceOfMedicine після встановлення сеттером властивості: {medicine1.PriceOfMedicine}\n");
        
        Console.WriteLine("#4:");
        medicine1.recommendationsMedicine = "Приймайте препарат лише за рекомендацією лікаря";
        Console.WriteLine($"Отримання значення recommendationsMedicine: {medicine1.recommendationsMedicine}\n");
        
        Console.WriteLine("#5:");
        medicine1[0] = "Складова №1";
        Console.WriteLine($"Отримання значення складової за індеком 0: {medicine1[0]}");
        Console.Write("Приклад спроби встановити значення за індеком, більшим за розмір масиву: ");
        medicine1[15] = "Складова №16";
    }
}

internal class Medicine
{
    string medicineName;
    int numberOfMedicine;
    double priceOfMedicine;
    public string recommendationsMedicine { get; set; }
    private string[] conponentsOfMedicine = new string[14];

    internal Medicine(string name, int numberOf, double priceOf)
    {
        medicineName = name;
        numberOfMedicine = numberOf;
        priceOfMedicine = priceOf;
    }

    public string GetMedicineName() { return this.medicineName; }
    public void SetMedicineName(string name) { this.medicineName = name; }

    public int GetNumberOfMedicine() => this.numberOfMedicine;
    public void SetNumberOfMedicine(int numberOf) => this.numberOfMedicine = numberOf;

    public double PriceOfMedicine
    {
        get { return priceOfMedicine; }
        set { priceOfMedicine = value; }
    }

    public string this[int index]
    {
        get { return conponentsOfMedicine[index]; }
        set
        {
            if (index <= conponentsOfMedicine.Length)
            {
                conponentsOfMedicine[index] = value;
            } else
            {
                Console.WriteLine($"Індекс даного масиву не може бути більше за {conponentsOfMedicine.Length}");
            }
        }
    }
}