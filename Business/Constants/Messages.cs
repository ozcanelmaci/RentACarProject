using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarDeleted = "Araba silindi";
        internal static string CarsListed = "Arabalar listelendi";
        public static string CarNameOrDailyPriceInvalid = "Araba ismi veya günlük fiyatı geçersiz";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";
        internal static string BrandsListed = "Markalar listelendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";
        internal static string ColorsListed = "Renkler listelendi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";
        internal static string UsersListed = "Kullanıcılar listelendi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerDeleted = "Müşteri silindi";
        internal static string CustomersListed = "Müşteriler listelendi";

        public static string RentalAdded = "Kiralama işlemi eklendi";
        public static string RentalUpdated = "Kiralama işlemi güncellendi";
        public static string RentalDeleted = "Kiralama işlemi silindi";
        internal static string RentalsListed = "Kiralama işlemleri listelendi";
        internal static string RentalCarInvalid = "Araç teslim edilmeden kiralanamaz";
    }
}
