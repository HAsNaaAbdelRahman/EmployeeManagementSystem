using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id {  get; set; }

        [Required]
        [StringLength(20 , MinimumLength =3)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

       

    }
}
