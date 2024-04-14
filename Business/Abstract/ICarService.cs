using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface ICarService
{
    IDataResult<List<Car>> GetAll();
    IDataResult<Car> GetCarsById(int id);
    public IDataResult<List<Car>> GetCarsByColorId(int id);

    IResult Add(Car car);
    IResult Update(Car car);
    IResult Delete(Car car);
    IDataResult<List<CarDetailDto>> GetDetail();

}
