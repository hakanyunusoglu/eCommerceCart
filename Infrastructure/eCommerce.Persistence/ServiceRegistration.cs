using eCommerce.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<eCommerceDbContext>(options => options.UseSqlServer("Server=.\\SQLEXPRESS;Database=eCommerceDB; Trusted_Connection=true;"));
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
        public static void AddSeedDatabase(this IApplicationBuilder app, eCommerceDbContext dbcontext)
        {
            SeedDatabase.Seed(dbcontext);
        }
    }
}
