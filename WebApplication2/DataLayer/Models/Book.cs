namespace WebApplication2.Models
{
    public class Book
    {
        public Book()
        {
        }

        public Book(int id, CoverType cover, string title, string author, int publishYear)
        {
            Id = id;
            Cover = cover;
            Title = title;
            Author = author;
            PublishYear = publishYear;
        }

        public int Id { get; set; }
        public CoverType Cover { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }

        public enum CoverType
        {
            Paperback,
            Hardcover,
            eBook
        }
    }
}
