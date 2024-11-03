using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebApplication1.Data;
using WebApplication1.Models.About;

namespace WebApplication1.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var teamMembers = _context.teamMembers.ToList();
            var teamMembersList = new List<TeamMemberVM>();
            var ourGoals = _context.ourGoals.ToList();
            var ourGoalsList = new List<OurGoalVM>();
            foreach (var teamMember in teamMembers)
            {
                var teamMemberVM = new TeamMemberVM
                {
                    Name = teamMember.Name,
                    Surname = teamMember.Surname,
                    PhotoPath = teamMember.PhotoPath,
                    Position = teamMember.Position,
                };
                teamMembersList.Add(teamMemberVM);
            }
            foreach (var ourGoal in ourGoals)
            {
                var ourGoalVM = new OurGoalVM
                {
                    Name = ourGoal.Name,
                    Info = ourGoal.Info,
                    IconURL = ourGoal.IconURL,
                };
                ourGoalsList.Add(ourGoalVM);
            }
            var model = new AboutIndexVM
            {
                TeamMembers = teamMembersList,
                OurGoals = ourGoalsList
            };
            return View(model);
        }
    }
}
