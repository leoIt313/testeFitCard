using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
using System.Web;
using System.Configuration;

namespace Business
{
    public class DefaultBusiness
    {
        public T GetSingle<T>(object dbContext, Expression<Func<T, bool>> predicate) where T : class
        {
            return DefaultDataAccess.GetSingle<T>(dbContext, predicate);
        }
        public T GetSingleOrDefault<T>(object dbContext, Expression<Func<T, bool>> predicate) where T : class
        {
            return DefaultDataAccess.GetSingleOrDefault<T>(dbContext, predicate);
        }
        public T GetFirst<T>(object dbContext, Expression<Func<T, bool>> predicate) where T : class
        {
            return DefaultDataAccess.GetFirst<T>(dbContext, predicate);
        }
        public T GetFirstOrDefault<T>(object dbContext, Expression<Func<T, bool>> predicate) where T : class
        {
            return DefaultDataAccess.GetFirstOrDefault<T>(dbContext, predicate);
        }
        public IQueryable<T> GetList<T>(object dbContext, Expression<Func<T, bool>> predicate) where T : class
        {
            return DefaultDataAccess.GetList<T>(dbContext, predicate);
        }
        public IQueryable<T> GetList<T>(object dbContext) where T : class
        {
            return DefaultDataAccess.GetList<T>(dbContext);
        }
        public bool Any<T>(object dbContext, Expression<Func<T, bool>> predicate) where T : class
        {
            return DefaultDataAccess.Any<T>(dbContext, predicate);
        }
        public void Insert<T>(object dbContext, T model, bool saveChanges = true) where T : class
        {
            DefaultDataAccess.Insert<T>(dbContext, model, saveChanges);
        }
        public void Update<T>(object dbContext, T model, bool saveChanges = true) where T : class
        {
            DefaultDataAccess.Update<T>(dbContext, model, saveChanges);
        }
        public static void AddOrUpdate<T>(object dbContext, T model, bool saveChanges = true) where T : class
        {
            DefaultDataAccess.AddOrUpdate<T>(dbContext, model, saveChanges);
        }
        public void Delete<T>(object dbContext, T model, bool saveChanges = true) where T : class
        {
            DefaultDataAccess.Delete<T>(dbContext, model, saveChanges);
        }
        public bool SaveChanges(object dbContext)
        {
            return DefaultDataAccess.SaveChanges(dbContext);
        }
        public ApiDbContext GetContext => DefaultDataAccess.GetContext;
        public object GetObjectContext => DefaultDataAccess.GetContext;
        public void DbCreate(string nomeBanco)
        {
            new ApiDbContext(nomeBanco);
        }

    }
}

