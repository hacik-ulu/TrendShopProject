using System.ComponentModel.DataAnnotations;

namespace TrendShop.IdentityServer.Dtos
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "E-posta gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "İsim alanı gereklidir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "İsim alanı gereklidir.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Parola gereklidir.")]
        public string Password { get; set; }
    }
}
