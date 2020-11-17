using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            InMemoryBook book = new InMemoryBook("Learning C#");

            // book.AddGrade(5);
            // book.AddGrade(5);
            // book.AddGrade(10);
            // book.AddGrade(10);

            EnterGrades(book);

            Statistics result = book.GetStatistics();

            Console.WriteLine($"Sum = {result.sum}");
            Console.WriteLine($"Avg = {result.average:N2}");
            Console.WriteLine($"Score = {result.letter}");
            Console.WriteLine($"Name = {book.GetName()}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                System.Console.WriteLine("Enter a grade or press 'q' to quit.");

                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("----------------------------------------");
                }
            }
        }
    }
}
