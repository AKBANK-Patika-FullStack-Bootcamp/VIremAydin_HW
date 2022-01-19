using System.ComponentModel.DataAnnotations;

namespace Week1.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string BookName { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty; 
    }
}
