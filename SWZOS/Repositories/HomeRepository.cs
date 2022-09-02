using SWZOS.Models.Admin;
using SWZOS_Database;
using System.Collections.Generic;
using System.Linq;

namespace SWZOS.Repositories
{
    public class HomeRepository : BaseRepository
    { 
        public HomeRepository(SWZOSContext database): base(database)
        {

        }

        public string GetHomePageDescription()
        {
            return _db.Global.Where(a => a.Key == "HomePageDescription").Select(a => a.Value).FirstOrDefault();
        }

        public string GetRegulations()
        {
            return _db.Global.Where(a => a.Key == "Regulations").Select(a => a.Value).FirstOrDefault();
        }
        
        public List<GlobalViewModel> GetAllValues()
        {
            return _db.Global.Select(a => new GlobalViewModel()
            {
                Key = a.Key,
                Value = a.Value,
                Description = a.Description
            }).ToList();
        }

        public GlobalViewModel GetModelByKey(string key)
        {
            return _db.Global.Where(a => a.Key == key).Select(a => new GlobalViewModel
            {   
                Key = a.Key,
                Value = a.Value, 
                Description = a.Description
            }).FirstOrDefault();
        }

        public void EditValue(GlobalViewModel model)
        {
            var entity = _db.Global.Where(a => a.Key == model.Key).FirstOrDefault();
            if (entity != null)
            {
                entity.Value = model.Value;
                entity.Description = model.Description;
                SaveChanges();
            }
        }
    }
}
