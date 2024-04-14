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

public class EfUserDal : EfEntityRepositoryBase<Users, ReCarContext>, IUserDal
{
    public List<CompanyAndUserDetailDto> CompanyAndUserDetail()
    {
        using (ReCarContext context=new())
        {
            var result=from u in context.Users
                       join c in context.Customers
                       on u.Id equals c.UserId
                       select new CompanyAndUserDetailDto { FirstName=u.FirstName, LastName=u.LastName,CompanyName=c.CompanyName };
                       return result.ToList();
        }
    }
}
