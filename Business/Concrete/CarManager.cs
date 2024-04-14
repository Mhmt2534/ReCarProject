using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
    public IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
    }

    public IDataResult<Car> GetCarsById(int id)
    {
        return new SuccessDataResult<Car>(_carDal.Get(c=>c.CarId==id), Messages.CarCall);
    }

    public IDataResult<List<Car>> GetCarsByBrandId(int id) {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),Messages.CarAdded);
    }

    public IDataResult<List<Car>> GetCarsByColorId(int id) {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=> c.ColorId == id),Messages.CarsListed);
    }

    public IResult Add(Car car)
    {
        if (car.Description.Length >= 2 && car.DailyPrice > 0)
        {
            Console.WriteLine("Deneme");
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
       return new ErrorResult(Messages.CarNotAdded);
        
    }

    public IResult Update(Car car)
    {
        _carDal.Update(car);
        return new SuccessResult(Messages.CarUpdated);
    }

    public IResult Delete(Car car)
    {
       _carDal.Delete(car);
        return new SuccessResult(Messages.CarDeleted);
    }

    public IDataResult<List<CarDetailDto>> GetDetail()
    {
        if (DateTime.Now.Hour==23)
        {
            return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
        }
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(), Messages.CarsListed);
    }

}
