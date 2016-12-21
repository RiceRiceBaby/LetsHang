using LetsHang.Data;
using LetsHang.Domain.DomainModels;
using LetsHang.Domain.DomainModels.Account;
using LetsHang.Domain.Enums;
using LetsHang.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsHang.Service
{
    public class AccountService : IAccountService
    {
        public void RegisterUser(UserDM dm)
        {
            // Sets status to pending and creates account
            using (EFContext context = new EFContext())
            {
                dm.StatusId = Convert.ToInt32(UserStatusEnum.Pending);

                context.Set<UserDM>().Add(dm);

                context.SaveChanges();
            }
        }

        public void UpdateUser(UserDM dm)
        {
            using (EFContext context = new EFContext())
            {
                UserDM entity = context.Set<UserDM>().Where(x => x.Id == dm.Id).FirstOrDefault();

                if (entity == null)
                    throw new Exception("User does not exist");

                entity.Update(dm);
                context.Entry<UserDM>(entity).State = EntityState.Modified;

                context.SaveChanges();
            }
        }


        public void ApproveUserById(int userId)
        {
            // Grabs user, sets status to active, and updates account
            using (EFContext context = new EFContext())
            {
                UserDM entity = context.Set<UserDM>().Where(x => x.Id == userId).FirstOrDefault();

                if (entity == null)
                    throw new Exception("User does not exist");

                entity.StatusId = Convert.ToInt32(UserStatusEnum.Active);
                context.Entry<UserDM>(entity).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void RemoveUserById(int userId)
        {
            using (EFContext context = new EFContext())
            {
                UserDM entity = context.Set<UserDM>().Where(x => x.Id == userId).FirstOrDefault();
                context.Set<UserDM>().Remove(entity);

                context.SaveChanges();
            }
        }

        public IList<UserDM> SearchUsers(UserSearchCriteriaDM crit)
        {
            IList<UserDM> list = null;

            using (EFContext context = new EFContext())
            {
                list = context.Set<UserDM>().Where(x => x.Id == x.Id).ToList();
            }

            return null;
        }

        public UserDM GetUserById(int userId)
        {
            UserDM dm = null;

            using (EFContext context = new EFContext())
            {
                dm = context.Set<UserDM>().Where(x => x.Id == userId).FirstOrDefault();
            }

            return dm;
        }
    }
}
