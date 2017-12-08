using Example.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Data
{
    public class ExampleDbInitializer
    {
        private static ExampleContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (ExampleContext)serviceProvider.GetService(typeof(ExampleContext));

            InitializeSchedules();
        }

        private static void InitializeSchedules()
        {
            if(!context.ExampleEntitys.Any())
            {
                context.ExampleEntitys.Add(new ExampleEntity { Name = "Chip DeBergh" });
                context.SaveChanges();
            }

            context.SaveChanges();
        }
    }
}
