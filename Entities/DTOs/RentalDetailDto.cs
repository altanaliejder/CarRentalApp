using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public int RentId { get; set; }
        public string BrandName { get; set; }
        public string Color { get; set; }
        public string CarName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public DateTime? RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
