using LetsHang.Data;
using LetsHang.Domain.DomainModels;
using LetsHang.Domain.DomainModels.Account;
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
        public void AddUser(UserDM dm)
        {
            using (EFContext context = new EFContext())
            {
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
