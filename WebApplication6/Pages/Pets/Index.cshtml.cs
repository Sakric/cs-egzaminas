using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApplication4.Data;
using WebApplication6.Data;

namespace WebApplication6.Pages.Pets
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication6.Data.cstestContext _context;

        public IndexModel(WebApplication6.Data.cstestContext context)
        {
            _context = context;
        }

        public IList<Pet> Pet { get;set; }

        public IList<PetUser> PetUser { get; set; }


        public async Task OnGetAsync()
        {
            var DataQuery = from pets in _context.Pets
                            join users in _context.Users
                            on pets.UserId equals users.Id
                            into EmployeeAddressGroup
                            from address in EmployeeAddressGroup.DefaultIfEmpty()
                            select new PetUser
                            {
                                Id = pets.Id,
                                Name = pets.PetName,
                                Group = pets.Group,
                                UserName = address.Name,
                                UserLastname = address.Lastname,
                                Email = address.Email
                            };

            PetUser = await DataQuery.ToListAsync();

            Pet = await _context.Pets.ToListAsync();
        }
    }
}
