char selection;

Console.Write("Do you want to test Radom in Range? [y/n] ");
char input = Console.ReadKey().KeyChar;
if (input == 'y')
{
    TestRandomInRange();
}

do
{
    Console.Clear();
    Console.WriteLine("What do you want to execute?");
    Console.WriteLine("============================");
    Console.WriteLine();
    Console.WriteLine("0. Calculate Circle Area");
    Console.WriteLine("1. Random in Range");
    Console.WriteLine("2. To FizzBuzz");
    Console.WriteLine("3. Fibonacci by Index");
    Console.WriteLine("4. Ask for Number in Range");
    Console.WriteLine("5. Is palindrome?");
    Console.WriteLine("6. Is palindrome? (advanced)");
    Console.WriteLine("7. Chart Bar");
    Console.WriteLine("8. Count Smiling Faces");
    Console.WriteLine("9. Highest in Geometric Sequence");
    Console.WriteLine("q to Quit");
    selection = Console.ReadKey(true).KeyChar;

    if (selection != 'q')
    {
        Console.Clear();
        switch (selection)
        {
            case '0': RunCalculateCircleArea(); break;
            case '1': RunRandomInRange(); break;
            case '2': RunToFizzBuzz(); break;
            case '3': RunFibonacciByIndex(); break;
            case '4': RunAskForNumberInRange(); break;
            case '5' or '6': RunIsPalindrome(); break;
            case '7': RunChartBar(); break;
            case '8': RunCountSmilingFaces(); break;
            case '9': RunHighestInGeometricSequence(); break;
            default: break;
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
}
while (selection != 'q');

#region Calculate Circle Area
void RunCalculateCircleArea()
{
    Console.Write("Enter radius:");
    var radius = double.Parse(Console.ReadLine()!);
    var area = CalculateCircleArea(radius);
    Console.WriteLine($"Area of circle with radius {radius} is {area}");
}

double CalculateCircleArea(double radius)
{
    return radius * radius * Math.PI;
}
#endregion

#region Random In Range
void RunRandomInRange()
{
    Console.Write("Enter a minimum: ");
    int min = int.Parse(Console.ReadLine()!);
    Console.Write("Enter a maximum: ");
    int max = int.Parse(Console.ReadLine()!);
    Console.WriteLine($"The random number between {min} and {max} is {RandomInRange(min, max)}");
}

int RandomInRange(int min, int max)
{
    return Random.Shared.Next(min, max + 1);
}

void TestRandomInRange()
{
    int zero = 0, one = 0, two = 0;
    for (int i = 0; i <= 1_000_000; i++)
    {
        int number = RandomInRange(0, 2);
        switch (number)
        {
            case 0: zero++; break;
            case 1: one++; break;
            case 2: two++; break;
        }
    }
    Console.WriteLine($"Zeros: {zero}, Ones: {one}, Twos: {two}");
    Thread.Sleep(10_000);
}
#endregion

#region To FizzBuzz
void RunToFizzBuzz()
{
    Console.Write("Enter a number: ");
    int value = int.Parse(Console.ReadLine()!);
    Console.WriteLine($"{ToFizzBuzz(value)}");
}

string ToFizzBuzz(int value)
{
    if (value % 3 == 0 && value % 5 == 0) { return "FizzBuzz"; }
    else if (value % 3 == 0) { return "Fizz"; }
    else if (value % 5 == 0) { return "Buzz"; }
    else return value.ToString();
}

#endregion

#region Fibonacci By Index
void RunFibonacciByIndex()
{
    Console.Write("Enter an index: ");
    int input = int.Parse(Console.ReadLine()!);
    Console.WriteLine($"Fibonacci-number: {FibonacciByIndex(input)}");
}

int FibonacciByIndex(int input)
{
    int value0 = 0, value1 = 1, result = 0;
    if (input == 0) { return 0; }
    if (input == 1) { return 1; }

    for (int i = 2; i <= input; i++)
    {
        result = value0 + value1;
        value0 = value1;
        value1 = result;
    }
    return result;
}
#endregion

#region Ask For Number In Rage
void RunAskForNumberInRange()
{
    int i = AskForNumberInRange(5, 10);
}

int AskForNumberInRange(int min, int max)
{
    int input;
    Console.WriteLine($"Enter a number between {min} and {max}: ");
    do
    {
        input = int.Parse(Console.ReadLine()!);
        if (input < min)
        {
            Console.WriteLine($"Wrong number. You input is too low. The minimum is {min}. Try again!");
        }
        if (input > max)
        {
            Console.WriteLine($"Wrong number. You input is too high. The maximum is {max}. Try again!");
        }
    } while (input < min || input > max);
    Console.WriteLine("Thank you, your input is valid.");
    return input;
}
#endregion 

#region Is Palindrome
void RunIsPalindrome()
{
    Console.Write("Enter a text to check if it's a palindrome: ");
    string input = Console.ReadLine()!;

    Console.Write("The text is ");
    if (!IsPalindrome(input))
    {
        Console.Write("not ");
    }
    Console.WriteLine("a palindrome.");
}

bool IsPalindrome(string text)
{
    {
        if (text == "")
        {
            return false;
        }

        text = text
            .Replace(" ", "")
            .Replace(",", "")
            .Replace("-", "")
            .ToLower();

        for (int i = 0; i < text.Length / 2; i++)
        {
            if (text[i] != text[text.Length - 1 - i])
            {
                return false;
            }
        }
        return true;
    }
}
#endregion

#region Chart Bar
void RunChartBar()
{
    System.Console.Write("Enter a double value: ");
    double value = double.Parse(Console.ReadLine()!);
    Console.WriteLine(ChartBar(value));
}

string ChartBar(double number)
{
    if (number < 0 || number > 1) { return ""; }
    else if (number is >= 0.0 and < 0.1) { return ".........."; }
    else if (number is >= 0.1 and < 0.2) { return "o........."; }
    else if (number is >= 0.2 and < 0.3) { return "oo........"; }
    else if (number is >= 0.3 and < 0.4) { return "ooo......."; }
    else if (number is >= 0.4 and < 0.5) { return "oooo......"; }
    else if (number is >= 0.5 and < 0.6) { return "ooooo....."; }
    else if (number is >= 0.6 and < 0.7) { return "oooooo...."; }
    else if (number is >= 0.7 and < 0.8) { return "ooooooo..."; }
    else if (number is >= 0.8 and < 0.9) { return "oooooooo.."; }
    else if (number is >= 0.9 and < 1) { return "ooooooooo."; }
    else { return "oooooooooo"; }
}
#endregion

#region Count smiling faces
void RunCountSmilingFaces()
{
    Console.Write("Enter a text: ");
    string text = Console.ReadLine()!;
    Console.WriteLine($"This text contains {CountSmilingFaces(text)} smiling faces.");
}

int CountSmilingFaces(string inputText)
{
    int count = 0;

    for (int i = 0; i < inputText.Length - 2; i++)
    {
        if (inputText.Substring(i, 3) == ":-)")
        {
            count++;
        }
    }
    return count;
}

#endregion

#region Highest In Geometric Sequence
void RunHighestInGeometricSequence()
{
    Console.Write("Enter a: ");
    double a = double.Parse(Console.ReadLine()!);
    Console.Write("Enter r: ");
    double r = double.Parse(Console.ReadLine()!);
    Console.Write("Enter a maximum: ");
    double maximum = double.Parse(Console.ReadLine()!);

    Console.WriteLine($"The highest element lower than the maximum is {HighestInGeometricSequence(a, r, maximum)}.");

}

double HighestInGeometricSequence(double a, double r, double maximum)
{
    double current = 0;
    for (int i = 0; current < maximum; i++)
    {
        current = a * Math.Pow(r, i);
    }
    return current / r;
}
#endregion

