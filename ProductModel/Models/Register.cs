using System;
using System.ComponentModel.DataAnnotations;

namespace ProductModel.Models
{
    public class Register
    {
        private Guid Id { get; set; }
        [Required(ErrorMessage ="Поле Username должно быть заполнено")]
        [EmailAddress]
        public string UserName { get; set; }
        [Required]
        [StringLength(20,MinimumLength =6)]
        public string Password { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public Register()
        {
            Id = Guid.NewGuid();
        }
    }
}
