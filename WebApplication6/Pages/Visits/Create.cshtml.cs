using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication6.Data;

namespace WebApplication6.Pages.Visits
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication6.Data.cstestContext _context;

        public CreateModel(WebApplication6.Data.cstestContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PetId"] = new SelectList(_context.Pets, "Id", "PetName");
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["WRONG"] = "";
            return Page();
        }

        [BindProperty]
        public Visit Visit { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var test = _context.Pets.Where(p => p.Id == Visit.PetId).Where(u => u.UserId == Visit.UserId);
            if (test.Count() >= 1)
            {
                _context.Visits.Add(Visit);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            ViewData["PetId"] = new SelectList(_context.Pets, "Id", "PetName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["WRONG"] = "TOKS VARTOTOJAS NETURI TOKIO GYVUNO";
            return Page();

        }
    }
}
