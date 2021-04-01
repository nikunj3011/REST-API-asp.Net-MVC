using GameLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Client
{
    public interface IGameLibraryClient
    {
        Task<List<Games>> GetAll();

        Task<Games> Get(int? id);

        Task<int> Create(Games games);
        Task<int> Update(Games games);
        Task<int> Delete(int id);
        Task<int> Delete(Games games);

    }
}
