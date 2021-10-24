using SWZOS_Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWZOS.Repositories
{
    public class BaseRepository
    {
        protected SWZOSContext _database;

        public BaseRepository(SWZOSContext database)
        {
            _database = database;
        }

        public void SaveChanges()
        {
            _database.SaveChanges();
        }
    }
}
