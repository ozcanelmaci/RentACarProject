using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;//global değişkenleri sektörde bu şekilde yazarız

        public InMemoryCarDal()
        {
            //Oracle,Sql Server , Postgres, MongoDb gibi yerlerden gelmiş gibi düşünüyoruz
            _cars = new List<Car> { 
                new Car{Id = 1, BrandId = 1, ColorId = 6, DailyPrice = 200, ModelYear = 2020,Description = "Cool Takılanlar"},
                new Car{Id = 2, BrandId = 4, ColorId = 5, DailyPrice = 150, ModelYear = 2021,Description = "Konfor Sevenler"},
                new Car{Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 100, ModelYear = 2019,Description = "Güvenlik İsteyenler"},
                new Car{Id = 4, BrandId = 3, ColorId = 3, DailyPrice = 250, ModelYear = 2021,Description = "SUV Sevenler"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)//referans tip olduğu için onun tuttuğu adresi bulmamız gerekir
        {
            //LINQ - Language Integrated Query
            //Lambda - '=>' işaretin adı
            Car productToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);//bu bize adres döndürecek
                                                                             //gibi düşünebiliriz

            _cars.Remove(productToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(p => p.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            //Gönderdiğim ürün id'sine sahip olan ürünü listede bul ve adresini tut
            Car productToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            productToUpdate.BrandId = car.BrandId;
            productToUpdate.ColorId = car.ColorId;
            productToUpdate.DailyPrice = car.DailyPrice;
            productToUpdate.Description = car.Description;
            productToUpdate.ModelYear = car.ModelYear;
        }
    }
}
