using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalServices;

        public RentalsController(IRentalService rentalServices)
        {
            _rentalServices = rentalServices;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalServices.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

		[HttpGet("getrentalbycarid")]
		public IActionResult GetAll(int id)
		{
			var result = _rentalServices.GetRentalsByCarId(id);
			
				return Ok(result);
			
			
		}

		[HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalServices.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Rentals rentals)
        {
            var result = _rentalServices.Add(rentals);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rentals rentals)
        {
            var result = _rentalServices.Delete(rentals);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Rentals rentals)
        {
            var result = _rentalServices.Update(rentals);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getdetail")]
        public IActionResult GetDetail()
        {
            var result=_rentalServices.GetDetail();
			if (result.Success)
			{
				return Ok(_rentalServices.GetDetail());
			}
			return BadRequest(result.Message);
		}

    }
}
