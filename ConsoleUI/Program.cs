using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryCarDal;
using Entities.Concrete;

CarManager carManager=new CarManager(new EFCarDal());
foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}


Console.WriteLine("");

/*
Car car1 = new Car();
car1.CarId = 7;
car1.BrandId = 4;
car1.ColorId = 2;
car1.ModelYear = 2019;
car1.DailyPrice = 120000;
car1.Description = "2019 model siyah BMW";

carManager.Add(car1);
*/


BrandManager brandManager = new(new EFBrandDal());


foreach (var brand in brandManager.GetAll())
{
    Console.WriteLine(brand.BrandName);
}
