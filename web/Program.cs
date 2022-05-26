using web.Models;

namespace web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Добавление
            using (PhoneDBContext db = new PhoneDBContext())
            {
                if (!db.Phs.Any() && !db.Avts.Any())
                {
                    Phone ph1 = new Phone { Model = "Kia", Price = 918004, BrandId = 4 };
                    Phone ph2 = new Phone { Model = "Ford", Price = 620528, BrandId = 2 };
                    Phone ph3 = new Phone { Model = "Honda", Price = 841246, BrandId = 1 };
                    Phone ph4 = new Phone { Model = "BMW", Price = 3501499, BrandId = 3 };
                    Phone ph5 = new Phone { Model = "Audi", Price = 2288743, BrandId = 6 };

                    Brand br1 = new Brand { Name = "Honda Motor", Country = "Япония" };
                    Brand br2 = new Brand { Name = "Ford Motor", Country = "США" };
                    Brand br3 = new Brand { Name = "BMW", Country = "Германия" };
                    Brand br4 = new Brand { Name = "Hyundai–Kia", Country = "Южная Корея" };
                    Brand br5 = new Brand { Name = "General Motors", Country = "США" };
                    Brand br6 = new Brand { Name = "VAG", Country = "Германия" };
                    Brand br7 = new Brand { Name = "Daimler", Country = "Германия" };
                    Brand br8 = new Brand { Name = "Suzuki", Country = "Япония" };
                    Brand br9 = new Brand { Name = "Groupe PSA", Country = "Франция" };


                    // Добавление

                    db.Avts.Add(br1);
                    db.Avts.Add(br2);
                    db.Avts.Add(br3);
                    db.Avts.Add(br4);
                    db.Avts.Add(br5);
                    db.Avts.Add(br6);
                    db.Avts.Add(br7);
                    db.Avts.Add(br8);
                    db.Avts.Add(br9);

                    db.Phs.Add(ph1);
                    db.Phs.Add(ph2);
                    db.Phs.Add(ph3);
                    db.Phs.Add(ph4);
                    db.Phs.Add(ph5);
                }
                db.SaveChanges();
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
