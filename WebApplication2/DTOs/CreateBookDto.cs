using static WebApplication2.Models.Book;
using WebApplication2.Models;

namespace WebApplication2.DTOs
{
    public class CreateBookDto
    {
        public int Id { get; set; }
        public CoverType Cover { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }

        //property for DateTime conversion
        public DateTime PublishDate => new DateTime(PublishYear, 1, 1);

        public static Book ToModel(CreateBookDto book)
        {
            return new Book
            {
                Id = book.Id,
                Cover = book.Cover,
                Title = book.Title,
                Author = book.Author,
                PublishYear = book.PublishYear,
            };
        }
    }
}
