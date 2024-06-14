using System;
using System.ComponentModel.DataAnnotations;

namespace ProductModel.Models
{
    public class Login
    {
        private Guid Id { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(20,MinimumLength=6)]
        public string Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
        
        public Login()
        {
            Id= Guid.NewGuid();
        }
    }
}
