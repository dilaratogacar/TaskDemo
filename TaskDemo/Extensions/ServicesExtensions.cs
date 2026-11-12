using Microsoft.Extensions.DependencyInjection;
using Repositories.EFCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Services.Contracts;
using Services;

namespace TaskDemo.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration
            ) =>

            services.AddDbContext<RepositoryContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));



        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();


    }


}


// Her şey servis katmanında dönüyor. 
/*  
 Repositories katmanında bütün temel CRUD işlemleri yapılıyor sadece.
Services katmanı repo katmanından bilgileri alıyor ve kontroller yapıp, iş kurallarını ya da istenilen işlemleri yapıyor.
Sonra bu bilgileri presentation katmanına o katmanın anlayabileceği şekilde, filtreleyerek ya da işleyerek gönderiyor.
Sunum katmanında da bu bilgiler alınıp kullanıcıya sunuluyor.
Aynı şekilde sunum katmanından alınan veri de servis katmanı aracılığı ile işlenip, kontrol edilip, gereken kurallar
uygulanıp repo katmanının anlayacağı temellikte gönderiliyor ve repo katmanı da bu temel veriyi alıp CRUD işlemini yapıyor.
 
 */