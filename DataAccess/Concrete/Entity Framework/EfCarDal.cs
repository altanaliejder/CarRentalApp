using Core.DataAccess.Entity_Framework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using(CarRentalContext context=new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.brandid equals b.id
                             join e in context.Colors on c.colorid equals e.id
                             select new CarDetailDto { CarName=c.name,BrandName = b.name,  CarId = c.id, DailyPrice = c.dailyprice,ColorName=e.name };
                return result.ToList();
            }
            
        }
    }
}
