using SWZOS.Models.BlackList;
using SWZOS_Database;
using SWZOS_Database.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SWZOS.Repositories
{
    public class BlackListRepository: BaseRepository
    {
        public BlackListRepository(SWZOSContext database): base(database)
        {

        }

        public List<BlackListViewModel> GetBlackListFull()
        {
            return _db.BlackList.Select(a => new BlackListViewModel 
            { 
                UserId = a.UserId,
                StatusId = a.StatusId,
                StatusName = a.BlackListStatus.Name,
                FullName = a.User.Name + " " + a.User.Surname,
                Reason = a.Reason
            }).ToList();
        }

        public void AddToBlackList(BlackListFormModel model)
        {
            var entity = new BlackList
            {
                UserId = model.UserId,
                StatusId = model.StatusId,
                Reason = model.Reason
            };

            _db.BlackList.Add(entity);
            _db.SaveChanges();
        }

        public void DeleteFromBlackList(int userId)
        {
            var result = _db.BlackList.Where(a => a.UserId == userId).FirstOrDefault();
            _db.BlackList.Remove(result);
            _db.SaveChanges();
        }
    }
}
