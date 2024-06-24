using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [NotMapped]
        public Category Category { get; set; } = null!;

        public int CategoryId { get; set; }
        public int Sum { get; set; }
        public string? Comment { get; set; }

        [NotMapped] 
        public List<Category> Categories { get; set; } = new();
    }
}
