using System;
using System.Collections.Generic;
using System.Web;
using WebApplication6.Data;

#nullable disable

namespace WebApplication4.Data
{
    public partial class UserPet : User
    {   
        public string? PetName { get; set; }
        public string? PetGroup { get; set; }

        public UserPet(long id, string name, string lastname, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Lastname = lastname;
            this.Email = email;
        }
        public UserPet(long id, string name, string lastname, string email, string petname, string petgroup)
        {
            this.Id = id;
            this.Name = name;
            this.Lastname = lastname;
            this.Email = email;
            this.PetGroup = petgroup;
            this.PetName = petname;
        }
    }
}
