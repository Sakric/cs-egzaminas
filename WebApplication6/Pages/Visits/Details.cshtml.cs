using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;

namespace WebApplication6.Pages.Visits
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication6.Data.cstestContext _context;

        public DetailsModel(WebApplication6.Data.cstestContext context)
        {
            _context = context;
        }

        public Visit Visit { get; set; }

        public IList<Visit> Visits { get; set; }


        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Visit = await _context.Visits
                .Include(v => v.Pet)
                .Include(v => v.User).FirstOrDefaultAsync(m => m.Id == id);


            Visits = await _context.Visits
            .Include(v => v.Pet)
            .Include(v => v.User).ToListAsync();
            ViewData["Sum"] = VisitSum();
            ViewData["Avg"] = VisitAvg();



            if (Visit == null)
            {
                return NotFound();
            }
            return Page();
        }
        private int VisitSum()
        {
            int sum = _context.Visits.Select(v => v.Price).Sum();
            return sum;
        }
        private double VisitAvg()
        {
            double avg = _context.Visits.Select(v => v.Price).Average();
            return avg;
        }
    }
}
