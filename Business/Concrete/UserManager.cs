using Business.Abstract;
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
    public class UserManager:IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            try
            {
                _userDal.Add(user);
                return new SuccessResult("Başarıyla eklendi");
            }
            catch (Exception)
            {

                return new ErrorResult("Ekleme başarısız");
            }
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("Silindi");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.getAll(),"Başarıyla listelendi");
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), "Başarıyla listelendi");
        }

        public IResult Update(User user)
        {
            return new SuccessResult("Güncellendi");
        }
    }
}
