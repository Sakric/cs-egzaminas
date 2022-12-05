using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;

namespace WebApplication6.Pages.Visits
{
    public class EditModel : PageModel
    {
        private readonly WebApplication6.Data.cstestContext _context;

        public EditModel(WebApplication6.Data.cstestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Visit Visit { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Visit = await _context.Visits
                .Include(v => v.Pet)
                .Include(v => v.User).FirstOrDefaultAsync(m => m.Id == id);

            if (Visit == null)
            {
                return NotFound();
            }
           ViewData["PetId"] = new SelectList(_context.Pets, "Id", "PetName");
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
           ViewData["WRONG"] = "";

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var test = _context.Pets.Where(p => p.Id == Visit.PetId).Where(u => u.UserId == Visit.UserId);
            if (test.Count() < 1)
            {
                ViewData["PetId"] = new SelectList(_context.Pets, "Id", "PetName");
                ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
                ViewData["WRONG"] = "TOKS VARTOTOJAS NETURI TOKIO GYVUNO";
                return Page();
            }

            _context.Attach(Visit).State = EntityState.Modified;





            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitExists(Visit.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VisitExists(long id)
        {
            return _context.Visits.Any(e => e.Id == id);
        }

   
    }
}
