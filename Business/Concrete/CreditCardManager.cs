using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CreditCardManager : ICreditCardService
	{
		private readonly ICreditCardDal _creditCardDal;
        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCart creditCart)
		{

			_creditCardDal.Add(creditCart);
			return new SuccessResult(Messages.CarAdded);
		}

		public IResult Delete(CreditCart creditCart)
		{
			throw new NotImplementedException();
		}

		public IDataResult<List<CreditCart>> GetAll()
		{
			return new SuccessDataResult<List<CreditCart>>(_creditCardDal.GetAll(), Messages.CarsListed);
		}

		public IDataResult<CreditCart> GetById(string KrediKartiNo)
		{
			var res = _creditCardDal.Get(c => c.KrediKartiNo == KrediKartiNo);
			if (res == null)
			{
				return new ErrorDataResult<CreditCart>(Messages.NotCar);
			}
			return new SuccessDataResult<CreditCart>(_creditCardDal.Get(c => c.KrediKartiNo == KrediKartiNo), Messages.CarCall);
		}

		public IResult Payment(string KrediKartiNo, string KartIsim, string SonKullanmaTarihi, string CVV)
		{
			var result = _creditCardDal.GetAll(p => p.KrediKartiNo == KrediKartiNo && p.KartIsim==KartIsim&&p.SonKullanmaTarihi==SonKullanmaTarihi&&p.CVV==CVV).Any();
			if (!result)
			{
				return new ErrorDataResult<List<CreditCart>>(Messages.noRental);
			}
			return new SuccessDataResult<List<CreditCart>>(_creditCardDal.GetAll(p => p.KrediKartiNo == KrediKartiNo && p.KartIsim == KartIsim && p.SonKullanmaTarihi == SonKullanmaTarihi && p.CVV == CVV), Messages.canRental);
		}

		public IResult Update(CreditCart creditCart)
		{
			_creditCardDal.Update(creditCart);
			return new SuccessResult(Messages.CarUpdated);
		}
	}
}
