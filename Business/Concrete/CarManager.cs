using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car) 
        {
            if(car.name.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded); 
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>( _carDal.getAll(),Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.getAll(p => p.brandid == id));
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>> (_carDal.getAll(p => p.colorid == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails());

        }

        public IDataResult<Car> GetCarById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p=>p.id==id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
    }
}
