using LetsHang.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsHang.Data.Maps.Lookups
{
    public class UserStatusMap : EntityTypeConfiguration<UserStatusDM>
    {
        public UserStatusMap()
        {
            this.ToTable("UserStatus", "LK");
            this.HasKey(x => x.Id);
            this.Property(x => x.Name).IsRequired();
        }
    }
}
