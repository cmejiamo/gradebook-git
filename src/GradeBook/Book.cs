//Pillars of OOP
//Encapsulation, to an object's ability to hide data and behavior that are not necessary to its user. Encapsulation enables a group of properties, methods and other members to be considered a single unit or object.
//Inheritance, defines a base class, 
    //DRY principle: Don't repeat yourself  
//Polymorphism, same type that can behave differently 

using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    //object is base type for everything in dotnet
    //first part of creating an evnet

    public class NamedObject //creating a base class //:Object is the ulimiate base class that other base classes inherit
    {
        public NamedObject(string name)
        {
            Name = name;
        }
        public string Name 
        {
            get;
            set;

        }
    }

    public interface IBook 
    {
        //interface
        void AddGrade(double grade);
        Statistics GetStatistics();
        String Name{ get;}
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class BookBase:NamedObject, IBook // interface
    {
        protected BookBase(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
        
    }

    public class DiskBook : BookBase
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
           using(var writer = File.AppendText($"{Name}.txt"))
           {
                writer.WriteLine(grade);
           }
           
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
           {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
           }
            return result;
            
        }
    }

    public class InMemoryBook:BookBase // this is a :inheritance relationship
    { 
        //handling event is adding method += 
        //raising event is invoking delegate
        public override event GradeAddedDelegate GradeAdded;
        
        //constructor that explicitly initializes grades
        // Needs same name as class
        // Cannot have a return type
        
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            //name field (upper) and name parameter(lower) differentiated by upper and lower case
            Name = name;
        }

        public List<double> grades;
        //when you have a public member you need uppercase 
        private string name;

        //public string Name
        //{
            //get; 
            //private set; 
            //private makes sure they will not have access to write to this property. Advantage of property over field.
        //}

        //readonly string category = "Science";
        //readonly useful to make sure there no other proprties or methods that can write into this field, unless in a constructor

        //public const string CATEGORY = "Science"; 
        //const value all upper case, typically naming convention
        //const useful to make sure there no other proprties or methods that can write into this field
        //to reference outside of book class, const field are treated like static members
        //cannot access static member via object reference, you access by using the type name aka Class.ConstName so Book.CATEGORY.
        //book.category will not work because it only stores object references

        
        //public string Name
        //{
            //get
            //{
            //    return name; 
            //}
            //set
            //{
            //    if (!String.IsNullOrEmpty(value))
            //    {
               
            // name = value;
               // }
                //value is an implicit varibale in set
           // }
        //}
        //instance member or method of type Book
        public void AddGrade(char Letter)
        {
            //method overloading, same  name inside of a type. Looks at parameter method(type variable) type to decided if name unique enough

            //switch loop, based on variable. case 'condition met':result;break;


           switch(Letter)
            {
                //use '' for char, user "" for string
                case 'A': AddGrade(90);
                break;

                case 'B': AddGrade(80);
                break;

                case 'C': AddGrade(70);
                break;
                //else equivalent, what happens if no cases are met
                default: AddGrade(0);
                break;
            }
       }

        public override void AddGrade(double grade)
        {
            //&& and , || or
            if(grade<=100 && grade >=0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else{

                //throw an exception object to deal with users giving you incorrect data
                //nameof allows you to not have to hard code error
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

 public override Statistics GetStatistics()
         {
             var result = new Statistics();
             //result.Average = 0.0;
            // result.High = double.MinValue;
            // result.Low = double.MaxValue;
           
             for (var index =0; index < grades.Count; index +=1)
             //For(variable of the index; condition must be true for code to run;after loop is run)
             {
                // if(grades[index]==42.1)
                 //{
                 //break; completely breaks out of loops   
                 //continue; go to the next iteration and continue executing loop
                 // }
                 //result.Average += grades[index];
                 //result.High = Math.Max(grades[index], result.High);
                 //result.Low = Math.Min(grades[index], result.Low);  
                     
                  result.Add(grades[index]);   
             }
             //result.Average /= grades.Count;

             
            
             return result;
            
        }

       // public Statistics GetStatistics2()
        // {
         //    var result = new Statistics();
           //  result.Average = 0.0;
             //result.High = double.MinValue;
             //result.Low = double.MaxValue;
           
           //do while, for each, if else statements can be used to accomplish the same thing
            //do while will allways execute at least once, while will check condition first

             //var index =0;
             //while(index < grades.Count)
             //{
               //  index += 1;
                 //result.Average += grades[index];
                 //result.High = Math.Max(grades[index], result.High);
                 //result.Low = Math.Min(grades[index], result.Low);  

             //}
             //condition must be true
             //result.Average /= grades.Count;

            
            
            // return result;
            
        //}

       
        //public Statistics GetStatistics1()
        // {
          //   var result = new Statistics();
          //   result.Average = 0.0;
           //  result.High = double.MinValue;
          //   result.Low = double.MaxValue;
           
           //  foreach (var grade in grades)
            // {
              //   result.Average += grade;
                // result.High = Math.Max(grade, result.High);
                 //result.Low = Math.Min(grade, result.Low);          
             //}
             //result.Average /= grades.Count;
            
            // return result;
            
        //}


        // public void ShowStatistics()
        // {
        //     var avgGrade = 0.0;
        //     var highGrade = double.MinValue;
        //     var lowGrade = double.MaxValue;        
        
        //     foreach (var number in grades)
        //     {
        //         avgGrade += number;
        //         highGrade = Math.Max(number, highGrade);
        //         lowGrade = Math.Min(number, lowGrade);          
        //     }
        //     avgGrade /= grades.Count;
            
        //     System.Console.WriteLine($"The average grade is {avgGrade:N2}.");
        //     System.Console.WriteLine($"The highest grade is {highGrade:N2}.");
        //     System.Console.WriteLine($"The lowest grade is {lowGrade:N2}.");

        // }
       
        //add a field, inside a class, outside main method
        //if in main method then only a local variable, so if outside can be called any time class called
       

    }
    
}