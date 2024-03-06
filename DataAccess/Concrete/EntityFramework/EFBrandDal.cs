using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State=EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State=EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Brand> Get(Expression<Func<Brand, bool>> filter)
        {
            return null;
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (NorthwindContext context = new())
            {
                return filter == null ? context.Set<Brand>().ToList():
                    context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (NorthwindContext context=new())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State= EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
