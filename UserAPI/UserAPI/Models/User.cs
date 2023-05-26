using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(2,ErrorMessage ="Username should be minimum of 2 characters")]
        public string Username { get; set; }

        public byte[]? Password { get; set; }

        public byte[]? HashKey { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name should be minimum of 2 characters")]
        public string Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        [Required]
        [Range(18,100,ErrorMessage ="Enter a valid age between 18-100")]
        public int Age { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
