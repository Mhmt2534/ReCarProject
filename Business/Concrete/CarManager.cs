using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcern.Validation;
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
        var res = _carDal.Get(c => c.CarId == id);
        if (res==null)
        {
            return new ErrorDataResult<Car>(Messages.NotCar);
        }
        return new SuccessDataResult<Car>(_carDal.Get(c=>c.CarId==id), Messages.CarCall);
    }

    public IDataResult<List<Car>> GetCarsByBrandId(int id) {
        var res = _carDal.GetAll(c => c.BrandId == id);
        if (res.Count==0)
        {
            return new ErrorDataResult<List<Car>>(Messages.NotCar);
        }
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),Messages.CarAdded);
    }

    public IDataResult<List<Car>> GetCarsByColorId(int id) {
        var res = _carDal.GetAll(c => c.ColorId == id);
        if (res.Count==0)
        {
            return new ErrorDataResult<List<Car>>(Messages.NotCar);
        }
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=> c.ColorId == id),Messages.CarsListed);
    }

    [ValidationAspect(typeof(CarValidator))]
    //[SecuredOperation("car.add,admin")]
    public IResult Add(Car car)
    {


        _carDal.Add(car);
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
  
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(), Messages.CarsListed);
    }

 
}
