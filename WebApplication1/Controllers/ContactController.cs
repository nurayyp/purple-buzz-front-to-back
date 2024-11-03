using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models.About;
using WebApplication1.Models.Contact;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contactPurposes = _context.contactPurposes.ToList();
            var contactPurposesList = new List<ContactPurposeVM>();
            foreach (var contactPurpose in contactPurposes)
            {
                var contactPurposeVM = new ContactPurposeVM()
                {
                    IconURL = contactPurpose.IconURL,
                    Name = contactPurpose.Name,
                    Owner = contactPurpose.Owner,
                    PhoneNumber = contactPurpose.PhoneNumber
                };
                contactPurposesList.Add(contactPurposeVM);
            }
            var model = new ContactIndexVM
            {
                ContactPurposes = contactPurposesList
            };
            return View(model);
        }
    }
}
