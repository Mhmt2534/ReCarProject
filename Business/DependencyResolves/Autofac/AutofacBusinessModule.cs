using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolves.Autofac;

public class AutofacBusinessModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
       builder.RegisterType<CarManager>().As<ICarService>();
       builder.RegisterType<EFCarDal>().As<ICarDal>();

       builder.RegisterType<BrandManager>().As<IBrandService>();
       builder.RegisterType<EFBrandDal>().As<IBrandDal>();

       builder.RegisterType<ColorManager>().As<IColorService>();
       builder.RegisterType<EFColorDal>().As<IColorDal>();

       builder.RegisterType<UserManager>().As<IUserService>();
       builder.RegisterType<EfUserDal>().As<IUserDal>();
       
       builder.RegisterType<CustomerManager>().As<ICustomerService>();
       builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
      
       builder.RegisterType<RentalManager>().As<IRentalService>();
       builder.RegisterType<EfRentalDal>().As<IRentalDal>();

        builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
        builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

		builder.RegisterType<CreditCardManager>().As<ICreditCardService>().SingleInstance();
		builder.RegisterType<EfCreditCardDal>().As<ICreditCardDal>().SingleInstance();



		builder.RegisterType<FileHelperManager>().As<IFileHelperService>().SingleInstance();



        builder.RegisterType<AuthManager>().As<IAuthService>();
        builder.RegisterType<JwtHelper>().As<ITokenHelper>();


        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();



    }


}
