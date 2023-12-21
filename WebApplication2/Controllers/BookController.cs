using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication2.Models;
using WebApplication2.NewFolder;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet("/api/mybooks/list")]
        public IEnumerable<Book> GetAll()
        {
            var database = new BookDataBase();
            var data = database.GetAll().Take(10);
            return data;
        }

        [HttpGet("/api/mybooks/single/{id}")]
        public Book GetSingleBook(int id)
        {
            var database = new BookDataBase();
            var data = database.GetAll().Find(b => b.Id == id);
            return data;
        }

        [HttpGet("/api/mybooks/pagedlist/{pageNum}")]
        public IEnumerable<Book> GetPagedList(int pageNum)
        {
            var database = new BookDataBase();
            var pageSize = 10;

            if (pageNum == 1)
            {
                var data = database.GetAll().Take(pageSize);
                return data;
            }
            else if (pageNum == 2)
            {
                var data = database.GetAll().Skip(pageSize).Take(pageSize);
                return data;
            }
            else
            {
                return Enumerable.Empty<Book>();
            }
        }

        [HttpGet("/api/mybooks/sortedlist")]
        public IEnumerable<Book> GetSortedBookList()
        {
            var database = new BookDataBase();
            var data = database.GetAll().OrderBy(b => b.Title);
            return data;
        }

    }
}
