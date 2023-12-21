using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.NewFolder;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            var database = new ToDoFakeDatabase();
            var data = database.GetAll();
            return data;
        }

        [HttpGet("{id}")]
        public TodoItem GetById(int id)
        {
            var database = new ToDoFakeDatabase();
            var data = database.GetAll().Find(t => t.Id == id);
            return data;
        }

        [HttpGet("filterBy/{typeName}")]
        public IEnumerable<TodoItem> GetAllFilteredByType(string typeName)
        {
            var database = new ToDoFakeDatabase();
            var data = database.GetAll().Where(t => t.Type == typeName);
            return data;
        }
    }
}
