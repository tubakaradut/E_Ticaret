using DataAccess.Context;
using DataAccess.Entity;
using DataAccess.Tools;
using Service.BaseService;
using System.Linq;

namespace Service.Concrete
{
    public class OrderDetailService:BaseService<OrderDetail>
    {
        ProjeContext context = DbContextSingleton.Context;
        public MostSalesProduct GetMostSalesProduct()
        {
            string query = "select top(1) max(Quantity) as TotalQuantity,p.ProductName as ProductName from OrderDetails o inner join Products p on p.ID = o.ProductId group by ProductId,p.ProductName order by totalQuantity desc";

            MostSalesProduct mostSalesProduct = context.Database.SqlQuery<MostSalesProduct>(query).FirstOrDefault();



            return mostSalesProduct;
        }
    }
}
