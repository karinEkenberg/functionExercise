namespace functionExercise
{
    internal class Program
    {
        public class Factorial
        {
            public static int FactTable(int num)
            {
                if (num < 0)
                {
                    throw new ArgumentException(message: $"The factorial is defined for non-negative integers only. Input: {num}", paramName: nameof(num));
                }
                else if (num == 0)
                {
                    return 1;
                }
                else
                {
                    return num * FactTable(num - 1);
                }
            }

            public static void RunFact(int num)
            {
                Console.Clear();
                for (int i = -2; i <= num; i++)
                {
                    try
                    {
                        Console.WriteLine($"{i}! = {FactTable(i):N0}");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine($"{i}! is  to big for a 32-bit integer.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{i}! throws {ex.GetType()}: {ex.Message}");
                    }
                }

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("What number do you want to calculate factorial on?");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                Factorial.RunFact(num);
            }
        }
    }
}
