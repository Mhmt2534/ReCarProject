using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class CarManager : ICarService
{
    private readonly ICarDal _carDal;
    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }
    public List<Car> GetAll()
    {
        return _carDal.GetAll();
    }

    public Car GetCarsById(int id)
    {
        return _carDal.Get(c=>c.CarId==id);
    }

    public List<Car> GetCarsByBrandId(int id) {
        return _carDal.GetAll(c => c.BrandId == id);
    }

    public List<Car> GetCarsByColorId(int id) { 
    return _carDal.GetAll(c=> c.ColorId == id);
    }

    public void Add(Car car)
    {
        if (car.Description.Length >= 2 && car.DailyPrice > 0)
        {
            Console.WriteLine("Araba Başarıyla Eklendi");
            _carDal.Add(car);
        }
        else
        {
            Console.WriteLine("Araba eklenemedi. Araba ismi minimum 2 karakter olmalıdır ve günlük fiyatı 0'dan büyük olmalıdır.");
        }
        
    }

    public void Update(Car car)
    {
        _carDal.Update(car);
    }

    public void Delete(Car car)
    {
       _carDal.Delete(car);
    }

    public List<CarDetailDto> GetDetail()
    {
        return _carDal.GetCarDetail();
    }

}
