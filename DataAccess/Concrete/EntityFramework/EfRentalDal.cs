using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, testDataBaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using(testDataBaseContext context = new testDataBaseContext())
            {
                var result = from re in context.Rentals
                             join ca in context.Cars
                             on re.CarId equals ca.Id
                             join cu in context.Customers
                             on re.CustomerId equals cu.Id
                             join u in context.Users
                             on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 CarName = ca.Description,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
