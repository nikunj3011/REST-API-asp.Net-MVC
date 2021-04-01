using GameLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.DataAccess.Context
{
    public class GameLibraryContext : DbContext
    {
        public DbSet<Games> Games { get; set; }
    }
}
