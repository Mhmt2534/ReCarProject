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

public class EfRentalDal : EfEntityRepositoryBase<Rentals, NorthwindContext>, IRentalDal
{
    public List<RentalCustomerDetail> RentalCustomerDetails()
    {
        using (NorthwindContext context=new())
        {
            return null;
        }
    }
}
