using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ITIProject.Models
{
    public class Department
    {

        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public int Capacity { get; set; }
        public bool Status {  get; set; }=true;
        [ValidateNever] 
        public virtual List<Student> Students { get; set; }
    }
}
