using Microsoft.AspNetCore.Mvc;
using System.Xml;
using WebApplication1.Data;
using WebApplication1.Models.Home;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var workOptions = _context.workOptions.ToList();
            var workOptionsList = new List<WorkOptionVM>();
            foreach (var workOption in workOptions)
            {
                var workOptionVM = new WorkOptionVM
                {
                    Name = workOption.Name,
                    Info = workOption.Info,
                    PhotoPath = workOption.PhotoPath
                };
                workOptionsList.Add(workOptionVM);
            }
            var model = new HomeIndexVM
            {
                WorkOptions = workOptionsList
             };
            return View(model); 
        }
    }
}
