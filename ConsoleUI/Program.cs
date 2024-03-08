using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryCarDal;
using Entities.Concrete;


CarManager carManager=new CarManager(new EFCarDal());
/*
foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}

Console.WriteLine("");
*/

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

/*
BrandManager brandManager = new(new EFBrandDal());


foreach (var brand in brandManager.GetAll())
{
    Console.WriteLine(brand.BrandName);
}

Console.WriteLine("");
Console.WriteLine("");
*/


/*
Car car1 = new Car();
car1 = carManager.GetCarsById(2);
Console.WriteLine(car1.Description);
*/

/*
Car car2 = new Car();
car2.CarId = 12;
car2.BrandId = 1;
car2.ColorId = 3;
car2.ModelYear = 2015;
car2.DailyPrice = 30000;
car2.Description = "2019 model kirmizi Ford";

carManager.Delete(car2);
*/


foreach (var car in carManager.GetDetail())
{
    Console.WriteLine(car.CarName + " / " +car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice + " TL");
}
