namespace Lab04;

class Program
{
    static void Main(string[] args)
    {
        MyClass myObject = new MyClass();
        
        Console.WriteLine("#1.1:");
        int number = 2;
        Console.WriteLine($"number (до методу WriteSomeMath) = {number}");
        myObject.WriteSomeMath(number);
        Console.WriteLine($"number (після методу WriteSomeMath) = {number}\n");
        
        Console.WriteLine("#1.2:");
        int[] arr = { 1, 2, 3 };
        Console.WriteLine($"arr[0] (до методу ResetFirstArrayElement) = {arr[0]}");
        myObject.ResetFirstArrayElement(arr);
        Console.WriteLine($"arr[0] (після методу ResetFirstArrayElement) = {arr[0]}\n");
        
        Console.WriteLine("#1.3:");
        int num = 2;
        Console.WriteLine($"number (до методу Increment) = {num}");
        myObject.Increment(ref num);
        Console.WriteLine($"number (після методу Increment) = {num}\n");
        
        Console.WriteLine("#1.4:");
        double fullNumber;
        myObject.SetNewDouble(out fullNumber);
        Console.WriteLine($"fullNumber (після методу SetNewDouble) = {fullNumber}\n");

        Console.WriteLine("#1.5:");
        myObject.CalcAverage(5, 2, 3);
        myObject.CalcAverage(1);
        myObject.CalcAverage();
        Console.WriteLine();
        
        Console.WriteLine("#1.6:");
        myObject.CalcFinalPrice(2000);
        myObject.CalcFinalPrice(2000, 0.6);
        Console.WriteLine();

        Console.WriteLine("#2:");
        Console.WriteLine($"Об'єктів створено (до new): {SpecialClass.InstanceCount}");
        SpecialClass.ExecutionCountMethod();
        Console.WriteLine("-------------------------------");
        SpecialClass specialObject1 = new SpecialClass(12,"Перший");
        SpecialClass specialObject2 = new SpecialClass(22, "Другий");
        SpecialClass specialObject3 = new SpecialClass(67, "Третій");
        Console.WriteLine($"Об'єктів створено (після трьох new): {SpecialClass.InstanceCount}");
        Console.WriteLine($"obj1.SPECIAL_INT = {specialObject1.SPECIAL_INT}, obj2.SPECIAL_INT = {specialObject2.SPECIAL_INT}, obj3.SPECIAL_INT = {specialObject3.SPECIAL_INT}");
        Console.WriteLine("-------------------------------");
        SpecialClass.ExecutionCountMethod();
        Console.WriteLine($"Статична змінна ExecutionCount: {SpecialClass.ExecutionCount}\n");
        
        Console.WriteLine("#3:");
        ArrayDemonstrationClass arrayDemonstrationObject = new ArrayDemonstrationClass();
        arrayDemonstrationObject.ShowArrayMethods();
        Console.WriteLine();
    }
    
}

public class MyClass
{
    public void WriteSomeMath(int number)
    {
        number = number * number + 31;
        Console.WriteLine($"number (в методі WriteSomeMath) = {number}");
    }

    public void ResetFirstArrayElement(int[] arr)
    {
        if (arr.Length > 0) arr[0] = 0;
        Console.WriteLine($"arr[0] (в методі ResetFirstArrayElement) = {arr[0]}");
    }

    public void Increment(ref int number)
    {
        number++;
        Console.WriteLine($"number (в методі Increment) = {number}");
    }

    public void SetNewDouble(out double fullNumber)
    {
        fullNumber = 5.5555;
        Console.WriteLine($"fullNumber (в методі SetNewDouble) = {fullNumber}");
    }

    public void CalcAverage(params double[] numbersArr)
    {
        double sum = 0;
        
        foreach (var element in numbersArr)
        {
            sum += element;
        }
        
        double average = sum / numbersArr.Length;
        Console.WriteLine($"Результат виконання методу CalcAverage: {average}");
    }

    public void CalcFinalPrice(double price, double discount = 0.05)
    {
        double finalPrice = price - (price * discount);
        Console.WriteLine($"Фінальна ціна при стартовій ціні {price} та знижці {discount}: {finalPrice}");
    }
}

public class SpecialClass
{
    public const double SPECIAL_DOUBLE = 1.23456;
    public readonly char SPECIAL_CHAR = 'd';
    public readonly int SPECIAL_INT = 23;
    public readonly string SPECIAL_STRING;

    public static int ExecutionCount;
    public static int InstanceCount;
    
    public SpecialClass(int specialInt, string specialString)
    {
        this.SPECIAL_INT = specialInt;
        this.SPECIAL_STRING = specialString;
        InstanceCount++;
    }

    public static void ExecutionCountMethod()
    {
        ExecutionCount++;
        Console.WriteLine($"Статичний метод сумарно викликано {ExecutionCount} раз");
    }
}

public class ArrayDemonstrationClass()
{
    public void ShowArrayMethods()
    {
        int[] numbersArr = { 2, 3, 19, 18, -6, 10, 5, 0 };
        Console.WriteLine($"Початковий масив: [{String.Join(", ", numbersArr)}]");
        
        Array.Reverse(numbersArr);
        Console.WriteLine($"Масив після Array.Reverse: [{String.Join(", ", numbersArr)}]");
        
        Array.Sort(numbersArr);
        Console.WriteLine($"Масив після Array.Sort: [{String.Join(", ", numbersArr)}]");
        
        int index = Array.BinarySearch(numbersArr, 10);
        Console.WriteLine($"Array.BinarySearch(numbersArr, 10): {index}");
    }
}