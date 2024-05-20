using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolves.Autofac;
using Core.DependencyResolvers;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Extensions;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
					  policy =>
					  {
						  policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
					  });
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<ICarService, CarManager>();
//builder.Services.AddSingleton<ICarDal,EFCarDal>();

//builder.Services.AddSingleton<IBrandService,BrandManager>();
//builder.Services.AddSingleton<IBrandDal,EFBrandDal>();

//builder.Services.AddSingleton<IColorService, ColorManager>();
//builder.Services.AddSingleton<IColorDal, EFColorDal>();

//builder.Services.AddSingleton<IUserService, UserManager>();
//builder.Services.AddSingleton<IUserDal, EfUserDal>();

//builder.Services.AddSingleton<ICustomerService, CustomerManager>();
//builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();

//builder.Services.AddSingleton<IRentalService,RentalManager>();
//builder.Services.AddSingleton<IRentalDal, EfRentalDal>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
               .ConfigureContainer<ContainerBuilder>(builder =>
               {
                   builder.RegisterModule(new AutofacBusinessModule());
               });


var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
//ServiceTool.Create(builder.Services);

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

var env = app.Services.GetRequiredService<IWebHostEnvironment>();

app.UseAuthentication(); //JWT
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();


app.MapControllers();

app.Run();
