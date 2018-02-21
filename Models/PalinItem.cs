using System.ComponentModel.DataAnnotations;

namespace Palindrome.Models
{
    public class PalinItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Hash { get; set; }
    }
}