using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.DataAccess.Repo
{
    public interface IBaseRepo<T>
    {
        List<T> GetAll();
        T Get(int? id);
        int Create(T item);
        int Update(T item);
        int Delete(int id);
        int Delete(T item);

    }
}
