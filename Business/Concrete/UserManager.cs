using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;
    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public IResult Add(User users)
    {
        _userDal.Add(users);
        return new SuccessResult(Messages.UserAdded);
    }

    public IResult Delete(User users)
    {
        _userDal.Delete(users);
        return new SuccessResult(Messages.UserDeleted);
    }

  

    public IDataResult<List<User>> GetAll()
    {
        return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UserListed);
    }

    public IDataResult<User> GetById(int id)
    {
        return new SuccessDataResult<User>(_userDal.Get(u=>u.Id==id),Messages.UserCall);
    }

    public List<OperationClaim> GetClaims(User user)
    {
        return _userDal.GetClaims(user);
    }

    public User GetByMail(string email)
    {
        return _userDal.Get(u => u.Email == email);
    }
    public IDataResult<List<CompanyAndUserDetailDto>> GetDetail()
    {
        return new SuccessDataResult<List<CompanyAndUserDetailDto>>(_userDal.CompanyAndUserDetail(),Messages.UserListed);
    }

    public IResult Update(User users)
    {
        _userDal.Update(users);
        return new SuccessResult(Messages.UserUpdated);
    }
}
