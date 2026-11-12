
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore.Config;



namespace Repositories.EFCore
{
    // Veritabanı ve uygulama arasındaki köprü,


    public class RepositoryContext : DbContext
    {
        //EF Core'ın hangi ayarlarla çalışacağının belirlendiği kısım
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }
        //DBSet EFCore'da tabloyu temsil eder.
        //<ModelAdi> Model'in tablosunu tanımlar,migration ile tablolar oluşur.
        //Veritabanındaki ilgili tabloya erişim sağlanır.
        //Veritabanındaki her bir tablo için DBSet tanımlanır. DBContext yani köprü tektir ve başta tanımlanır.
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Status> Status { get; set; }
        //public DbSet<Status> Status { get; set; }



        //Tabloların nasıl oluşturulacağı, ilişkilerin nasıl kurulacağı bu kısımda belirlenir.
        // new BookConfig() bu sınıfta tablonun  kuralları, ilişkileri tanımlanır.


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Birden fazla tablo yazılabilir. Her bir tablonun new BookConfig() ilişkilerin kurulduğu, kuralların belirlendiği
            // sınıfları olabilir.
            modelBuilder.ApplyConfiguration(new TasksConfig());
            modelBuilder.ApplyConfiguration(new CategoriesConfig());
            modelBuilder.ApplyConfiguration(new StatusConfig());
        }
    }
}
