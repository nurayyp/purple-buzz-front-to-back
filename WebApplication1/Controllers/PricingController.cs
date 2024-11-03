using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Models.About;
using WebApplication1.Models.Contact;
using WebApplication1.Models.Pricing;

namespace WebApplication1.Controllers
{
    public class PricingController : Controller
    {
        private readonly AppDbContext _context;
        public PricingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var pricingOptions = _context.pricingOptions.ToList();
            var pricingOptionsList = new List<PricingOptionVM>();
            foreach (var pricingOption in pricingOptions)
            {
                var pricingOptionVM = new PricingOptionVM
                {
                    IconURL = pricingOption.IconURL,
                    Name = pricingOption.Name,
                    Price = pricingOption.Price,
                    Info = pricingOption.Info,
                    Buy = pricingOption.Buy
                };
                pricingOptionsList.Add(pricingOptionVM);
            }
            var model = new PricingIndexVM
            { 
                PricingOptions = pricingOptionsList
            };
            return View(model);
        }
    }
}
