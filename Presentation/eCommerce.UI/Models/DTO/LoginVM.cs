using System.ComponentModel.DataAnnotations;

namespace eCommerce.UI.Models.DTO
{
    public class LoginVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[]? passwordHash { get; set; }
        public byte[]? passwordSalt { get; set; }
    }
}
