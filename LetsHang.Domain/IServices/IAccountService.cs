using LetsHang.Domain.DomainModels;
using LetsHang.Domain.DomainModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsHang.Domain.IServices
{
    public interface IAccountService
    {
        void RegisterUser(UserDM dm);
        void UpdateUser(UserDM dm);
        void ApproveUserById(int userId);
        void RemoveUserById(int userId);
        IList<UserDM> SearchUsers(UserSearchCriteriaDM crit);
        UserDM GetUserById(int id);
    }
}
