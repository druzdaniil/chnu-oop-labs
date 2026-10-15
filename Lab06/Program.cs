namespace Lab06;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("#1:");
        Test firstTest = new Test("ООП", 10, 100);
        Test secondTest = new Test("Фронтенд", 5, 50);
        Console.WriteLine(firstTest);
        Console.WriteLine(secondTest);
        Console.WriteLine();
 
        Console.WriteLine("#2 (метод розширення):");
        Console.WriteLine($"Тест має щонайменше 8 питань: {firstTest.HasMinQuestions(8)}");
        Console.WriteLine($"Тест має щонайменше 8 питань: {secondTest.HasMinQuestions(8)}\n");
 
        Console.WriteLine("#3.1 (оператор додавання):");
        Test sumTest = firstTest + secondTest;
        Console.WriteLine($"firstTest: {firstTest}");
        Console.WriteLine($"secondTest: {secondTest}");
        Console.WriteLine($"firstTest + secondTest: {sumTest}");
        Console.WriteLine();
 
        Console.WriteLine("#3.2 (оператор інкременту):");
        Test testA = new Test("Алгоритми", 3, 30);
        Test testB = new Test("Англійська", 6, 60);
 
        Console.WriteLine("Постфіксний (testA = testB++): ");
        Console.WriteLine($"До:\ntestA: {testA}\ntestB: {testB}");
        testA = testB++;
        Console.WriteLine($"Після:\ntestA: {testA}\ntestB: {testB}");
        Console.WriteLine(new string('-', 30));
 
        testA = new Test("Алгоритми", 3, 30);
        testB = new Test("Англійська", 6, 60);
        Console.WriteLine("Префіксний (testA = ++testB): ");
        Console.WriteLine($"До:\ntestA: {testA}\ntestB: {testB}");
        testA = ++testB;
        Console.WriteLine($"Після:\ntestA: {testA}\ntestB: {testB}\n");
 
        Console.WriteLine("#3.3 (неявне та явне перетворення типів): ");
        Test fromInt = 44;
        Console.WriteLine($"Test fromInt = 44: {fromInt}");
        int questions = (int)firstTest;
        Console.WriteLine($"int questions = (int)firstTest: {questions}\n");
        // int questionsBad = firstTest;
        
        Console.WriteLine("Завдання для всіх:");
        Point point = new Point(1, 2);
        point.Show();
    }
}

sealed class Test
{
    private string testName;
    private int questionsCount;
    private int maxScore;
 
    public string TestName { get { return testName; } }
    public int QuestionsCount { get { return questionsCount; } }
    public int MaxScore { get { return maxScore; } }
 
    public Test(string testName, int questionsCount, int maxScore)
    {
        this.testName = testName;
        this.questionsCount = questionsCount;
        this.maxScore = maxScore;
    }

    public static Test operator +(Test firstTest, Test secondTest)
    {
        return new Test(
            firstTest.testName, 
            firstTest.questionsCount + secondTest.questionsCount, 
            firstTest.maxScore + secondTest.maxScore
            );
    }

    public static Test operator ++(Test test)
    {
        return new Test(test.testName, test.questionsCount + 1, test.maxScore);
    }

    public static implicit operator Test(int questionsCount)
    {
        return new Test("Без назви", questionsCount, 0);
    }

    public static explicit operator int(Test test)
    {
        return test.questionsCount;
    }
 
    public override string ToString()
    {
        return $"Тест \"{testName}\", питань: {questionsCount}, макс. балів: {maxScore}";
    }
}

static class TestExtensions
{
    public static bool HasMinQuestions(this Test test, int minQuestions)
    {
        return test.QuestionsCount >= minQuestions;
    }
}
 
class Point
{
    int x;
    int y;
 
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
 
    public void Show()
    {
        Console.WriteLine("x=" + x + y);
        Console.WriteLine(x + y);
    }
}