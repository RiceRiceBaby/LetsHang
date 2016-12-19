using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int UpdatedBy { get; set; }

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
    }
}