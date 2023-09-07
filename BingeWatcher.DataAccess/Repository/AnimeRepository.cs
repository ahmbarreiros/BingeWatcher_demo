using BingeWatcher.Data;
using BingeWatcher.DataAccess.Repository.IRepository;
using BingeWatcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingeWatcher.DataAccess.Repository
{
    public class AnimeRepository : Repository<Anime>, IAnimeRepository
    {
        private new readonly AppDbContext _db;
        public AnimeRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Anime anime)
        {
            var obj = _db.Animes.FirstOrDefault(u => u.Id == anime.Id);
            if(obj != null)
            {
                obj.Title = anime.Title;
                obj.Status = anime.Status;
                obj.Start_Date = anime.Start_Date;
                obj.End_Date = anime.End_Date;
                obj.Rating = anime.Rating;
                obj.Synopsis = anime.Synopsis;
                obj.GenreId = anime.GenreId;
                obj.Number_Of_Episodes = anime.Number_Of_Episodes;
                if(anime.Main_Picture != null)
                {
                    obj.Main_Picture = anime.Main_Picture;
                }

            }
        }
    }
}
