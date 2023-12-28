using WebApplication2.DTOs;
using WebApplication2.FakeDatabase;
using WebApplication2.Models;

namespace WebApplication2.DataLayer.Repositories
{
    public interface ITodoRepository
    {
        long Add(TodoItem item);
        void Delete(int key);
        List<TodoItem> GetAll();
        TodoItem GetById(int key);
        void Update(TodoItem item);
    }

    public class TodoRepository : ITodoRepository
    {
        private readonly List<TodoItem> _database;
        

        public TodoRepository()
        {
            _database = new ToDoFakeDatabase().GetAll();
        }

        public List<TodoItem> GetAll()
        {
            return _database;
        }

        public TodoItem GetById(int key)
        {
            return _database.Find(t => t.Id == key);
        }

        public long Add(TodoItem item)
        {
            var newId = _database.Max(t => t.Id) + 1;
            item.Id = newId;
            _database.Add(item);
            return newId;
        }

        public void Update(TodoItem item)
        {
            var index = _database.FindIndex(t => t.Id == item.Id);
            _database[index] = item;
        }

        public void Delete(int key)
        {
            var index = _database.FindIndex(t => t.Id == key);
            _database.RemoveAt(index);
        }
    }
}
