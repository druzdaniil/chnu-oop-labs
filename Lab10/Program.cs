namespace Lab10;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("#1:");
        Test firstTest = new Test("OOP", 3, 30);
        Console.WriteLine(firstTest);
        Console.WriteLine($"IsDisposed: {firstTest.IsDisposed}");
        firstTest.Dispose();
        Console.WriteLine($"IsDisposed: {firstTest.IsDisposed}");
        firstTest.Dispose();
        Console.WriteLine();

        Console.WriteLine("#2:");
        string path = "lab10_file.txt";
        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.WriteLine("Daniil");
            writer.WriteLine("Druz");
            writer.WriteLine("Bla bla bla");
            Console.WriteLine("Writing to file...");
        }
        using (StreamReader reader = new StreamReader(path))
        {
            string text = reader.ReadToEnd();
            Console.WriteLine("File content:");
            Console.Write(text);
        }
        File.Delete(path);
        Console.WriteLine("----------------");
        using (Test usingTest = new Test("Frontend", 2, 20))
        {
            Console.WriteLine(usingTest);
        }
        Console.WriteLine();

        Console.WriteLine("#3:");
        Console.WriteLine("Without Dispose:");
        CreateLostTest();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("----------------");
        Console.WriteLine("With Dispose:");
        Test cleanTest = new Test("English", 5, 50);
        Console.WriteLine($"Generation before GC: {GC.GetGeneration(cleanTest)}");
        cleanTest.Dispose();
        cleanTest = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
    
    static void CreateLostTest()
    {
        Test lostTest = new Test("Algorithms", 4, 40);
        Console.WriteLine($"Generation before GC: {GC.GetGeneration(lostTest)}");
        lostTest = null;
    }
}

sealed class Test : IDisposable
{
    private string testName;
    private int questionsCount;
    private int maxScore;
    private string[] questions;
    private bool isDisposed = false;

    public string TestName { get { return testName; } }
    public int QuestionsCount { get { return questionsCount; } }
    public int MaxScore { get { return maxScore; } }
    public bool IsDisposed { get { return isDisposed; } }

    public Test(string testName, int questionsCount, int maxScore) 
    {
        this.testName = testName;
        this.questionsCount = questionsCount;
        this.maxScore = maxScore; 
        questions = new string[questionsCount];
        for (int i = 0; i < questionsCount; i++)
        {
            questions[i] = "Question " + (i + 1);
        }
        Console.WriteLine($"Constructor: test '{testName}' created");
    }

    public void Dispose()
    {
        if (isDisposed) return;
        isDisposed = true;
        if (questions != null)
        {
            Array.Clear(questions, 0, questions.Length);
            questions = null;
        }
        Console.WriteLine($"Dispose: managed resources of '{testName}' released");
        GC.SuppressFinalize(this);
    }

    ~Test()
    {
        Console.WriteLine($"Destructor: unmanaged resources of '{testName}' released");
        if (!isDisposed) Dispose();
    }

    public override string ToString()
    {
        return $"Test '{testName}', questions: {questionsCount}, max score: {maxScore}";
    }
}