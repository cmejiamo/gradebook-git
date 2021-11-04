using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage); 
    public class TypeTests
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;
            //log = new WriteLogDelegate(ReturnMessage()); same as below
            log = ReturnMessage;
            var result = log("Hello");
            Assert.Equal("Hello1",result);

        }

        string ReturnMessage(string message)
        {
            return message;
        }
        Book GetBook(string name)
        {
            return new Book(name);
            //dotnet acts like garbage collector
            //frees up memory, knows when variable is no longer referenced or out of scope
        }

        public class person
        {
            //class is a reference type
            //most common
        }

        public struct point
        {
            //struct is a value type
            //faster, takes less memory
            //not common, rare cases

            //place curser on type identifier, fn12 then you can see metadata 
            //and see if refernece or value type 
        }

[Fact]
//mark as '[Fact]' when testing
//Assert.Equal(Expected result, Actual or Variabel result)
//in command line first 'dotnet build' then 'dotnet test'
        public void StringRefTypeButBehaveLikeValueTypes()
        {
            //String is a reference type that behaves like a value type
            string name= "catalina";
            var upper = MakeUpperCase(name); 
            Assert.Equal("CATALINA",upper);
            //Assert.Equal(Expected result, Actual or Variabel result)
             

        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
            //change to uppercase, to return upper reference type must be string
            //you pass parameter by value
        }

    [Fact]
    public void ValueTypesAlsoPassByValue()
    {
        var x= GetInt1();
        SetInt1(x);

        Assert.Equal(3,x);
        //value of x will not change
    }

    private int GetInt1()
    {
        return 3;
    }

       private void SetInt1(int z)
    {
        z = 42;
    }

    [Fact] 
    public void ValueTypesAlsoPassByRef()
    {
        var x= GetInt();
        SetInt(ref x);

        Assert.Equal(33,x);
        //Value of x will change with ref to the variable x
    }

    private int GetInt()
    {
        return 3;
    }

       private void SetInt(ref int z)
    {
        z = 33;
    }


       [Fact]
    public void CSharpIsPassByOut() 
        {
           var book1= GetBook("Book1");
           GetBookSetName(out book1, "New Name");

          Assert.Equal("New Name", book1.Name);
          //Above is True, because new book object below allows access to the reference (location where value stored), it can be changed 
        }
        private void GetBookSetName(out Book book, string name)
        //out vs ref, out parameter must be initialized otherwise there will be an error. Ref does not need to be intialized but it's use is rare
        {
            book =new Book(name);

        }

        [Fact]
    public void CSharpIsPassByRef() 
        {
           var book1= GetBook("Book1");
           GetBookSetName1(ref book1, "New Name");

          Assert.Equal("New Name", book1.Name);
          //Above is True, because new book object below allows access to the reference (location where value stored), it can be changed 
        }
        private void GetBookSetName1(ref Book book, string name)
        {
            book =new Book(name);

        }
   

        [Fact]
        public void CSharpIsPassByValue() 
        {
           var book1= GetBook("Book1");
           GetBookSetName(book1, "New Name");

          // Assert.Equal("New Name", book1.Name);
          //Above is false, because new book object below does not change the value.
           Assert.Equal("Book1", book1.Name);
           
        }

        private void GetBookSetName(Book book, string name)
        {
            book =new Book(name);

        }

         [Fact]
        public void CanSetNameFromReference() 
        {
           var book1= GetBook("Book1");
           SetName(book1, "New Name");

           Assert.Equal("New Name", book1.Name);
           
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;

        }

        [Fact]
        public void GetBookReturnsDifferentObjects() 
        {
           var book1= GetBook("Book1");
           var book2= GetBook("Book2");

           Assert.Equal("Book1", book1.Name);
           Assert.Equal("Book2", book2.Name);   

        }

        [Fact]
        public void TwoVarsCanReferenceSameObject() 
        {
           var book1= GetBook("Book1");
           //value that is inside of book1
           var book2= book1;

           Assert.Same(book1, book2);   
           Assert.True(Object.ReferenceEquals(book1,book2)); 
           //Two variables can reference the same object True passes, False fails
           //Assert.False(Object.ReferenceEquals(book1,book2)); 

        }

        
    }
}
