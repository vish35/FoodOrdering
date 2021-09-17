using System;
using Foodordering.Areas.Identity.Data;
using Foodordering.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Foodordering.Areas.Identity.IdentityHostingStartup))]
namespace Foodordering.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FoodorderingContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FoodorderingContextConnection")));

            //   services.AddDefaultIdentity<FoodorderingUser>(options => options.SignIn.RequireConfirmedAccount = true)
              //      .AddEntityFrameworkStores<FoodorderingContext>();
            });
        }
    }
}