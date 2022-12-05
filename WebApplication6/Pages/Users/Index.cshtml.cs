using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApplication4.Data;
using WebApplication6.Data;
using Rotativa.AspNetCore;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication6.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication6.Data.cstestContext _context;

        public IndexModel(WebApplication6.Data.cstestContext context)
        {
            _context = context;
        }

        public IList<User> User { get; set; }

        public IList<UserPet> UserPet { get; set; }
        public IList<UserPetCount> UserPetCount { get; set; }
        public IList<UserPet> UserPet2 { get; set; }

        public IFormFile upload { get; set; }

        public async Task OnGetAsync()
        {
            /*
            var list = _context.Users.LeftJoin(_context.Pets, user => user.Id, pet => pet.UserId,
                (user, pet) => new UserPet
                {
                    Name = user.Name,
                    Lastname = user.Lastname,
                    Email = user.Email,
                    PetName = pet.PetName ?? "",
                    PetGroup = pet.Group ?? ""
                });
            */
            var DataQuery = from user in _context.Users
                            join pet in _context.Pets
                            on user.Id equals pet.UserId
                            into EmployeeAddressGroup
                            from address in EmployeeAddressGroup.DefaultIfEmpty()
                            select new UserPet
                            (
                                user.Id,
                                user.Name,
                                user.Lastname,
                                user.Email,
                                address.PetName,
                                address.Group
                            );

            var DataQuery2 = from user in _context.Users
                            join pet in _context.Pets
                            on user.Id equals pet.UserId
                            into EmployeeAddressGroup
                            from address in EmployeeAddressGroup.DefaultIfEmpty()
                            select new
                            {
                                user.Id,
                                user.Name,
                                user.Lastname,
                                user.Email,
                                address.PetName,
                                address.Group
                            };


            UserPet = await DataQuery.ToListAsync();
            UserPetCount = (IList<UserPetCount>)DataQuery2.OrderBy(u => u.Name).GroupBy(u => new {u.Id, u.Name, u.Lastname, u.Email }).Select(grp => new UserPetCount
            (
                grp.Key.Id,
                grp.Key.Name,
                grp.Key.Lastname,
                grp.Key.Email,
                grp.Count()
            )).ToList();

            User = await _context.Users.ToListAsync();
            
        }
    }
}
