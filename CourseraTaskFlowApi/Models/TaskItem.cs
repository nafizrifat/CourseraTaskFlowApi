using System.ComponentModel.DataAnnotations;

namespace CourseraTaskFlowApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot be more than 500 characters.")]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
