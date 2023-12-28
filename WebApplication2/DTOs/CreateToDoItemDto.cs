using WebApplication2.Models;

namespace WebApplication2.DTOs
{
    public class CreateToDoItemDto
    {
        public CreateToDoItemDto()
        {
        }

        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserId { get; set; }

        //public static explicit operator TodoItem(CreateToDoItemDto dto)
        //{
        //    return new TodoItem 
        //    {
        //        Type = dto.Type,
        //        Content = dto.Content,
        //        EndDate = dto.EndDate,
        //        UserId = dto.UserId,
        //    };
        //}

        public static TodoItem ToModel(CreateToDoItemDto dto)
        {
            return new TodoItem
            {
                Type = dto.Type,
                Content = dto.Content,
                EndDate = dto.EndDate,
                UserId = dto.UserId,
            };
        }
    }
}
