using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class ImageCarManager : IImageCarServices
{
    IImageCarDal _carImageDal;
    IFileHelperService _fileHelper;
    public ImageCarManager(IImageCarDal carImageDal, IFileHelperService fileHelper)
    {
        _carImageDal = carImageDal;
        _fileHelper = fileHelper;
    }
    public IResult Add(IFormFile file, ImageCar carImage)
    {
        IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
        if (result != null)
        {
            return result;
        }
        carImage.ImagePath = _fileHelper.Upload(file, PathConstans.ImagesPath);
        carImage.Date = DateTime.Now;
        _carImageDal.Add(carImage);
        return new SuccessResult("Resim başarıyla yüklendi");
    }

    public IResult Delete(ImageCar carImage)
    {
        _fileHelper.Delete(PathConstans.ImagesPath + carImage.ImagePath);
        _carImageDal.Delete(carImage);
        return new SuccessResult();
    }
    public IResult Update(IFormFile file, ImageCar carImage)
    {
        carImage.ImagePath = _fileHelper.Update(file, PathConstans.ImagesPath + carImage.ImagePath, PathConstans.ImagesPath);
        _carImageDal.Update(carImage);
        return new SuccessResult();
    }

    public IDataResult<List<ImageCar>> GetByCarId(int carId)
    {
        var result = BusinessRules.Run(CheckCarImage(carId));
        if (result != null)
        {
            return new ErrorDataResult<List<ImageCar>>(GetDefaultImage(carId).Data);
        }
        return new SuccessDataResult<List<ImageCar>>(_carImageDal.GetAll(c => c.CarId == carId));
    }

    public IDataResult<ImageCar> GetByImageId(int imageId)
    {
        return new SuccessDataResult<ImageCar>(_carImageDal.Get(c => c.Id == imageId));
    }

    public IDataResult<List<ImageCar>> GetAll()
    {
        return new SuccessDataResult<List<ImageCar>>(_carImageDal.GetAll());
    }
    private IResult CheckIfCarImageLimit(int carId)
    {
        var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
        if (result >= 5)
        {
            return new ErrorResult();
        }
        return new SuccessResult();
    }
    private IDataResult<List<ImageCar>> GetDefaultImage(int carId)
    {

        List<ImageCar> carImage = new List<ImageCar>();
        carImage.Add(new ImageCar { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
        return new SuccessDataResult<List<ImageCar>>(carImage);
    }
    private IResult CheckCarImage(int carId)
    {
        var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
        if (result > 0)
        {
            return new SuccessResult();
        }
        return new ErrorResult();
    }
}
