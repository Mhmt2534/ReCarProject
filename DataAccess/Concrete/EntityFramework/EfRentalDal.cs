using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework;

public class EfRentalDal : EfEntityRepositoryBase<Rentals, ReCarContext>, IRentalDal
{
    public List<RentalCustomerDetail> RentalCustomerDetails()
    {
        using (ReCarContext context=new())
        {
            return null;
        }
    }

	public List<RentalDetailDto> rentalDetailDtos()
	{
        using (ReCarContext context=new())
        {
            var res = from r in context.Rentals
                      join c in context.Cars
                      on r.CarId equals c.CarId
                      join b in context.Brands
                      on c.BrandId equals b.BrandId
                      join m in context.Customers
                      on r.CustomerId equals m.UserId
                      join u in context.Users
                      on m.UserId equals u.Id
                      select new RentalDetailDto { Brand = b.BrandName, FirstName = u.FirstName, LastName = u.LastName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };

            return res.ToList();
                     
        }
	}
}
