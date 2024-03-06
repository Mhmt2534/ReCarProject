using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework;

public class EFCarDal : ICarDal
{
    public void Add(Car entity)
    {
        using (NorthwindContext context = new NorthwindContext())
        {
            if (entity.Description.Length>=2 && entity.DailyPrice>0)
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Araba eklenemedi. Araba ismi minimum 2 karakter olmalıdır ve günlük fiyatı 0'dan büyük olmalıdır.");
            }
        }
    }

    public void Delete(Car entity)
    {
        using (NorthwindContext context=new NorthwindContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State=EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    {
        using (NorthwindContext context = new NorthwindContext())
        {
            return filter==null ? context.Set<Car>().ToList() : 
                context.Set<Car>().Where(filter).ToList();
        }
    }

    public List<Car> Get(Expression<Func<Car, bool>> filter)
    {
        using (NorthwindContext context=new NorthwindContext())
        {
            return null;
        }
    }

    public void Update(Car entity)
    {
        using (NorthwindContext context=new NorthwindContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State= EntityState.Modified;
            context.SaveChanges();
        }
    }
}
