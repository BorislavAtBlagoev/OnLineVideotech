using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnLineVideotech.Web.Areas.Identity.Data;

namespace OnLineVideotech.Web.Models
{
    public class OnLineVideotechContext : IdentityDbContext<User>
    {
        public OnLineVideotechContext(DbContextOptions<OnLineVideotechContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
