using System.ComponentModel.DataAnnotations;

namespace datingapp.api.Dtos
{
    public class UserForLoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}