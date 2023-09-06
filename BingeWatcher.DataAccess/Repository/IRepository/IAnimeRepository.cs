using BingeWatcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingeWatcher.DataAccess.Repository.IRepository
{
    public interface IAnimeRepository : IRepository<Anime>
    {
        void Update(Anime anime);
    }
}
