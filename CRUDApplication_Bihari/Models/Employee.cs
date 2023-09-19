using System.ComponentModel.DataAnnotations;

namespace CRUDApplication_Bihari.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "* Name can't be blank")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* State can't be blank")]

        public string State { get; set; }
        [Required(ErrorMessage = "* City can't be blank")]

        public string City { get; set; }
        [Required(ErrorMessage = "* Salary can't be blank")]

        public decimal Salary { get; set; }
    }
}
