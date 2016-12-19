using LetsHang.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsHang.Data.Maps.Account
{
    public class UserMap : EntityTypeConfiguration<UserDM>
    {
        public UserMap()
        {
            this.ToTable("User", "Account");
            this.HasKey(x => x.Id);
            this.Property(x => x.FirstName).IsRequired();
            this.Property(x => x.LastName).IsRequired();
            this.Property(x => x.EmailAddress).IsRequired();
            this.Property(x => x.PublicName).IsRequired();
            this.Property(x => x.Password).IsRequired();
            this.Property(x => x.GenderId).IsRequired();
            this.Property(x => x.StatusId).IsRequired();
        }
    }
}
