using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CreditCartController : ControllerBase
	{
		private readonly ICreditCardService _creditCardService;
        public CreditCartController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

		[HttpGet("getall")]
		public IActionResult Get()
		{
			var result = _creditCardService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result.Message);
		}


		[HttpGet("getbyid")]
		public IActionResult GetById(string KrediKartiNo)
		{
			var result = _creditCardService.GetById(KrediKartiNo);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result.Message);
		}


		[HttpGet("paymentsystem")]
		public IActionResult Payment(string KrediKartiNo, string KartIsim, string SonKullanmaTarihi, string CVV)
		{
			var result = _creditCardService.Payment(KrediKartiNo,KartIsim,SonKullanmaTarihi,CVV);

			return Ok(result);


		}


	}
}
