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
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly AppDbContext _db;
        public GenreRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Genre genre)
        {
            _db.Genres.Update(genre);
        }
    }
}
