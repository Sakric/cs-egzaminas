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
    public class IndexModel : PageModel
    {
        private readonly WebApplication6.Data.cstestContext _context;

        public IndexModel(WebApplication6.Data.cstestContext context)
        {
            _context = context;
        }

        public IList<Visit> Visit { get;set; }

        public async Task OnGetAsync()
        {
            Visit = await _context.Visits
                .Include(v => v.Pet)
                .Include(v => v.User).ToListAsync();
            ViewData["Sum"] = VisitSum();
            ViewData["Avg"] = VisitAvg();
        }
        private float VisitSum()
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
