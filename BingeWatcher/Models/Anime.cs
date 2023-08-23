using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BingeWatcher.Models
{
    public class Anime
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        //[Required]
        [NotMapped]
        public object Main_Picture { get; set; }
        [NotMapped]
        public object? Alternative_Titles { get; set; }
        public string? Start_Date { get; set; }
        public string? End_Date { get; set;}
        public string? Synopsis { get; set; }
        public double? Mean_Score { get; set; }
        public int? Rank { get; set; }
        public int? Popularity { get; set; }
        public string? NSFW { get; set; } // white = safe; gray = may not be save; black = not safe
        //[Required]
        [NotMapped]
        public List<string> Genres { get; set; } // NOTE: SHOULD BE List<Genres> FURTHER ON
        [Required]
        public string Media_Type { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int Number_Of_Episodes { get; set; }
        public string? Rating { get; set; } // g/pg/pg_13/r/r+/rx
        //[Required]
        [NotMapped]
        public List<object> Studios { get; set; }

    }
}
