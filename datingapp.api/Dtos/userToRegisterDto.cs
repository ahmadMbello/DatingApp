using System.ComponentModel.DataAnnotations;

namespace datingapp.api.Dtos
{
    public class userToRegisterDto
    {
        [Required]
        [StringLength(8,MinimumLength=4,ErrorMessage="length must between 4 and 8 chracter")]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}