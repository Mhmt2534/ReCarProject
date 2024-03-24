using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalCustomerDetail:IDto
    {
        public string CompanyName {  get; set; }
        public List<CarDetailDto> CarDetails { get; set; }

    }
}
