using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BingeWatcher.Models.ViewModels
{
    public class AnimeVM
    {
        public Anime Anime { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> GenreList { get; set; }
    }
}
