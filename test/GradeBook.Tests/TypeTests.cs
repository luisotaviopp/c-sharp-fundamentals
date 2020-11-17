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

			log = ReturnMessage;

			string result = log("Hello!");

			Assert.Equal("Hello!", result);
		}

		string ReturnMessage(string message) {
			return message;
		}

		[Fact]
		public void CSharpCanPassByRef()
		{
			var book1 = GetBook("book 1");
			RefBookSetName(ref book1, "New Name");

			Assert.Equal("New Name", book1.GetName());
		}

		private void RefBookSetName(ref Book book, string name) {
			book = new Book(name);
		}

		[Fact]
		public void CSharpIsPassingByValue()
		{
			var book1 = GetBook("book 1");
			GetBookSetName(book1, "New Name");

			Assert.Equal("book 1", book1.GetName());
		}

		private void GetBookSetName(Book book, string name) {
			book = new Book(name);
		}

		[Fact]
		public void GetSetNameFromReference()
		{
			var book1 = GetBook("book 1");
			SetName(book1, "New Name");

			Assert.Equal("New Name", book1.GetName());
		}

		private void SetName(Book book, string name) {
			book.SetName(name);
		}

		[Fact]
		public void GetBooksCanReferenceDifferentMethods()
		{
			var book1 = GetBook("book 1");
			var book2 = GetBook("book 2");

			Assert.Equal("book 1", book1.GetName());
			Assert.Equal("book 2", book2.GetName());
			Assert.NotSame(book1, book2);
		}

		[Fact]
		public void TwoVarsCanReferenceSameObject()
		{
			var book1 = GetBook("book 1");
			var book2 = book1;

			Assert.Equal("book 1", book1.GetName());
			Assert.Equal("book 1", book2.GetName());

			Assert.Same(book1, book2);
		}

		Book GetBook(string name)
		{
			return new Book(name);
		} 
	}
}
