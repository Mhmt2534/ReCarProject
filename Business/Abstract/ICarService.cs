using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface ICarService
{

    IDataResult<List<Car>> GetAll();
    IDataResult<List<Car>> GetCarsByBrandId(int id);
    IDataResult<List<Car>> GetCarsByColorId(int id);
    IDataResult<Car> GetCarsById(int id);
    IDataResult<CarImageByDetailDto> GetCarImageByDetailDto(int id);
    IDataResult<List<CarDetailDto>> GetDetail();
    IDataResult<List<CarByBrandIdDto>> GetCarsByBrandIdDetail(int id);
    IDataResult<List<CarByColorIdDto>> GetCarsByColorIdDetail(int id);

	IDataResult<List<CarDetailDto>> GetCarByBrandAndColor(int brandId, int colorId);

	IResult Add(Car car);
    IResult Update(Car car);
    IResult Delete(Car car);


}
