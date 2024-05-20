using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class CreditCart:IEntity
	{
		[Key]
		public string KrediKartiNo { get; set; }
		public string KartIsim { get; set; }
		public string SonKullanmaTarihi { get; set; }
		public string CVV { get; set; }
	}
}
