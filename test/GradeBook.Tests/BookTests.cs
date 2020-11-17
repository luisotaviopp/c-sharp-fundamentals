using System;
using Xunit;
using GradeBook;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStats()
        {
            // arrange
            float x = 6f;
            float y = 4f;

            // act
            float actual = x + y;
            float expected = 10f;

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestName()
        {
            //Given
            Book book = new Book("LEarning DataStructures with Python");
            book.AddGrade(10);
            book.AddGrade(10);
            book.AddGrade(50);
            
            Statistics stats = book.GetStatistics();
            //When
            
            //Then
        }
    }
}
