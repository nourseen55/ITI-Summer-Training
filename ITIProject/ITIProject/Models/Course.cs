using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ITIProject.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public String CourseName { get; set; }
        [Range(2,40)]
        public int Hours { get; set; }
        [ValidateNever]
        public List<Student> Students { get; set; } 
    }
}
