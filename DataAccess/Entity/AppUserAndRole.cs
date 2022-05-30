using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entity
{
    public class AppUserAndRole
    {
        public Guid ID { get; set; }
        [ForeignKey("AppUser")]
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        [ForeignKey("AppUserRole")]
        public Guid AppUserRoleId { get; set; }
        public virtual AppUserRole AppUserRole { get; set; }
    }
}
