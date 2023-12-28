using WebApplication2.Models;
using static WebApplication2.Models.Book;

namespace WebApplication2.FakeDatabase
{
    public class BookDataBase
    {
        private static List<Book> bookList = new List<Book>
        {
            new Book(1, CoverType.Hardcover, "The Catcher in the Rye", "J.D. Salinger", 1951),
            new Book(2, CoverType.Paperback, "To Kill a Mockingbird", "Harper Lee", 1960),
            new Book(3, CoverType.eBook, "1984", "George Orwell", 1949),
            new Book(4, CoverType.Paperback, "The Great Gatsby", "F. Scott Fitzgerald", 1925),
            new Book(5, CoverType.Hardcover, "Moby-Dick", "Herman Melville", 1851),
            new Book(6, CoverType.Paperback, "Pride and Prejudice", "Jane Austen", 1813),
            new Book(7, CoverType.Hardcover, "The Lord of the Rings", "J.R.R. Tolkien", 1954),
            new Book(8, CoverType.Paperback, "One Hundred Years of Solitude", "Gabriel García Márquez", 1967),
            new Book(9, CoverType.eBook, "The Hobbit", "J.R.R. Tolkien", 1937),
            new Book(10, CoverType.Hardcover, "Brave New World", "Aldous Huxley", 1932),
            new Book(11, CoverType.Paperback, "The Chronicles of Narnia", "C.S. Lewis", 1950),
            new Book(12, CoverType.Hardcover, "The Shining", "Stephen King", 1977),
            new Book(13, CoverType.Paperback, "Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 1997),
            new Book(14, CoverType.eBook, "The Hitchhiker's Guide to the Galaxy", "Douglas Adams", 1979),
            new Book(15, CoverType.Paperback, "The Alchemist", "J.R.R. Tolkien", 1988)
    };

        public List<Book> GetAll()
        {
            return bookList;
        }

        public void InsertBook(Book book)
        {
            bookList.Add(book);
            // context.SaveChanges(); jeigu tai butu db
        }

        public void UpdateBook(Book book)
        {
            var bookFromDb = bookList.FirstOrDefault(b => b.Id == book.Id);

            if (bookFromDb == null)
            {
                throw new ArgumentException($"Book with ID {book.Id} was not found in database");
            }

            bookFromDb.Author = book.Author;
            bookFromDb.Title = book.Title;
            // context.SaveChanges(); jeigu tai butu db
        }

        public void RemoveBook(int id)
        {
            var bookFromDb = bookList.FirstOrDefault(b => b.Id == id);

            if (bookFromDb == null)
            {
                return;
            }

            bookList.Remove(bookFromDb);
        }

        public void UpdateTitle(int id, string title)
        {
            var bookFromDb = bookList.FirstOrDefault(b => b.Id == id);

            if (bookFromDb == null)
            {
                throw new ArgumentException($"Book with ID {id} was not found in database");
            }

            bookFromDb.Title = title;
        }
    }
}
