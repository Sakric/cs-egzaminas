using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Web;
using WebApplication6.Data;

#nullable disable

namespace WebApplication4.Data
{
    public class UserPetCount : User
    {
        public int? PetCount { get; set; }

        public UserPetCount(long id, string name, string lastname, string email, int petcount)
        {
            this.Id = id;
            this.Name = name;
            this.Lastname = lastname;
            this.Email = email;
            this.PetCount = petcount;
        }

    }
}
