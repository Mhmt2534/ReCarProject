using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
            new Car { Id = 1,BrandId=1,ColorId=24,ModelYear=2010,DailyPrice=10000,Description="BMW X1"},
            new Car { Id = 2,BrandId=1,ColorId=22,ModelYear=2017,DailyPrice=15000,Description="BMW X5"},
            new Car { Id = 3,BrandId=2,ColorId=24,ModelYear=2014,DailyPrice=18000,Description="Mercedes C180"},
            new Car { Id = 4,BrandId=2,ColorId=20,ModelYear=2019,DailyPrice=17000,Description="Mercedes C200"},
            new Car { Id = 5,BrandId=3,ColorId=22,ModelYear=2023,DailyPrice=22000,Description="Toyota"}
        };
    }

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Delete(Car car)
    {
        Car carToDelete=_cars.SingleOrDefault(c=>c.Id==car.Id);

        _cars.Remove(carToDelete);
    }

    public List<Car> GetAll()
    {
        return _cars;
    }

    public List<Car> GetById(int brandId)
    {
        return _cars.Where(c=>c.BrandId == brandId).ToList();
    }

    public void Update(Car car)
    {
        Car carToUpdate= _cars.SingleOrDefault(c=>c.Id == car.Id);
        carToUpdate.Id= car.Id;
        carToUpdate.BrandId=car.BrandId;
         carToUpdate.ModelYear=car.ModelYear;
        carToUpdate.ColorId=car.ColorId;
        carToUpdate.DailyPrice=car.DailyPrice;
        carToUpdate.Description=car.Description;
    }
}
