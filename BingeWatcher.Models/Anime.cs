using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BingeWatcher.Models
{
    public class Anime
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Título")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? Title { get; set; }
        [ValidateNever]
        public string? Main_Picture { get; set; }
        [DisplayName("Data de Início")]
        public string? Start_Date { get; set; }
        [DisplayName("Data de Encerramento")]
        public string? End_Date { get; set;}
        [DisplayName("Sinopse")]
        public string? Synopsis { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? Status { get; set; }
        [DisplayName("Episódios")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public int Number_Of_Episodes { get; set; }
        [DisplayName("Classificação")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? Rating { get; set; } // g/pg/pg_13/r/r+/rx
        [DisplayName("Gênero")]
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        [ValidateNever]
        [DisplayName("Gênero")]
        public Genre Genre { get; set; }

    }
}
