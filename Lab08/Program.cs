namespace Lab08;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();

        Console.WriteLine("#1.1:");
        // IMedicine interfaceVariableBad = new IMedicine();
        Tablet tablet = new Tablet("Nurofen", 20, 120.0, 200);
        Syrup syrup = new Syrup("Pectolvan Plushch", 5, 150.0, 100);
        IMedicine interfaceVariable = tablet;
        Console.WriteLine($"Interface variable refers to: {interfaceVariable.MedicineType}");
        interfaceVariable = syrup;
        Console.WriteLine($"Interface variable refers to: {interfaceVariable.MedicineType}\n");

        Console.WriteLine("#1.2:");
        Console.WriteLine(tablet);
        Console.WriteLine(syrup + "\n");

        Console.WriteLine("#1.3:");
        program.PrintUsageInfo(tablet);
        program.PrintUsageInfo(syrup);
        IMedicine[] medicineInterfaceTypeArray = { tablet, syrup };
        foreach (IMedicine item in medicineInterfaceTypeArray)
        {
            program.PrintUsageInfo(item);
        }
        Console.WriteLine();

        Tree[] trees =
        {
            new Tree("Oak", 120, 25.5),
            new Tree("Pine", 60, 30.0),
            new Tree("Birch", 40, 18.2),
            new Tree("Maple", 80, 22.7)
        };

        Console.WriteLine("#2.1:");
        Array.Sort(trees);
        program.ShowArray(trees);

        Console.WriteLine("#2.2:");
        Array.Sort(trees, trees[0]);
        program.ShowArray(trees);

        Console.WriteLine("#2.3:");
        Array.Sort(trees, new CompareByHeight());
        program.ShowArray(trees);

        Console.WriteLine("#3:");
        Park park = new Park(
            new Tree("Oak", 120, 25.5),
            new Tree("Pine", 60, 30.0),
            new Tree("Birch", 40, 18.2),
            new Tree("Maple", 80, 22.7)
        );

        Console.WriteLine("Sorted by name:");
        park.SortByName();
        park.Show();

        Console.WriteLine("Sorted by age:");
        park.SortByAge();
        park.Show();

        Console.WriteLine("Sorted by height:");
        park.SortByHeight();
        park.Show();
    }

    void PrintUsageInfo(IMedicine item)
    {
        Console.WriteLine($"{item.MedicineType}: {item.GetUsageInfo()}");
    }

    void ShowArray(Tree[] array)
    {
        foreach (Tree tree in array)
        {
            Console.WriteLine(tree);
        }
        Console.WriteLine();
    }
}

interface IMedicine
{
    string MedicineType { get; }
    string GetUsageInfo();
}

class Medicine
{
    protected string medicineName;
    protected int numberOfMedicine;
    protected double priceOfMedicine;

    internal Medicine(string medicineName, int numberOfMedicine, double priceOfMedicine)
    {
        this.medicineName = medicineName;
        this.numberOfMedicine = numberOfMedicine;
        this.priceOfMedicine = priceOfMedicine;
    }

    public override string ToString()
    {
        return $"Medicine: {medicineName},\n   number: {numberOfMedicine},\n   price: {priceOfMedicine} UAH";
    }
}

class Tablet : Medicine, IMedicine
{
    int dosageMg;

    public string MedicineType { get { return "Tablet"; } }

    public Tablet(string name, int number, double price, int dosageMg) : base(name, number, price)
    {
        this.dosageMg = dosageMg;
    }

    public string GetUsageInfo()
    {
        return $"take 1 tablet ({dosageMg} mg) after meal";
    }

    public override string ToString()
    {
        return base.ToString() + ",\n" + $"   tablet,\n   dosage: {dosageMg} mg";
    }
}

sealed class Syrup : Medicine, IMedicine
{
    int volumeMl;

    public string MedicineType { get { return "Syrup"; } }

    public Syrup(string name, int number, double price, int volumeMl) : base(name, number, price)
    {
        this.volumeMl = volumeMl;
    }

    public string GetUsageInfo()
    {
        return $"shake the bottle ({volumeMl} ml) and take 5 ml three times a day";
    }

    public override string ToString()
    {
        return base.ToString() + ",\n" + $"   syrup,\n   volume: {volumeMl} ml";
    }
}

class Tree : IComparable, IComparer<Tree>
{
    private string name;
    private int age;
    private double height;

    public string Name { get { return name; } }
    public int Age { get { return age; } }
    public double Height { get { return height; } }

    public Tree(string name, int age, double height)
    {
        this.name = name;
        this.age = age;
        this.height = height;
    }

    public int CompareTo(object? obj)
    {
        if (obj == null) return 1;
        if (obj is Tree other)
            return this.name.CompareTo(other.name);
        else
            throw new ArgumentException("Object is not a Tree");
    }

    public int Compare(Tree x, Tree y)
    {
        return x.age.CompareTo(y.age);
    }

    public override string ToString()
    {
        return $"Tree: {name},\n   age: {age} years,\n   height: {height} m";
    }
}

class CompareByHeight : IComparer<Tree>
{
    public int Compare(Tree x, Tree y)
    {
        return x.Height.CompareTo(y.Height);
    }
}

class Park
{
    private Tree[] trees;

    public Park(params Tree[] trees)
    {
        this.trees = (Tree[])trees.Clone();
    }

    public void SortByName()
    {
        Array.Sort(trees);
    }

    public void SortByAge()
    {
        Array.Sort(trees, trees[0]);
    }

    public void SortByHeight()
    {
        Array.Sort(trees, new CompareByHeight());
    }

    public void Show()
    {
        foreach (Tree tree in trees)
        {
            Console.WriteLine(tree);
        }
        Console.WriteLine();
    }
}