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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.name.Length < 2)
            {
                return new ErrorResult(Messages.ColorErrorAdded);
            }
            else
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }
        }

        public IResult Delete(Color color)
        {
            try
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ColorErrorDeleted);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Color>>(_colorDal.getAll(), Messages.ColorListed);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Color>>(Messages.ColorErrorListed);
            }
        }

        public IDataResult<Color> GetColorById(int id)
        {
            try
            {
                return new SuccessDataResult<Color>(_colorDal.Get(c => c.id == id));
            }
            catch (Exception)
            {

                return new ErrorDataResult<Color>(Messages.ColorErrorListed);
            }
        }

        public IResult Update(Color color)
        {
            try
            {
                return new SuccessResult(Messages.ColorUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ColorErrorUpdated);
            }
        }
    }
}
