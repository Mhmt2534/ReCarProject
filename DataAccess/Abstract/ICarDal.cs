using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract;

public interface ICarDal:IEntitiyRepository<Car>
{
   List<CarDetailDto> GetCarDetail();
   List<CarByBrandIdDto> GetCarByBrandIdDtos(int id);
   List<CarByColorIdDto> GetCarByColorIdDtos(int id);
	public CarImageByDetailDto GetCarImageByDetailDto(int id);
	List<CarDetailDto> GetCarByBrandAndColor(int brandId, int colorId);

}
