using System.ComponentModel.DataAnnotations;

namespace Todo.Api.Resources
{
    public class SaveTodoResource
    {
        [Required]
        public string Name { get; set; }
        //[Required]
        //public bool IsComplete { get; set; }
    }
}
