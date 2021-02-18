using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest1();

            //CarTest2();

            //ColorTest();

            //BrandTest();

            //UserTest();

            //CustomerTest();

            //RentalTest();
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result1 = rentalManager.Add(new Rental
            {
                Id = 1,
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2021, 02, 13, 14, 20, 57),
                ReturnDate = null
            });
            var result2 = rentalManager.Add(new Rental
            {
                Id = 2,
                CarId = 2,
                CustomerId = 2,
                RentDate = new DateTime(2021, 02, 15, 13, 10, 20),
                ReturnDate = DateTime.Now
            });
            var result3 = rentalManager.Add(new Rental { Id = 3, CarId = 1, CustomerId = 2, RentDate = DateTime.Now });
            Console.WriteLine(result1.Message + "\n");
            Console.WriteLine(result2.Message);
            Console.WriteLine(result3.Message);

            var result4 = rentalManager.Update(new Rental
            {
                Id = 1,
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2021, 02, 15, 13, 10, 20),
                ReturnDate = DateTime.Now
            });
            Console.WriteLine(result4.Message);
            result3 = rentalManager.Add(new Rental { Id = 3, CarId = 1, CustomerId = 2, RentDate = DateTime.Now });
            Console.WriteLine(result3.Message);

            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine("Kiralanan araç adı : " + rental.CarName + "\nKiralayanın adı-soyadı : " +
                    rental.CustomerFirstName + " " + rental.CustomerLastName + "\nKiralama Tarihi : " + rental.RentDate);
                if (rental.ReturnDate == null)
                {
                    Console.WriteLine("Araç daha teslim edilmedi");
                }
                else
                {
                    Console.WriteLine("Teslim Tarihi : " + rental.ReturnDate);
                }
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            //var result1 = customerManager.Add(new Customer { CustomerId = 1, UserId = 2, CompanyName = "Company1" });
            //var result2 = customerManager.Add(new Customer { CustomerId = 2, UserId = 4, CompanyName = "Company3" });
            //Console.WriteLine(result1.Message);
            //Console.WriteLine(result2.Message);

            foreach (var customer in customerManager.GetCustomerDetails().Data)
            {
                Console.WriteLine(customer.CompanyName + " " + customer.CustomerFirstName + " " + customer.CustomerLastName);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            var result1 = userManager.Add(new User
            {
                Id = 1,
                FirstName = "Özcan",
                LastName = "Elmacı",
                Email = "oz.ozcan.elmaci55@gmail.com",
                Password = 000000
            });
            var result2 = userManager.Add(new User
            {
                Id = 2,
                FirstName = "User2",
                LastName = "Last2",
                Email = "Email2",
                Password = 22222
            });
            var result3 = userManager.Add(new User
            {
                Id = 3,
                FirstName = "User3",
                LastName = "Last3",
                Email = "Email3",
                Password = 33333
            });
            var result4 = userManager.Add(new User
            {
                Id = 4,
                FirstName = "User4",
                LastName = "Last4",
                Email = "Email4",
                Password = 44444
            });
            Console.WriteLine(result1.Message);
            Console.WriteLine(result2.Message);
            Console.WriteLine(result3.Message);
            Console.WriteLine(result4.Message);
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result1 = brandManager.Delete(new Brand { Id = 2, Name = "Mercedes" });
            var result2 = brandManager.Delete(new Brand { Id = 3, Name = "Range Rover" });
            Console.WriteLine(result1.Message);
            Console.WriteLine(result2.Message);

            var result3 = brandManager.Add(new Brand { Id = 2, Name = "Mercedes" });
            var result4 = brandManager.Add(new Brand { Id = 3, Name = "Range Rover" });
            Console.WriteLine(result3.Message);
            Console.WriteLine(result4.Message);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Id + " " + brand.Name);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result1 = colorManager.Delete(new Color { Id = 2, Name = "Orange" });
            var result2 = colorManager.Delete(new Color { Id = 3, Name = "Red" });
            Console.WriteLine(result1.Message);
            Console.WriteLine(result2.Message);

            var result3 = colorManager.Add(new Color { Id = 2, Name = "Orange" });
            var result4 = colorManager.Add(new Color { Id = 3, Name = "Red" });
            Console.WriteLine(result3.Message);
            Console.WriteLine(result4.Message);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Id + " " + color.Name);
            }
        }

        private static void CarTest2()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //var result1 = carManager.Add(new Car { CarId = 5, DailyPrice = 0, Description = "ak" });

            //Console.WriteLine(result1.Message);

            var result = carManager.GetById(4);

            if (result.Success)
            {
                Console.WriteLine(result.Data.Description);
                //foreach (var car in result.Data)
                //{
                //    Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
                //}
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarTest1()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result1 = carManager.Add(new Car { Id = 1, BrandId = 1, ColorId = 6, DailyPrice = 200, ModelYear = 2020, Description = "Cool Takılanlar" });
            var result2 = carManager.Add(new Car { Id = 2, BrandId = 4, ColorId = 5, DailyPrice = 150, ModelYear = 2021, Description = "Konfor Sevenler" });
            var result3 = carManager.Add(new Car { Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 100, ModelYear = 2019, Description = "Güvenlik İsteyenler" });
            var result4 = carManager.Add(new Car { Id = 4, BrandId = 3, ColorId = 3, DailyPrice = 250, ModelYear = 2021, Description = "SUV Sevenler" });

            Console.WriteLine(result1.Message);
            Console.WriteLine(result2.Message);
            Console.WriteLine(result3.Message);
            Console.WriteLine(result4.Message);

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Araba Adı : " + car.CarName + "\nAraba rengi : " + car.ColorName +
                    "\nAraba Markası : " + car.BrandName + "\nGünlük Fiyatı : " + car.DailyPrice + "$");
            }
        }
    }
}
