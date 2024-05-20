using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IRentalService
{
    IResult Add(Rentals rentals);
    IResult Delete(Rentals rentals);
    IResult Update(Rentals rentals);

    IDataResult<List<Rentals>> GetAll();

    IDataResult<Rentals> GetById(int id);
    IDataResult<List<Rentals>> GetRentalsByCarId(int id);
	IDataResult<List<RentalDetailDto>> GetDetail();
}
