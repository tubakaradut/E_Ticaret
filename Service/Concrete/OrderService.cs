using DataAccess.Context;
using DataAccess.Entity;
using DataAccess.Tools;
using Service.BaseService;
using System;

namespace Service.Concrete
{
    public class OrderService : BaseService<Order>
    {
        ProjeContext context = DbContextSingleton.Context;
        public Order Add(Order model)
        {
            model.ID = Guid.NewGuid();
            var result = context.Set<Order>().Add(model);
            context.SaveChanges();

            return result;
        }
    }
}
