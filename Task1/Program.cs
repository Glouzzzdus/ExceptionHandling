using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.Write("Enter your text (Enter to exit): ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new Exception("Input must be not empty!");
                    }

                    char firstChar = input[0];
                    Console.WriteLine($"First character: {firstChar}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}