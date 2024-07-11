using DepoYonetimSistemi.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepoYonetimSistemi.DataAccessLayer;
using DepoYonetimSistemi.EntityLayer.Enums;

namespace DepoYonetimSistemi.DataAccessLayer.DBContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Depo> Depolar { get; set; }
        public DbSet<DepoHareket> DepoHareketleri { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<MalTur> MalTurleri { get; set; }
        public AppDbContext() : base("DepoYonetimSistemiDBTestTT") => Database.SetInitializer(new MyDatabaseInitializer());
    }

    public class MyDatabaseInitializer : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            base.Seed(context);

            Kullanici admin = new Kullanici { Ad = "Deneme", Soyad = "DenemeOğlu", EPosta = "user1@gmail.com", Parola = "123", ParolaTekrar = "123", Yetkiler = KullaniciYetkiler.Admin };
            Kullanici user = new Kullanici { Ad = "Deneme2", Soyad = "DenemeOğlu2", EPosta = "user2@gmail.com", Parola = "12345", ParolaTekrar = "12345", Yetkiler = KullaniciYetkiler.User };
            context.Kullanicilar.Add(admin);
            context.Kullanicilar.Add(user);


            Depo depo1 = new Depo { Ad = "Depo1" };
            Depo depo2 = new Depo { Ad = "Depo2" };
            Depo depo3 = new Depo { Ad = "Depo3" };
            context.Depolar.Add(depo1);
            context.Depolar.Add(depo2);
            context.Depolar.Add(depo3);


            MalTur maltur1 = new MalTur { Ad = "Kayısı" };
            MalTur maltur2 = new MalTur { Ad = "Kiraz" };
            MalTur maltur3 = new MalTur { Ad = "Vişne" };
            MalTur maltur4 = new MalTur { Ad = "Elma" };
            MalTur maltur5 = new MalTur { Ad = "Havuç" };
            context.MalTurleri.Add(maltur1);
            context.MalTurleri.Add(maltur2);
            context.MalTurleri.Add(maltur3);
            context.MalTurleri.Add(maltur4);
            context.MalTurleri.Add(maltur5);

            context.SaveChanges();
        }
    }
}
