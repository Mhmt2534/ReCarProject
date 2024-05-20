using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemoryCarDal;

public class InMemoryCarDal : ICarDal
{
    List<Car> _cars;
    public InMemoryCarDal()
    {
        _cars = new List<Car>()
        {
            new Car { CarId = 1,BrandId=1,ColorId=24,ModelYear=2010,DailyPrice=10000,Description="BMW X1"},
            new Car { CarId = 2,BrandId=1,ColorId=22,ModelYear=2017,DailyPrice=15000,Description="BMW X5"},
            new Car { CarId = 3,BrandId=2,ColorId=24,ModelYear=2014,DailyPrice=18000,Description="Mercedes C180"},
            new Car { CarId = 4,BrandId=2,ColorId=20,ModelYear=2019,DailyPrice=17000,Description="Mercedes C200"},
            new Car { CarId = 5,BrandId=3,ColorId=22,ModelYear=2023,DailyPrice=22000,Description="Toyota"}
        };
    }

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Delete(Car car)
    {
        Car carToDelete=_cars.SingleOrDefault(c=>c.CarId==car.CarId);

        _cars.Remove(carToDelete);
    }

    public List<Car> GetAll()
    {
        return _cars;
    }

    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public Car GetById(int id)
    {
        return null;
    }

    public List<Car> Get(Expression<Func<Car, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public void Update(Car car)
    {
        Car carToUpdate= _cars.SingleOrDefault(c=>c.CarId == car.CarId);
        carToUpdate.CarId= car.CarId;
        carToUpdate.BrandId=car.BrandId;
         carToUpdate.ModelYear=car.ModelYear;
        carToUpdate.ColorId=car.ColorId;
        carToUpdate.DailyPrice=car.DailyPrice;
        carToUpdate.Description=car.Description;
    }

    public Car Get(int id)
    {
        throw new NotImplementedException();
    }

    Car IEntitiyRepository<Car>.Get(Expression<Func<Car, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<CarDetailDto> GetCarDetail()
    {
        throw new NotImplementedException();
    }

	public List<CarByBrandIdDto> GetCarByBrandIdDtos(int id)
	{
		throw new NotImplementedException();
	}

	public List<CarByColorIdDto> GetCarByColorIdDtos(int id)
	{
		throw new NotImplementedException();
	}

	public CarImageByDetailDto GetCarImageByDetailDto(int id)
	{
		throw new NotImplementedException();
	}

	public List<CarDetailDto> GetCarByBrandAndColor(int brandId, int colorId)
	{
		throw new NotImplementedException();
	}
}
