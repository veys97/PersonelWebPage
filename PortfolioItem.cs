
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeyselAlanWebPage.Models
{
    public class PortfolioItem
    {
        public int Id { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; } // Veritabanında resmin yolunu saklar

        public string Status { get; set; }

        
    }
}
