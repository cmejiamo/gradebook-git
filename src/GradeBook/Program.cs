using System;
using System.Collections.Generic;

namespace GradeBook
{
    
    class Program

    {
      
        static void Main(string[] args)

        {



            // adding method from another class 
            var book = new InMemoryBook("Catalina's Gradebook");

            //adding an event
            // book.GradeAdded += OnGradeAdded;
            // book.GradeAdded += OnGradeAdded;
            //  book.GradeAdded -= OnGradeAdded;
            //  book.GradeAdded += OnGradeAdded;

            //hard code grades directly into program
            //book.AddGrade(89.1);
            //book.AddGrade(99.1);
            //book.AddGrade(77.5);

            //highlighted and select extract method which created the following pointing to the new method below, way to refactor
            EnterGrades(book);

            var stats = book.GetStatistics();

            System.Console.WriteLine(InMemoryBook.CATEGORY);
            System.Console.WriteLine($"For the book named {book.Name}.");
            System.Console.WriteLine($"The average grade is {stats.Average:N2}.");
            System.Console.WriteLine($"The highest grade is {stats.High:N2}.");
            System.Console.WriteLine($"The lowest grade is {stats.Low:N2}.");
            System.Console.WriteLine($"The letter grade is {stats.Letter}.");




            //create a list using System.Collections.Generic, find average, find max, find min print list;
            // var grades2 = new List <double>(){55.6,91.3,25.3};
            // grades2.Add(98.2);

            // var avgGrade = 0.0;
            // var highGrade = double.MinValue;
            // var lowGrade = double.MaxValue;        

            // foreach (var number in grades2)
            // {
            //     avgGrade += number;
            //     highGrade = Math.Max(number, highGrade);
            //     lowGrade = Math.Min(number, lowGrade);
            // }
            // avgGrade /= grades2.Count;

            // System.Console.WriteLine($"The average grade is {avgGrade:N2}.");
            // System.Console.WriteLine($"The highest grade is {highGrade:N2}.");
            // System.Console.WriteLine($"The lowest grade is {lowGrade:N2}.");


            // How to print in the console
            // Console.WriteLine("Hello Catalina");


            //  Create a variable and assign a type
            //    double x= 15.3;
            //    var y = 16.2;
            //    var z = x+y;
            //    Console.WriteLine(z);


            // create an array
            // double[] numbers = new double[5] {2,3,4,5,6};


            // print an array  
            // foreach (var i in numbers) {
            //     System.Console.WriteLine(i);
            // }

            //create an array and apply an expression
            // var grades = new [] {80.2,85.6,96.3};
            // var result = 0.0;
            // foreach (var i in grades)
            // {
            //     result += i;
            // }
            // System.Console.WriteLine(result);

            //create a list and add using System.Collections.Generic;
            // var grades1 = new List <double>(){55.6,91.3,25.3};
            // grades1.Add(98.2);
            // var listresult = 0.0;
            // foreach (var i in grades1)
            // {
            //     listresult += i;
            // }
            // System.Console.WriteLine(listresult);

            //create a list using System.Collections.Generic, find average, print list;
            // var grades2 = new List <double>(){55.6,91.3,25.3};
            // grades2.Add(98.2);
            // var listresult2 = 0.0;

            // foreach (var i in grades2)
            // {
            //     listresult2 += i;
            // }
            // listresult2 /= grades2.Count;
            // System.Console.WriteLine($"The average grade is {listresult2:N2} ex1");


            //create and if/else statement     
            // if(args.Length>0)
            // {
            //     Console.WriteLine($"Hello, {args[0]}!");
            // }
            // else 
            // {
            //     Console.WriteLine("Hello!");
            // }
        }

        private static void EnterGrades(InMemoryBook book)
        {
            while (true)
            {
                System.Console.WriteLine("Enter grade or 'q' to quit.");
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
                //if you catch exception, the runtime will not crash or be terminated. 
                //Perviously user error caused program to crash
                //you can have multiple catch statements for same try
                catch (ArgumentException error)
                {
                    Console.WriteLine(error.Message);

                }
                catch (FormatException error)
                {
                    Console.WriteLine(error.Message);

                }
                //you can execute what is in the finally block regradless if above is correct or with errors
                finally
                {
                    Console.WriteLine("");
                }



                //book.AddLetterGrade(grade);
            }
            //get user input to add grades
        }
        //event
        // static void OnGradeAdded(object sender, EventArgs e)
        //{
        //    System.Console.WriteLine("A grade was added"); //delegate
        //}
    }
}