using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required, MaxLength(32)]
        public string  UserName { get; set; }
        [Required, MaxLength(32)]
        public string  Password { get; set; }
    }
}