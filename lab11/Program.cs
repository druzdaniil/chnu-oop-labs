using System.Collections;

namespace Lab11;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine("#1:");
        ArrayList numbers = new ArrayList();
        Console.WriteLine($"Count = {numbers.Count}, Capacity = {numbers.Capacity}");
        program.ShowNumbers(numbers);
        numbers.Add(9);
        numbers.Add(2);
        numbers.Add(11);
        numbers.Add(5);
        numbers.Add(7);
        Console.WriteLine($"Count = {numbers.Count}, Capacity = {numbers.Capacity}");
        program.ShowNumbers(numbers);
        numbers.Insert(1, 4);
        Console.WriteLine("Insert 4 by 1 index:");
        program.ShowNumbers(numbers);
        Console.WriteLine($"Contains 11: {numbers.Contains(11)}");
        Console.WriteLine($"Index of 5: {numbers.IndexOf(5)}");
        Console.WriteLine($"Index of 1000: {numbers.IndexOf(1000)}");
        Console.WriteLine($"Contains 5: {numbers.Contains(5)}");
        numbers.Remove(5);
        Console.WriteLine($"Contains 5 after Remove: {numbers.Contains(5)}\n");

        Console.WriteLine("Before sort:");
        program.ShowNumbers(numbers);
        numbers.Sort();
        Console.WriteLine("After sort:");
        program.ShowNumbers(numbers);
        Console.WriteLine();

        int[] numbersArray = (int[])numbers.ToArray(typeof(int));
        numbersArray[0] = 100;
        Console.WriteLine($"numbersArray[0] = {numbersArray[0]}, numbers[0] = {numbers[0]}\n");

        Console.WriteLine("#2:");
        ArrayList trains = new ArrayList();
        trains.Add(new Train("TRAIN-1", "Kyiv", 420));
        trains.Add(new Train("TRAIN-3", "Lviv", 380));
        trains.Add(new Train("TRAIN-4", "Odesa", 510));
        trains.Add(new Train("TRAIN-2", "Kharkiv", 290));

        Console.WriteLine("Before sort:");
        program.ShowTrains(trains);
        trains.Sort();
        Console.WriteLine("Sorted by number:");
        program.ShowTrains(trains);

        IComparer comparerByPassengers = new CompareByPassengers();
        trains.Sort(comparerByPassengers);
        Console.WriteLine("Sorted by passengers:");
        program.ShowTrains(trains);

        Train firstTrain = (Train)trains[0];
        Console.WriteLine($"First train now: {firstTrain.Number}\n");

        int totalPassengers = 0;
        foreach (Train train in trains)
        {
            totalPassengers += train.Passengers;
        }
        Console.WriteLine($"Total passengers of all trains: {totalPassengers}");
    }

    void ShowNumbers(ArrayList list)
    {
        Console.Write("Numbers: ");
        foreach (int number in list)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }

    void ShowTrains(ArrayList list)
    {
        foreach (Train train in list)
        {
            Console.WriteLine(train);
        }
        Console.WriteLine();
    }
}

class Train : IComparable
{
    private string number;
    private string destination;
    private int passengers;
    
    public string Number { get { return number; } }
    public string Destination { get { return destination; } }
    public int Passengers { get { return passengers; } }

    public Train(string number, string destination, int passengers)
    {
        this.number = number;
        this.destination = destination;
        this.passengers = passengers;
    }

    public int CompareTo(object? obj)
    {
        if (obj == null) return 1;
        if (obj is Train other) return this.number.CompareTo(other.number);
        else throw new ArgumentException("Object is not a Train");
    }
    
    public override string ToString()
    {
        return $"Train: {number}, destination: {destination}, passengers: {passengers}";
    }
}

class CompareByPassengers : IComparer
{
    public int Compare(object? x, object? y)
    {
        Train first = (Train)x!;
        Train second = (Train)y!;
        return first.Passengers.CompareTo(second.Passengers);
    }
}