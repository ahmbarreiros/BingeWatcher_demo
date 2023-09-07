using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BingeWatcher.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Nome")]
        public string? Name { get; set; }
    }
}
