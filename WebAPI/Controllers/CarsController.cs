using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result= _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result=_carService.GetCarsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

		[HttpGet("getbybrandiddetail")]
		public IActionResult GetByBrandIdDetail(int id)
		{
			var result = _carService.GetCarsByBrandIdDetail(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result.Message);
		}

		[HttpGet("getbycoloriddetail")]
		public IActionResult GetByColorIdDetail(int id)
		{
			var result = _carService.GetCarsByColorIdDetail(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result.Message);
		}


		[HttpGet("getbycolorid")]
        public IActionResult GetByColorId(int id)
        {
            var result = _carService.GetCarsById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getdetail")]
        public IActionResult GetDetail()
        {
            var result=_carService.GetDetail();
            if (result.Success)
            {
                return Ok(_carService.GetDetail());
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result=_carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
           var result=_carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


		[HttpGet("Getimagedetail")]
		public IActionResult GetImageDetail(int id)
		{
			var result = _carService.GetCarImageByDetailDto(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getcarbybrandandcolor")]
		public IActionResult GetCarByBrandAndColor(int brandId, int colorId)
		{
			var result = _carService.GetCarByBrandAndColor(brandId, colorId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}



	}
}
