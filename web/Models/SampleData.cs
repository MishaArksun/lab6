namespace web.Models
{
    public class SampleData
    {
        public static void Initialize(PhoneDBContext context)
        {
            //IServiceProvider serviceProvider
            //MobileContext context = serviceProvider.GetService(typeof(MobileContext)) as MobileContext;
            if (!context.Phs.Any())
            {
                context.Phs.AddRange(
                    new Phone
                    {
                        Id = 1,
                        Model = "iPhone X",
                        Price = 60000
                    },
                    new Phone
                    {
                        Id = 2,
                        Model = "Samsung Galaxy Edge",
                        Price = 35565
                    },
                    new Phone
                    {
                        Id = 3,
                        Model = "Pixel 3",
                        Price = 20500
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
