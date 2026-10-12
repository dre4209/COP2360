using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first number (numerator): ");
            string input1 = Console.ReadLine() ?? "";

            Console.Write("Enter the second number (denominator): ");
            string input2 = Console.ReadLine() ?? "";

            DivideNumbers(input1, input2);

            Console.WriteLine("\nProgram finished.");
        }

        // Takes two strings, converts them to integers and divides them
        static void DivideNumbers(string num1, string num2)
        {
            try
            {
                int numerator = Convert.ToInt32(num1);
                int denominator = Convert.ToInt32(num2);

                int result = Divide(numerator, denominator);

                Console.WriteLine($"Result: {numerator} / {denominator} = {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: Please enter whole numbers only (no letters, symbols or decimals).");
                Console.WriteLine($"Details: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: You cannot divide by zero.");
                Console.WriteLine($"Details: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error: That number is too large or too small for an integer.");
                Console.WriteLine($"Valid range is {int.MinValue} to {int.MaxValue}.");
                Console.WriteLine($"Details: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
                Console.WriteLine($"Type: {ex.GetType().Name}");
                Console.WriteLine($"Details: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Division attempt complete.");
            }
        }

        // Performs the actual division
        static int Divide(int a, int b)
        {
            return a / b;
        }
    }
}