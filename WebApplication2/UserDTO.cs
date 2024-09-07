using System.ComponentModel.DataAnnotations;

namespace WebApplication2
{
    public class UserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
