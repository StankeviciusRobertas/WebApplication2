using WebApplication2.Models;

namespace WebApplication2.FakeDatabase
{
    public class ToDoFakeDatabase
    {
        private static List<TodoItem> todoList = new List<TodoItem>
        {
            new TodoItem(1, "Work", "Complete assignment", DateTime.Parse("2024-01-10"), "user4"),
            new TodoItem(2, "Work", "Visit doctor", DateTime.Parse("2024-01-12"), "user2"),
            new TodoItem(3, "Other", "Buy groceries", DateTime.Parse("2023-12-20"), "user2"),
            new TodoItem(4, "Work", "Visit doctor", DateTime.Parse("2023-12-31"), "user5"),
            new TodoItem(5, "Work", "Visit doctor", DateTime.Parse("2023-12-23"), "user2"),
            new TodoItem(6, "Other", "Visit doctor", DateTime.Parse("2023-12-26"), "user4"),
            new TodoItem(7, "Work", "Call plumber", DateTime.Parse("2023-12-28"), "user4"),
            new TodoItem(8, "Shopping", "Attend webinar", DateTime.Parse("2023-12-31"), "user8"),
            new TodoItem(9, "Work", "Visit doctor", DateTime.Parse("2023-12-26"), "user1"),
            new TodoItem(10, "Other", "Attend webinar", DateTime.Parse("2023-12-31"), "user8"),
            new TodoItem(11, "Shopping", "Plan vacation", DateTime.Parse("2024-01-08"), "user3"),
            new TodoItem(12, "Shopping", "Complete assignment", DateTime.Parse("2023-12-24"), "user9"),
            new TodoItem(13, "Shopping", "Call plumber", DateTime.Parse("2023-12-31"), "user1"),
            new TodoItem(14, "Work", "Call plumber", DateTime.Parse("2024-01-06"), "user4"),
            new TodoItem(15, "Work", "Call plumber", DateTime.Parse("2023-12-27"), "user3")
        };

        public List<TodoItem> GetAll()
        {
            return todoList;
        }

        public void InsertToDo(TodoItem todoItem)
        {
            todoList.Add(todoItem);
        }

        public void UpdateToDo(TodoItem todoItem)
        {
            var todoItemToUpdate = todoList.FirstOrDefault(t => t.Id == todoItem.Id);

            if (todoItemToUpdate == null)
            {
                throw new ArgumentException($"Book with ID {todoItem.Id} was not found in database");
            }

            todoItemToUpdate.Type = todoItem.Type;
            todoItemToUpdate.Content = todoItem.Content;
            todoItemToUpdate.EndDate = todoItem.EndDate;
            todoItemToUpdate.UserId = todoItem.UserId;
        }

        public void DeleteToDo(int id)
        {
            var todoItemToUpdate = todoList.FirstOrDefault(t => t.Id == id);
            todoList.Remove(todoItemToUpdate);
        }
    }
}
