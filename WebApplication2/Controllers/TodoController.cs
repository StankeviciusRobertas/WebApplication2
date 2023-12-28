using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.FakeDatabase;
using WebApplication2.DTOs;
using WebApplication2.DataLayer.Repositories;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _repository;
        private readonly IToDoEmailService _emailService;

        public TodoController(ITodoRepository repository, IToDoEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        [HttpGet]
        public IEnumerable<GetToDoItemDto> GetAll()
        {
            //var database = new ToDoFakeDatabase(); // toks budas yra negeras, nes servisam naudoti new negalim
            var data = _repository.GetAll();
            return data.Select(t => new GetToDoItemDto(t));
        }

        [HttpGet("{id}")]
        public GetToDoItemDto GetById(int id)
        {
            var data = _repository.GetById(id);
            return new GetToDoItemDto(data);
        }

        /// <summary>
        /// Iraso nauja todo irasa i duomenu baze ir issiuncia emaila apie tai
        /// </summary>
        /// <param name="req">todo item objektas</param>
        /// <returns>grazina naujai sukurto iraso id</returns>
        [HttpPost]
        public long Post(CreateToDoItemDto req)
        {
            //var model = (TodoItem)req;
            //return _repository.Add(model);
            TodoItem model = CreateToDoItemDto.ToModel(req);
            _emailService.TrySendEmail("kazkam@example.com", model);
            return _repository.Add(model);
        }

        

        // front-end (javascript fetch, dirba su dto) -> controller (gauna dto, ir is dto daro modeli) ->
        // -> repository (modeli) -> database
    }
}
