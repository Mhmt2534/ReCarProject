using Business.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation;

public class RentalValidator:AbstractValidator<Rentals>
{
    private readonly IRentalDal _rentalDal;

    public RentalValidator()
    {
        RuleFor(rental => rental)
         .Must(BeAvailable)
         .WithMessage(Messages.noRental);
    }

    private bool BeAvailable(Rentals rental)
    {
        var isAvailable = _rentalDal.GetAll(p => p.CarId == rental.CarId && p.ReturnDate == null).Any();
        return !isAvailable;
    }
}
