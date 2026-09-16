namespace Lab02;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("#1: ");
        int[] arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 3, 4, 5, 5 };
        int[] arr2 = new int[10];

        int elMult = 1;

        for (int i = 0; i < arr1.Length; i++)
            elMult *= arr1[i];

        Console.WriteLine($"Добуток елементів масиву arr1: {elMult}");
        Console.WriteLine($"Розмір масиву arr2 через властивість Length: {arr2.Length}");
        Console.WriteLine($"Розмір масиву arr2 через метод GetLength: {arr2.GetLength(0)}\n");

        Console.WriteLine("#2: ");
        int[,] rectArr1 =
        {
            { 9, 8, 7, 6 },
            { 5, 4, 3, 2 }
        };

        int[,] rectArr2 = new int[3, 2];
        
        int[][] jaggedArr = new int[3][];
        jaggedArr[0] = new int[] {2, 3, 4, 5};
        jaggedArr[1] = new int[] {1, 7};
        jaggedArr[2] = arr1;

        int sumRectArr = 0;
        
        for (int i = 0; i < rectArr1.GetLength(0); i++)
        for (int j = 0; j < rectArr1.GetLength(1); j += 2)
            sumRectArr += rectArr1[i, j];

        int sumJaggedArr = 0;
        
        for (int i = 0; i < jaggedArr.Length; i++)
        for (int j = 0; j < jaggedArr[i].Length; j += 2)
            sumJaggedArr += jaggedArr[i][j];

        Console.WriteLine($"Сума елементів непарних стовпців масиву rectArr1: {sumRectArr}");
        Console.WriteLine($"Сума елементів непарних стовпців масиву jaggedArr: {sumJaggedArr}\n");

        Console.WriteLine("#3: ");
        Console.Write("Введіть елемент масиву, кількість якого хочете знайти (ціле число): ");
        
        int elementToSearch = ElementInput();
        int elCount = 0;
        
        foreach (int element in arr1)
            if (element == elementToSearch)
                elCount++;

        Console.WriteLine($"Кількість елементів '{elementToSearch}' в масиві arr1: {elCount}\n");

        Console.WriteLine("#4: ");
        
        Continent continent1 = new Continent("Євразія", 123456.78);
        Continent continent2 = new Continent("Євразія", 123456.78);

        object obj1 = continent1;
        Continent? continent3 = obj1 as Continent;
        
        Console.WriteLine($"Результат оператора as: {continent3 != null}");
        Console.WriteLine($"Чи є continent3 екзмепляром класу Continent?: {continent3 is Continent}");
        Console.WriteLine("--------------------------");
        Console.WriteLine($"Equals (перевизначений): {continent1.Equals(continent2)}");
        Console.WriteLine($"ToString (перевизначений):\n{continent1.ToString()}");
    }

    static int ElementInput()
    {
        while (true)
        {
            bool isParsed = int.TryParse(Console.ReadLine(), out int elementToSearch);

            if (!isParsed)
            {
                Console.WriteLine("Error: Введіть ціле число");
                continue;
            }

            return elementToSearch;
        }
    }
}

internal class Continent
{
    internal string ContinentName;
    internal double ContinentSquare;

    internal Continent(string name, double square)
    {
        ContinentName = name;
        ContinentSquare = square;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Continent continent)
        {
            bool continentResult = ContinentName == continent.ContinentName
                                   && ContinentSquare == continent.ContinentSquare;
            
            return continentResult;
        }
    
        return false;
    }
    
    public override string ToString()
    {
        return $"Континент: {ContinentName} \nЙого площа: {ContinentSquare}";
    }
}