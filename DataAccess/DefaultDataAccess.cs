using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Configuration;
using System.Data.Entity.Migrations;

namespace DataAccess
{
    public static class DefaultDataAccess
    {
        public static ApiDbContext GetContext
        {
            get
            {
                try
                {
                    if (HttpContext.Current.Items["API_CONTEXT_INSTANCE"] == null)
                        HttpContext.Current.Items.Add("API_CONTEXT_INSTANCE",
                            new ApiDbContext(ConfigurationManager.AppSettings["EF_AMBIENTE"]));

                    return (ApiDbContext)HttpContext.Current.Items["API_CONTEXT_INSTANCE"];
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public static DbContext ConvertContext(object dbContext)
        {
            try
            {
                return (ApiDbContext)dbContext;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static T GetSingle<T>(object dbContext, Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return ConvertContext(dbContext).Set<T>().Single(predicate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static T GetSingleOrDefault<T>(object dbContext, Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return ConvertContext(dbContext).Set<T>().SingleOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static T GetFirst<T>(object dbContext, Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return ConvertContext(dbContext).Set<T>().First(predicate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static T GetFirstOrDefault<T>(object dbContext, Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return ConvertContext(dbContext).Set<T>().FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static IQueryable<T> GetList<T>(object dbContext, Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return ConvertContext(dbContext).Set<T>().Where(predicate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static IQueryable<T> GetList<T>(object dbContext) where T : class
        {
            try
            {
                return ConvertContext(dbContext).Set<T>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static bool Any<T>(object dbContext, Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return ConvertContext(dbContext).Set<T>().Any(predicate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void Insert<T>(object dbContext, T model, bool saveChanges = true) where T : class
        {
            try
            {
                ConvertContext(dbContext).Set<T>().Add(model);

                if (saveChanges)
                {
                    SaveChanges(dbContext);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void AddOrUpdate<T>(object dbContext, T model, bool saveChanges = true) where T : class
        {
            try
            {
                ConvertContext(dbContext).Set<T>().AddOrUpdate(model);

                if (saveChanges)
                {
                    SaveChanges(dbContext);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void Update<T>(object dbContext, T model, bool saveChanges = true) where T : class
        {
            try
            {
                var context = ConvertContext(dbContext);

                context.Entry(model).State = EntityState.Modified;

                if (saveChanges)
                {
                    SaveChanges(dbContext);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public static void Delete<T>(object dbContext, T model, bool saveChanges = true) where T : class
        {
            try
            {
                ConvertContext(dbContext).Set<T>().Remove(model);

                if (saveChanges)
                {
                    SaveChanges(dbContext);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static bool SaveChanges(object dbContext)
        {
            try
            {

                var context = ConvertContext(dbContext);

                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
