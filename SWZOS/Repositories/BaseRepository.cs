using SWZOS_Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWZOS.Repositories
{
    public class BaseRepository
    {
        protected SWZOSContext _db;

        public BaseRepository(SWZOSContext database)
        {
            _db = database;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
