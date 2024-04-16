using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IUserService
{
    IResult Add(User users);
    IResult Delete(User users);
    IResult Update(User users);
    IDataResult<List<User>> GetAll();
    IDataResult<User> GetById(int id);
    IDataResult<List<CompanyAndUserDetailDto>> GetDetail();

    List<OperationClaim> GetClaims(User user);
    User GetByMail(string email);

}
