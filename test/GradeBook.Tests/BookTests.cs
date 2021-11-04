using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesGrade() 
        {
            //arrange
            var book = new Book("");
            book.AddGrade(85.6);
            book.AddGrade(90.5);
            book.AddGrade (77.3);

            //act
          var result =  book.GetStatistics();
            

            //assert
            Assert.Equal(84.5, result.Average,1);
            Assert.Equal(90.5, result.High,1);
            Assert.Equal(77.3, result.Low,1);
            Assert.Equal('B', result.Letter);
           
           
           //var y =2;
           // var actual = x*y;
           //var expected = 7;
           //Assert.Equals(expected, actual);

        }
    }
}
