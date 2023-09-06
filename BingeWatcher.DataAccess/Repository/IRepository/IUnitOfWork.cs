using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingeWatcher.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    { 
        IGenreRepository GenreRepository { get; }
        void SaveChanges();
    }
}
