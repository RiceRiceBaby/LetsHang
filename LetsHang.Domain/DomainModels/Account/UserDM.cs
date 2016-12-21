using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LetsHang.Domain.IServices;
using LetsHang.Domain.DomainModels.Account;

namespace LetsHang.Domain.DomainModels
{
    public class UserDM : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PublicName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public int GenderId { get; set; }

        public int StatusId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public void Update(UserDM dm)
        {
            this.FirstName = dm.FirstName;
            this.LastName = dm.LastName;
            this.PublicName = dm.PublicName;
            this.EmailAddress = dm.EmailAddress;
            this.Password = dm.Password;
            this.GenderId = dm.GenderId;
            this.StatusId = dm.StatusId;
            this.UpdatedDate = dm.UpdatedDate;
            this.UpdatedBy = dm.UpdatedBy;
        }

        public bool IsValidForRegistration(IAccountService accountService)
        {
            IList<UserDM> list = accountService.SearchUsers(new UserSearchCriteriaDM
            {
                EmailAddress = this.EmailAddress
            });

            if (list != null & list.Count > 0)
                this.ValidationErrors.Add("An account has already been created with this email address");

            return this.ValidationErrors.Count <= 0;
        }
    }
}