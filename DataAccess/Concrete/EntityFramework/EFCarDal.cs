using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework;

public class EFCarDal : EfEntityRepositoryBase<Car, ReCarContext>, ICarDal
{
    public List<CarDetailDto> GetCarDetail()
    {
        using (ReCarContext context=new())
        {
            var res=from c in context.Cars
                    join b in context.Brands
                    on c.BrandId equals b.BrandId
                    join r in context.Colors
                    on c.ColorId equals r.ColorId
                    select new CarDetailDto { CarName=c.CarName,BrandName=b.BrandName,ColorName=r.ColorName,DailyPrice=c.DailyPrice};
                    
                    return res.ToList();

        }
    }
}
