using GameLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.DataAccess.Repo
{
    public interface IGameLibraryRepo : IBaseRepo<Games>
    {
        IQueryable<Games> GetQueriable();
    }
}
