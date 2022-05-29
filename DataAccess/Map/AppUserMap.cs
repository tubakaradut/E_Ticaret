using CoreMap.Map;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
    public class AppUserMap : CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.AppUsers");
            Property(x => x.Firstname).HasMaxLength(255).IsOptional();
            Property(x => x.Lastname).HasMaxLength(255).IsOptional();
            Property(x => x.Address).HasMaxLength(255).IsOptional();
            Property(x => x.Username).HasMaxLength(255).IsRequired();
            Property(x => x.Password).HasMaxLength(255).IsRequired();
            Property(x => x.Email).HasMaxLength(255).IsRequired();

        }
    }
}