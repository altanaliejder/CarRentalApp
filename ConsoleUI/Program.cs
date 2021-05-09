using Business.Concrete;
using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //UserTest();
            //CustomerTest();
            RentalTest();

        }

        private static void RentalTest()
        {
            Rental rental = new Rental();
            rental.Id = 2;
            rental.CarId = 2;
            rental.CustomerId = 2;
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetail();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.RentId + " "
                        + item.BrandName+" "
                        +item.Color+" "
                        + item.CarName + " "
                        + item.UserFirstName + " "
                        + item.UserLastName + " "
                        + item.RentalDate.ToString() + " "
                        + item.ReturnDate.ToString()
                        ); 

                    //Console.WriteLine(item.Id + " " + item.CustomerId);
                }
                //Console.WriteLine("Basarili");//date e bak
            }
        }

        private static void CustomerTest()
        {
            Customer customer = new Customer();
            customer.Id = 2;
            customer.UserId = 1;
            customer.CompanyName = "Havelsan";

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(customer);
            if (!result.Success)
            {
                Console.WriteLine("Basarisiz");
            }
        }

        private static void UserTest()
        {
            User user = new User();
            user.Id = 2;
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Delete(user);
            if (result.Success)
            {
                Console.WriteLine("Basarili");
                var list = userManager.GetAll();
                if (list.Success)
                {
                    foreach (var item in list.Data)
                    {
                        Console.WriteLine(item.FirstName);
                    }
                }
            }
        }

        private static void BrandTest()
        {

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.name);
                }
            } 
            
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success) { 

                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.CarName + "/ " + item.BrandName +"/ " + item.ColorName+"/ "+item.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

    }
}
