using AirlineBookingSystem.DataAccess;
using AirlineBookingSystem.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Areas.Admin.Controllers
{
    [Area(CD.ADMIN_AREA)]
    [Authorize(Roles = $"{CD.SUPER_ADMIN_ROLE} , {CD.ADMIN_ROLE}")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly Repository<Hotel> _homeRepository;
        public HomeController(ApplicationDbContext context)
        {
            //_context = new ApplicationDbContext();
            _context = context; //new Repository<Hotel>();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
