using static WebApplication2.Models.Book;
using WebApplication2.Models;

namespace WebApplication2.DTOs
{
    public class FilterBookRequestDto
    {
        public CoverType Cover { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        

        public FilterBookRequestDto(Book book)
        {
            Cover = book.Cover;
            Title = book.Title;
            Author = book.Author;
        }
    }
}
