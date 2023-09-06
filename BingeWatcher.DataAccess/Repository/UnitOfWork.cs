using BingeWatcher.Data;
using BingeWatcher.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingeWatcher.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenreRepository GenreRepository { get; private set; }
        public IAnimeRepository AnimeRepository { get; private set; }

        private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            GenreRepository = new GenreRepository(_db);
            AnimeRepository = new AnimeRepository(_db);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
