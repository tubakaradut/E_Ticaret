using CoreMap.EntityCore;
using System;

namespace DataAccess.Entity
{
    public   class OrderDetail:EntityRepository
    {
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }


        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }


        public decimal UnitPrice  { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal? SubTotal { get; set; }

       
    }
}
