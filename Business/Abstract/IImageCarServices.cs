using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IImageCarServices
{
    IResult Add(IFormFile file, ImageCar carImage);
    IResult Delete(ImageCar carImage);
    IResult Update(IFormFile file, ImageCar carImage);
    
    IDataResult<List<ImageCar>> GetAll();
    IDataResult<List<ImageCar>> GetByCarId(int carId);
    IDataResult<ImageCar> GetByImageId(int imageId);
}
