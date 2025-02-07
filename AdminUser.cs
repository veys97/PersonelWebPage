using System.ComponentModel.DataAnnotations;

namespace VeyselAlanWebPage.Models
{
    public class AdminUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } // Şifre hash ile saklanmalı
    }
}
