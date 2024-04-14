using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class RentalManager : IRentalServices
{
    private readonly IRentalDal _rentalDal;
    public RentalManager(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;
    }
    public IResult Add(Rentals rentals)
    {
        var isAvailable = _rentalDal.GetAll(p => p.CarId == rentals.CarId && p.ReturnDate == null).Any();
        if (isAvailable == true)
        {
            return new ErrorResult(Messages.noRental);
        }
        _rentalDal.Add(rentals);
        return new SuccessResult(Messages.Rentall);


    }

    public IResult Delete(Rentals rentals)
    {
        _rentalDal.Delete(rentals);
        return new SuccessResult();
    }

    public IDataResult<List<Rentals>> GetAll()
    {
        return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll(), Messages.CarsListed);
    }

    public IResult Update(Rentals rentals)
    {
        _rentalDal.Update(rentals);
        return new SuccessResult(Messages.CarUpdated);
    }
}
