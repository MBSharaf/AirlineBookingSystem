using AirlineBookingSystem.DataAccess;
using AirlineBookingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingSystem.Utilities.initializer
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityRole> _userManager;

        public DbInitializer(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityRole> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task Initializer() 
        {
            if (_context.Database.GetPendingMigrations().Any()) 
            {
                _context.Database.Migrate();
            }
            if (!_roleManager.Roles.Any()) 
            {
                await _roleManager.CreateAsync(new IdentityRole(CD.SUPER_ADMIN_ROLE));
                await _roleManager.CreateAsync(new IdentityRole(CD.ADMIN_ROLE));
                await _roleManager.CreateAsync(new IdentityRole(CD.CUSTOMER_ROLE));
            }


            var user = new ApplicationUser()
            {
                FirstName = "Super", 
                LastName = "Admin", 
                UserName = "SuperAdmin", 
                Email = "superadmin@gmail.com", 
                EmailConfirmed = true,
            };
            //await _userManager.CreateAsync();
        }
    }
}
