namespace Lab07;

enum Month
{
    January = 1, February, March,
    April, May, June,
    July, August, September,
    October, November, December
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("#1: ");
        Console.Write("Введіть номер місяця (1-12): ");
        int number;
        if (int.TryParse(Console.ReadLine(), out number))
        {
            Month month = (Month)number;

            if (Enum.IsDefined(typeof(Month), month))
            {
                Console.WriteLine($"Місяць: {Enum.GetName(typeof(Month), number)}");
                Console.WriteLine($"Номер місяця: {(int)month}");
            }
            else
            {
                Console.WriteLine("Такого місяця не існує");
            }
        }
        else
        {
            Console.WriteLine("Потрібно ввести ціле число");
        }

        string[] names = Enum.GetNames(typeof(Month));
        Console.WriteLine($"Усі місяці: {string.Join(", ", names)}");
        Console.WriteLine();

        Console.WriteLine("#2:");
        Weapon<int, int> weaponSword = new("Меч", 10, 2);
        Weapon<int, int> weaponDagger = new("Кинджал", 7, 1);
        Weapon<int, int> weaponAxe = new() { Name = "Сокира", Damage = 15, Range = 2 };
        Weapon<double, int> weaponBow = new("Лук", 12.5, 30);
        Weapon<string, string> weaponSpell = new("Заклинання", "Сильна", "Велика");

        Console.WriteLine(weaponSword);
        Console.WriteLine(weaponDagger);
        Console.WriteLine(weaponAxe);
        Console.WriteLine(weaponBow);
        Console.WriteLine(weaponSpell);
        Console.WriteLine();

        Console.WriteLine("Сума damage та range:");
        Console.WriteLine($"Меч: {weaponSword.Sum()}");
        Console.WriteLine($"Лук: {weaponBow.Sum()}");
        Console.WriteLine($"Заклинання: {weaponSpell.Sum()}\n");

        Console.WriteLine("Count: ");
        Console.WriteLine($"Weapon<int, int>.count = {Weapon<int, int>.count}");
        Console.WriteLine($"Weapon<double, int>.count = {Weapon<double, int>.count}");
        Console.WriteLine($"Weapon<string, string>.count = {Weapon<string, string>.count}");
    }
}

class Weapon<T1, T2>
{
    string name;
    T1 damage = default;
    T2 range = default;

    public static int count;

    public string Name { get { return name; } set { name = value; } }
    public T1 Damage { get { return damage; } set { damage = value; } }
    public T2 Range { get { return range; } set { range = value; } }

    public Weapon()
    {
        count++;
    }

    public Weapon(string name, T1 damage, T2 range)
    {
        this.name = name;
        this.damage = damage;
        this.range = range;
        count++;
    }

    public dynamic Sum()
    {
        return (dynamic)damage + (dynamic)range;
    }

    public override string ToString()
    {
        return $"Зброя \"{name}\", Шкода: {damage}, Зона ураження: {range}";
    }
}