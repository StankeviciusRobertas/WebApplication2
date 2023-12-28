using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication2.Models;
using WebApplication2.FakeDatabase;
using WebApplication2.DTOs;
using WebApplication2.DataLayer.Repositories;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        
        public BookController(IBooksRepository repository)
        {
            _booksRepository = repository;
        }

        [HttpGet]
        public IEnumerable<GetBookDto> GetAll()
        {
            var data = _booksRepository.GetAll();
            return data.Select(t => new GetBookDto(t));
        }

        [HttpGet("{id}")]
        public GetBookDto GetSingleBook(int id)
        {
            var data = _booksRepository.GetById(id);
            return new GetBookDto(data);
        }

        [HttpGet("exists/{id}")]
        public IActionResult BookExists(int id)
        {
            var bookInfo = _booksRepository.BookExists(id);

            if (bookInfo != null)
            {
                return Ok(bookInfo);
            }
            else
            {
                return NotFound($"Book with Id {id} not found");
            }
        }

        //[HttpGet("pagedlist/{pageNum}/{pageSize}")]
        //public IEnumerable<Book> GetPagedList(int pageNum, int pageSize)
        //{
        //    var database = new BookDataBase();

        //    var data = database.GetAll().Skip((pageNum - 1) * pageSize).Take(pageSize);
        //    return data;
        //}

        //[HttpGet("sortedlist")]
        //public IEnumerable<Book> GetSortedBookList()
        //{
        //    var database = new BookDataBase();
        //    var data = database.GetAll().OrderBy(b => b.Title);
        //    return data;
        //}

        /// <summary>
        /// Iraso nauja Book irasa i duomenu baze
        /// </summary>
        /// <param name="book">Book objektas</param>
        [HttpPost]
        public void CreateBook(CreateBookDto book)
        {
            Book model = CreateBookDto.ToModel(book);
            //return _booksRepository.InsertBook(model);
        }

        //TODO
        [HttpPut("{id}")]
        public void UpdateBook(UpdateBookDto book)
        {
            _booksRepository.UpdateBook(book);
        }

        [HttpDelete]
        public void DeleteBook(int id)
        {
            _booksRepository.DeleteBook(id);
        }

        //[HttpPut("updateTitle")]
        //public void UpdateBookTitle(BookWithTitle book)
        //{
        //    var database = new BookDataBase();
        //    database.UpdateTitle(book.Id, book.Title);
        //}



    }
}
