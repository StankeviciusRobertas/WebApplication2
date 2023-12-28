using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IToDoEmailService
    {
        bool TrySendEmail(string to, TodoItem model);
    }
    public class ToDoEmailService : IToDoEmailService
    {
        public bool TrySendEmail(string emailAdress, TodoItem model)
        {
            Console.WriteLine($"El. pastas issiustas {emailAdress}");
            //kazkokia email siuntimo logika...
            return true;
        }
    }
}
