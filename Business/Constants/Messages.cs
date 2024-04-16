using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants;

public static class Messages
{
    public static string CarsListed = "Cars Listed";
    public static string CarCall = "Car Call";
    public static string CarAdded = "Car Added";
    public static string CarDeleted = "Car Deleted";
    public static string CarUpdated = "Car Updated";
    public static string NotCar = "There isn't car";
    public static string CarNotAdded = "Car not added. Name of the car must be minimum 2 characters and Daily Price must be greater than 0 ";


    public static string BrandListed = "Brands Listed";
    public static string BrandCall = "Brand Call";
    public static string BrandAdded = "Brand Added";
    public static string BrandDeleted = "Brand Deleted";
    public static string BrandUpdated = "Brand Updated";
    public static string NotBrand = "There isn't brand";

    public static string ColorListed = "Colors Listed";
    public static string ColorCall = "Color Call";
    public static string ColorAdded = "Color Added";
    public static string ColorDeleted = "Color Deleted";
    public static string ColorUpdated = "Color Updated";
    public static string NotColor = "There isn't color";

    public static string UserListed = "Users Listed";
    public static string UserCall = "User Call";
    public static string UserAdded = "User Added";
    public static string UserDeleted = "User Deleted";
    public static string UserUpdated = "User Updated";
    public static string NotUser = "There isn't user";

    public static string CustomerListed = "Customers Listed";
    public static string CustomerCall = "Customer Call";
    public static string CustomerAdded = "Customer Added";
    public static string CustomerDeleted = "Customer Deleted";
    public static string CustomerUpdated = "Customer Updated";
    public static string NotCustomer = "There isn't customer";

    public static string MaintenanceTime = "SistemBakımda";
    public static string noRental = "Araba hala kullanımda";
    public static string Rentall = "Araba Kiralandı";
    internal static string ImageAdded="de";
    internal static string CarImageDeleted;
    internal static string ImageUpdated;
    internal static string CarImageLimitReached;
    internal static string CarImageAlreadyHave;
    internal static string ImagesListedByCarId;
    internal static string ImagesListed;
    internal static string ImagesListedById;
    internal static string UserRegistered;
    internal static User UserNotFound;
    internal static User PasswordError;
    internal static string SuccessfulLogin;
    internal static string UserAlreadyExists;
    internal static string AccessTokenCreated;
    internal static string? AuthorizationDenied;
}
