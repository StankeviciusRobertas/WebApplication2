﻿using WebApplication2.Models;
using static WebApplication2.Models.Book;

namespace WebApplication2.DTOs
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string CoverType { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }

        //property for DateTime conversion
        public DateTime PublishDate => new DateTime(PublishYear, 1, 1);

        public GetBookDto(Book book)
        {
            Id = book.Id;
            CoverType = book.Cover.ToString();
            Title = book.Title;
            Author = book.Author;
            PublishYear = book.PublishYear;
        }
    }
}
