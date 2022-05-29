using CoreMap.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
  public interface ICoreService<T> where T:EntityRepository
    {
        //Add
        string Add(T model);

        //Add List
        string Add(List<T> models);

        //Get
        T GetById(Guid id);

        //Get List
        List<T> GetList();

        //Delete
        string Delete(Guid id);

        //Update
        string Update(T model);

        //Any
        bool Any(Expression<Func<T, bool>> exp);


        //GetDefault
        List<T> GetDefault(Expression<Func<T, bool>> exp);

        //Remove Force
        string RemoveForce(T model);
    }
}
