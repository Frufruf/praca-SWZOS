using SWZOS.Models.BlackList;
using SWZOS_Database;
using SWZOS_Database.Entities;
using System.Collections.Generic;
using System.Linq;
using static SWZOS_Database.Enum;

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
                Id = a.Id,
                UserId = a.UserId,
                StatusId = a.StatusId,
                StatusName = a.BlackListStatus.Name,
                FullName = a.User.Name + " " + a.User.Surname,
                Reason = a.Reason
            }).ToList();
        }

        public List<BlackListViewModel> GetRecordsToApprove()
        {
            return _db.BlackList.Where(a => a.StatusId == (int)BlackListStatusEnum.WaitingForApproval).Select(a => new BlackListViewModel
            {
                Id = a.Id,
                UserId = a.UserId,
                StatusId = a.StatusId,
                StatusName = a.BlackListStatus.Name,
                FullName = a.User.Name + " " + a.User.Surname,
                Reason = a.Reason
            }).ToList();
        }

        public BlackListViewModel GetBlackListEntry(int id)
        {
            return _db.BlackList.Where(a => a.Id == id).Select(a => new BlackListViewModel
            {
                UserId = a.UserId,
                StatusId = a.StatusId,
                StatusName = a.BlackListStatus.Name,
                FullName = a.User.Name + " " + a.User.Surname,
                Reason = a.Reason
            }).FirstOrDefault();
        }

        public BlackListFormModel GetBlackListFormModelByUserId (int userId)
        {
            return _db.BlackList.Where(a => a.UserId == userId).Select(a => new BlackListFormModel
            {
                Id = a.Id,
                UserId = a.UserId,
                StatusId = a.StatusId,
                FullName = a.User.Name + " " + a.User.Surname,
                Reason = a.Reason
            }).FirstOrDefault();
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
            result.StatusId = (int)BlackListStatusEnum.Deleted;
            _db.SaveChanges();
        }

        public void ApproveBlackListEntry(int userId)
        {
            var result = _db.BlackList.Where(a => a.UserId == userId).FirstOrDefault();
            result.StatusId = (int)BlackListStatusEnum.Approved;
            _db.SaveChanges();
        }

        public void RejectBlackListEntry(int userId)
        {
            var result = _db.BlackList.Where(a => a.UserId == userId).FirstOrDefault();
            result.StatusId = (int)BlackListStatusEnum.Rejected;
            _db.SaveChanges();
        }
        
    }
}
