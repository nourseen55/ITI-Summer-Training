using ITIProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Range(10, 20)]
        public int Age { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        //[Remote(action: "VerifyEmail", controller: "Student")]
        public string? Email { get; set; }
        [Required, StringLength(15, MinimumLength = 3)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [NotMapped]
        //[DataType(DataType.Password)]

        public string ConfirmedPassword { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [ValidateNever]
        public virtual Department Department { get; set; }
        [ValidateNever]
        public virtual Course Course { get; set; }



    }
}