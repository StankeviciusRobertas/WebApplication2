using WebApplication2.Models;

namespace WebApplication2.NewFolder
{
    public class BookDataBase
    {
        private static List<Book> bookList = new List<Book>
        {
            new Book(1, "The Catcher in the Rye", "J.D. Salinger"),
        new Book(2, "To Kill a Mockingbird", "Harper Lee"),
        new Book(3, "1984", "George Orwell"),
        new Book(4, "The Great Gatsby", "F. Scott Fitzgerald"),
        new Book(5, "Moby-Dick", "Herman Melville"),
        new Book(6, "Pride and Prejudice", "Jane Austen"),
        new Book(7, "The Lord of the Rings", "J.R.R. Tolkien"),
        new Book(8, "One Hundred Years of Solitude", "Gabriel García Márquez"),
        new Book(9, "The Hobbit", "J.R.R. Tolkien"),
        new Book(10, "Brave New World", "Aldous Huxley"),
        new Book(11, "The Chronicles of Narnia", "C.S. Lewis"),
        new Book(12, "The Shining", "Stephen King"),
        new Book(13, "Harry Potter and the Sorcerer's Stone", "J.K. Rowling"),
        new Book(14, "The Hitchhiker's Guide to the Galaxy", "Douglas Adams"),
        new Book(15, "The Alchemist", "Paulo Coelho")
        };

        public List<Book> GetAll()
        {
            return bookList;
        }
    }
}
