using Core.Service;
using CoreMap.EntityCore;
using DataAccess.Context;
using DataAccess.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.BaseService
{
    public class BaseService<T> : ICoreService<T> where T : EntityRepository
    {
        ProjeContext context = DbContextSingleton.Context;

        public ProjeContext GetContext()
        {
            return context;
        }

        public string Add(T model)
        {
            //todo: her veri kaydedildiğinde Created... propertyleri doldurulacak.
            //todo: her veri kaydedildiğinde IP adresi yakalanacak.

            try
            {
                model.ID = Guid.NewGuid();
                context.Set<T>().Add(model);
                context.SaveChanges();
                return "veri eklendi!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Add(List<T> models)
        {
            foreach (var item in models)
            {
                context.Set<T>().Add(item);
            }
            context.SaveChanges();
            return "veriler eklendi";
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Any(exp);
        }

        public string Delete(Guid id)//2
        {
            try
            {
                T deleted = GetById(id);
                deleted.Status = Core.Enums.Status.Deleted;
                Update(deleted);
                return "veri silindi";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        public T GetById(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Where(exp).ToList();
        }

        public List<T> GetList()
        {
            return context.Set<T>().ToList();
        }

        public string RemoveForce(T model)
        {
            try
            {
                context.Set<T>().Remove(model);
                return "veri kalıcı olarak silindi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Update(T model)
        {

            try
            {
                T updated = GetById(model.ID);

                context.Entry(updated).CurrentValues.SetValues(model);

                //DbEntityEntry entity = context.Entry(updated);
                //entity.CurrentValues.SetValues(model);

                context.SaveChanges();
                return $"{model.ID} nolu veri güncellendi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
    }
}
