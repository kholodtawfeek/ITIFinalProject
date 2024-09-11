using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ITIFinalProject.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The User First Name is required.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The User Last Name is required.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The User Email is required.")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The User Password is required.")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public int Password { get; set; }
    }
}
