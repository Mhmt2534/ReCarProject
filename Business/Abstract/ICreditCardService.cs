using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICreditCardService
	{
		IDataResult<List<CreditCart>> GetAll();
		IDataResult<CreditCart> GetById(string KrediKartiNo);

		IResult Add(CreditCart creditCart);
		IResult Update(CreditCart creditCart);
		IResult Delete(CreditCart creditCart);
		IResult Payment(string KrediKartiNo, string KartIsim, string SonKullanmaTarihi, string CVV);
	}
}
