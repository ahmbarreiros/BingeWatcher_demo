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
            _db.Update(anime);
        }
    }
}
