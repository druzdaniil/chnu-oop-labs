namespace Lab09;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();

        Console.WriteLine("#1:");
        int[] grades = { 90, 75, 60 };
        int index = 5;
        try
        {
            int grade = grades[index];
            Console.WriteLine(grade);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Error: index {index} is outside the array (actual size is {grades.Length})");
            Console.WriteLine($"Message: {ex.Message}");
        }
        Console.WriteLine();

        Console.WriteLine("#2:");
        try
        {
            int number = int.Parse("12a");
            Console.WriteLine(number);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Error: index {index} is outside the array (actual size is {grades.Length})");
            Console.WriteLine($"Message: {ex.Message}");
        }
        catch
        {
            Console.WriteLine("General catch: some other exception was thrown");
        }
        Console.WriteLine();

        Console.WriteLine("#3:");
        Console.WriteLine("#3.2.1: ");
        try
        {
            program.LoadWithRethrow();
        }
        catch (FormatException ex)
        {
            Console.WriteLine("StackTrace:");
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine($"InnerException: {ex.InnerException}");
        }
        Console.WriteLine();
        Console.WriteLine("#3.2.2:");
        try
        {
            program.LoadWithWrap();
        }
        catch (FormatException ex)
        {
            Console.WriteLine("StackTrace:");
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("InnerException:");
            Console.WriteLine(ex.InnerException);
        }
        Console.WriteLine();

        Console.WriteLine("#4:");
        program.CheckParameter("age");
        program.CheckParameter("height");
        Console.WriteLine();

        Console.WriteLine("#5:");
        int[] arr = { 10, 20, 30 };
        Console.WriteLine("#5.2.1:");
        program.ReadArrayItem(arr, 1);
        Console.WriteLine();
        Console.WriteLine("#5.2.2:");
        program.ReadArrayItem(arr, 7);
        Console.WriteLine();

        Console.WriteLine("#5.2.3:");
        try
        {
            try
            {
                Console.WriteLine("inner try: arr[9] = " + arr[9]);
            }
            catch (FormatException)
            {
                Console.WriteLine("inner catch");
            }
            finally
            {
                Console.WriteLine("inner finally");
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("outer catch");
        }
        Console.WriteLine();

        // Console.WriteLine("Environment.Exit(0) demonstration:");
        // try
        // {
        //     Console.WriteLine("try");
        //     Environment.Exit(0);
        // }
        // finally
        // {
        //     Console.WriteLine("finally");
        // }

        Console.WriteLine("#6.1:");
        try
        {
            program.ValidateUsername("ab");
        }
        catch (InvalidInputDataException ex)
        {
            Console.WriteLine($"Message: {ex.Message}");
            Console.WriteLine($"Field name: {ex.FieldName}");
        }
        Console.WriteLine();

        Console.WriteLine("#6.2:");
        try
        {
            program.ValidateUsername("ValidUsernameExample");
        }
        catch (InvalidInputDataException ex)
        {
            Console.WriteLine($"Message: {ex.Message}");
            Console.WriteLine($"Field name: {ex.FieldName}");
        }
    }

    int ParseNumber(string text)
    {
        return int.Parse(text);
    }

    void LoadWithRethrow()
    {
        try
        {
            ParseNumber("abc");
        }
        catch (FormatException)
        {
            throw;
        }
    }

    void LoadWithWrap()
    {
        try
        {
            ParseNumber("abc");
        }
        catch (FormatException ex)
        {
            throw new FormatException("Wrapped error", ex);
        }
    }

    void CheckParameter(string paramName)
    {
        try
        {
            throw new ArgumentOutOfRangeException(paramName, -1, "Value is out of allowed range");
        }
        catch (ArgumentOutOfRangeException ex) when (ex.ParamName == "age")
        {
            Console.WriteLine("Filter is true: problem with the parameter 'age'");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Filter is false: problem with the parameter '{ex.ParamName}'");
        }
    }

    void ReadArrayItem(int[] arr, int index)
    {
        try
        {
            Console.WriteLine($"try: arr[{index}] = {arr[index]}");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("catch: index is outside the array");
        }
        finally
        {
            Console.WriteLine("finally");
        }
    }

    void ValidateUsername(string name)
    {
        if (name.Length < 3)
        {
            throw new InvalidInputDataException("Username is too short", "username");
        }
        Console.WriteLine($"Username is correct: {name}");
    }
}

class InvalidInputDataException : Exception
{
    string fieldName;

    public string FieldName { get { return fieldName; } }

    public InvalidInputDataException() : base()
    {
    }

    public InvalidInputDataException(string message) : base(message)
    {
    }

    public InvalidInputDataException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public InvalidInputDataException(string message, string fieldName) : base(message)
    {
        this.fieldName = fieldName;
    }
}