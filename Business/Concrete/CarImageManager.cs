using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageCountOfCarCorrect(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        //public IDataResult<List<CarImage>> GetByCarId(int carId)
        //{
        //    IResult result = BusinessRules.Run(CheckIfImageOfAnyCarExists(carId));
        //    if (result != null)
        //    {
        //        return new SuccessDataResult<List<CarImage>>();
        //    }
        //    return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId));
        //}

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfImageCountOfCarCorrect(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageCountOfCarError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfImageOfAnyCarExists(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId);
            if (result == null)
            {
                return new ErrorResult(Messages.ImageCountOfCarError);
            }
            return new SuccessResult();
        }
    }
}
