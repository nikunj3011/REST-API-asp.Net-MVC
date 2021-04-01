using GameLibrary.DataAccess.Context;
using GameLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.DataAccess.Repo
{
    public class SqlGameLibrary : IGameLibraryRepo
    {
        private GameLibraryContext db = new GameLibraryContext();

        public IQueryable<Games> GetQueriable()
        {
            return db.Games;
        }

        public Games Get(int? id)
        {
            Games games = db.Games.Find(id);
            return games;
        }

        public List<Games> GetAll()
        {
            return db.Games.ToList();
        }
        public int Create(Games game)
        {
            db.Games.Add(game);
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            Games games = Get(id);
            return Delete(games);
        }

        public int Delete(Games games)
        {
            db.Games.Remove(games);
            return db.SaveChanges();
        }


        public int Update(Games games)
        {
            db.Entry(games).State = EntityState.Modified;
            return db.SaveChanges();
            
        }

        
    }
}
