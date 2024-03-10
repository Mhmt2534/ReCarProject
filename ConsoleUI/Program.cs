using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryCarDal;
using Entities.Concrete;


CarManager carManager=new CarManager(new EFCarDal());

var result = carManager.GetDetail();
Console.WriteLine(result.Message);
foreach (var car in result.Data)
{
    Console.WriteLine(car.CarName + " / " + car.BrandName);
}

Console.WriteLine("");


/*
Car car1 = new Car();
car1.CarId = 8;
car1.BrandId = 2;
car1.ColorId = 3;
car1.ModelYear = 2020;
car1.DailyPrice = 120000;
car1.Description = "2018 model Beyaz Toyota";
car1.CarName = "Toyota AR";
*/


/*
var result=carManager.Add(car1);

if (result.Success)
{
    Console.WriteLine(result.Message);
}
else
{
    Console.WriteLine(result.Message);
}
*/


/*
var result = carManager.Delete(car1);

if (result.Success)
{
    Console.WriteLine(result.Message);
}
else
{
    Console.WriteLine(result.Message);
}
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

/*
foreach (var car in carManager.GetDetail())
{
    Console.WriteLine(car.CarName + " / " +car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice + " TL");
}
*/









