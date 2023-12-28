using WebApplication2.DTOs;
using WebApplication2.FakeDatabase;
using WebApplication2.Models;

namespace WebApplication2.DataLayer.Repositories
{
    public interface IBooksRepository
    {
        FilterBookRequestDto BookExists(int id);
        void DeleteBook(int id);
        List<Book> GetAll();
        Book GetById(int id);
        void InsertBook(Book book);
        void UpdateBook(UpdateBookDto book);
        void UpdateTitle(int id, string title);
    }
    public class BooksRepository : IBooksRepository
    {
        private readonly List<Book> _books;

        public BooksRepository()
        {
            _books = new BookDataBase().GetAll();
        }
        public List<Book> GetAll()
        {
            return _books;
        }

        public Book GetById(int id)
        {
            return _books.Find(t => t.Id == id);
        }
        public void InsertBook(Book book)
        {
            _books.Add(book);
            // context.SaveChanges(); jeigu tai butu db
        }

        public void UpdateBook(UpdateBookDto book)
        {
            var bookFromDb = _books.FirstOrDefault(b => b.Id == book.Id);

            if (bookFromDb == null)
            {
                throw new ArgumentException($"Book with ID {book.Id} was not found in database");
            }

            bookFromDb.Author = book.Author;
            bookFromDb.Title = book.Title;
            // context.SaveChanges(); jeigu tai butu db
        }

        public void DeleteBook(int id)
        {
            var bookFromDb = _books.FirstOrDefault(b => b.Id == id);

            if (bookFromDb == null)
            {
                return;
            }

            _books.Remove(bookFromDb);
        }

        public void UpdateTitle(int id, string title)
        {
            var bookFromDb = _books.FirstOrDefault(b => b.Id == id);

            if (bookFromDb == null)
            {
                throw new ArgumentException($"Book with ID {id} was not found in database");
            }

            bookFromDb.Title = title;
        }

        public FilterBookRequestDto BookExists(int id)
        {
            var book = GetById(id);

            if (book != null)
            {
                return new FilterBookRequestDto(book);
            }
            else
            {
                return null;
            }
        }
    }
}
