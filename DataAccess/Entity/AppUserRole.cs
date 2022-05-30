using CoreMap.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
  public  class AppUserRole:EntityRepository
    {
        //public int AppUserRoleId { get; set; }
        public string RoleName { get; set; }

        public List<AppUserAndRole> AppUserAndRoles { get; set; }
    }
}
