using CoreMap.EntityCore;
using System;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public class Order : EntityRepository
    {
        public Guid AppUserID { get; set; }
        public AppUser AppUser { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
