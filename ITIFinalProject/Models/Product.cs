using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ITIFinalProject.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }
        public string ImagePath { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public Category category { get; set; }

    }
}
