using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class ColorManager : IColorService
{
    private readonly IColorDal _colorDal;
    public ColorManager(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }
    public void Add(Color color)
    {
        throw new NotImplementedException();
    }

    public void Delete(Color color)
    {
        throw new NotImplementedException();
    }

    public List<Color> GetAll()
    {
        throw new NotImplementedException();
    }

    public Color GetColorById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Color color)
    {
        throw new NotImplementedException();
    }
}
