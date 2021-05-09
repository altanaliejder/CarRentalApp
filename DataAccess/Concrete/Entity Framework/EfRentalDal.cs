using Core.DataAccess.Entity_Framework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.id
                             join b in context.Brands on c.brandid equals b.id
                             join o in context.Colors on c.colorid equals o.id
                             join m in context.Users on r.CustomerId equals m.Id
                             join n in context.Customers on m.Id equals n.UserId 
                             select new RentalDetailDto{RentId = r.Id, CarName=c.name,UserFirstName=m.FirstName,UserLastName=m.LastName,BrandName=b.name,Color=o.name,RentalDate=r.RentDate,ReturnDate=r.ReturnDate };
                return result.ToList();
            }
            
        }
    }
}
