using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework;

public class EFCarDal : EfEntityRepositoryBase<Car, ReCarContext>, ICarDal
{
	public List<CarByBrandIdDto> GetCarByBrandIdDtos(int id)
	{
		using (ReCarContext context = new())
		{
			var res = from c in context.Cars
					  join b in context.Brands
					  on c.BrandId equals b.BrandId
					  join r in context.Colors
					  on c.ColorId equals r.ColorId
					  where c.BrandId == id
					  select new CarByBrandIdDto { CarId = c.CarId, CarName = c.CarName, BrandName = b.BrandName, ColorName = r.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice };

			return res.ToList();

		}
	}

	public List<CarByColorIdDto> GetCarByColorIdDtos(int id)
	{
		using (ReCarContext context = new())
		{
			var res = from c in context.Cars
					  join b in context.Brands
					  on c.BrandId equals b.BrandId
					  join r in context.Colors
					  on c.ColorId equals r.ColorId
					  where c.ColorId == id
					  select new CarByColorIdDto { CarId = c.CarId, CarName = c.CarName, BrandName = b.BrandName, ColorName = r.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice };

			return res.ToList();

		}
	}

	public List<CarDetailDto> GetCarDetail()
	{
		using (ReCarContext context = new())
		{
			var res = from c in context.Cars
					  join b in context.Brands
					  on c.BrandId equals b.BrandId
					  join r in context.Colors
					  on c.ColorId equals r.ColorId
					  select new CarDetailDto { CarId = c.CarId, CarName = c.CarName, BrandName = b.BrandName, ColorName = r.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice };

			return res.ToList();

		}
	}

	public CarImageByDetailDto GetCarImageByDetailDto(int id)
	{
		using (ReCarContext context = new())
		{
			var res = (from c in context.Cars
					   join b in context.Brands
					   on c.BrandId equals b.BrandId
					   join r in context.Colors
					   on c.ColorId equals r.ColorId
					   where c.CarId == id
					   select new CarImageByDetailDto { CarId = c.CarId, CarName = c.CarName, BrandName = b.BrandName, ColorName = r.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice }).FirstOrDefault();

			return res;

		}
	}

	public List<CarByBrandAndColorDto> GetCarByBrandAndColor(int brandId, int colorId)
	{
		using (ReCarContext context = new())
		{
			var res = from c in context.Cars
					  join b in context.Brands
					  on c.BrandId equals b.BrandId
					  join cl in context.Colors
					  on c.ColorId equals cl.ColorId
					  where c.BrandId == brandId && c.ColorId == colorId
					  select new CarByBrandAndColorDto { CarId = c.CarId, CarName = c.CarName, BrandName = b.BrandName, ColorName = cl.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice };

			return res.ToList();

		}



	}

	List<CarDetailDto> ICarDal.GetCarByBrandAndColor(int brandId, int colorId)
	{
		using (ReCarContext context = new())
		{
			var res = from c in context.Cars
					  join b in context.Brands
					  on c.BrandId equals b.BrandId
					  join cl in context.Colors
					  on c.ColorId equals cl.ColorId
					  where c.BrandId == brandId && c.ColorId == colorId
					  select new CarDetailDto { CarId = c.CarId, CarName = c.CarName, BrandName = b.BrandName, ColorName = cl.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice };

			return res.ToList();

		}
	}
}
