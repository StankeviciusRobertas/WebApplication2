using WebApplication2.Models;

namespace WebApplication2.DTOs
{
    public class GetToDoItemDto
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserId { get; set; }

        public GetToDoItemDto(TodoItem model)
        {
            Id = model.Id;
            Type = model.Type;
            Content = model.Content;
            EndDate = model.EndDate;
            UserId = model.UserId;
        }
    }
}
