using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication6.Data;

namespace WebApplication6.Pages.laikinas
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication6.Data.cstestContext _context;

        public DetailsModel(WebApplication6.Data.cstestContext context)
        {
            _context = context;
        }

        public User User { get; set; }
        public IList<Visit> Visit { get; set; }
        public IList<UserVisits> UserVisits { get; set; }


        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JoinUsersVizits(id);

            User = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);


            if (UserVisits == null)
            {
                return NotFound();
            }
            return Page();
        }

        private void JoinUsersVizits(long? id)
        {
            UserVisits = _context.Users.Where(m => m.Id == id).Join(_context.Visits, u => u.Id, v => v.UserId, (u, v) => new UserVisits(
                u.Name,
                u.Lastname,
                u.Email,
                v.Date,
                v.Price)
            ).ToList();
        }

    }
}
