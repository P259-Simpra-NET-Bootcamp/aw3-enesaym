using Microsoft.EntityFrameworkCore;
using SimApiHw.Base.Model;
using SimApiHw.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimApiHw.Data.Repository.Base
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : BaseModel
    {
        protected readonly SimDbContext dbContext;
        private bool disposed;

        public GenericRepository(SimDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Delete(Entity entity)
        {
            dbContext.Set<Entity>().Remove(entity);
        }

        public void DeleteById(int id)
        {
            var entity = dbContext.Set<Entity>().Find(id);
            dbContext.Set<Entity>().Remove(entity);
        }

        public List<Entity> GetAll()
        {
            return dbContext.Set<Entity>().ToList();
        }


        public Entity GetById(int id)
        {
            return dbContext.Set<Entity>().Find(id);
        }
     

        public void Insert(Entity entity)
        {
            dbContext.Set<Entity>().Add(entity);
        }

        public void Update(Entity entity)
        {
            dbContext.Set<Entity>().Update(entity);
        }

        public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> expression)
        {
            return dbContext.Set<Entity>().Where(expression).AsQueryable();
        }
        public IEnumerable<Entity> WhereAsNoTracking(Expression<Func<Entity, bool>> expression)
        {
            return dbContext.Set<Entity>().AsNoTracking().Where(expression).AsQueryable();
        }

        public void Complete()
        {
            dbContext.SaveChanges();
        }



        private void Clean(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }

            disposed = true;
            GC.SuppressFinalize(this);
        }
        public void Dispose()
        {
            Clean(true);
        }
    }
}
