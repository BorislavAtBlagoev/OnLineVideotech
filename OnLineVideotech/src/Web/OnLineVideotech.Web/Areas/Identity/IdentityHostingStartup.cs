using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnLineVideotech.Web.Areas.Identity.Data;
using OnLineVideotech.Web.Models;

[assembly: HostingStartup(typeof(OnLineVideotech.Web.Areas.Identity.IdentityHostingStartup))]
namespace OnLineVideotech.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<OnLineVideotechContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("OnLineVideotechContextConnection")));

                services.AddDefaultIdentity<User>()
                    .AddEntityFrameworkStores<OnLineVideotechContext>();
            });
        }
    }
}