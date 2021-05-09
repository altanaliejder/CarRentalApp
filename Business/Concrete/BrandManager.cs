using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IDataResult<Brand> GetById(int brandId)
        {
            try
            {
                return new SuccessDataResult<Brand>(_brandDal.Get(c => c.id == brandId));
            }
            catch (Exception)
            {

                return new ErrorDataResult<Brand>(Messages.BrandErrorListed);
            }
        }

        public IDataResult< List<Brand>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Brand>>(_brandDal.getAll(), Messages.BrandListed);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Brand>>(Messages.BrandErrorListed);
            }
            
        }
        public IResult Add(Brand brand)
        {
            try
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.BrandErrorDeleted);
            }
        }
        public IResult Update(Brand brand)
        {
            try
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.BrandErrorUpdated);
            }
        }
        public IResult Delete(Brand brand)
        {
            try
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.BrandDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.BrandErrorDeleted);
            }
        }
    }
}
