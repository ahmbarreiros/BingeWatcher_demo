using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BingeWatcher.Models
{
    public class AnimeGenres
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AnimeId")]
        [Required]
        public int AnimeId { get; set; }
        [ForeignKey("GenreId")]
        [Required]
        public int GenreId { get; set; }
    }
}
