using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BingeWatcher.Models
{
    public class Anime
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Main_Picture { get; set; }
        [NotMapped]
        public object? Alternative_Titles { get; set; }
        public string? Start_Date { get; set; }
        public string? End_Date { get; set;}
        public string? Synopsis { get; set; }
        [Required]
        public string? Status { get; set; }
        [Required]
        public int Number_Of_Episodes { get; set; }
        public string? Rating { get; set; } // g/pg/pg_13/r/r+/rx

    }
}
