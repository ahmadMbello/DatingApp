using System.ComponentModel.DataAnnotations;

namespace datingapp.api.Dtos
{
    public class userToRegisterDto
    {
       

        [Required]
        public string UserName { get; set; }
         [Required]
        [StringLength(8,MinimumLength = 4,ErrorMessage = "length between 4 and 8")]
        public string Password { get; set; }
    }
}