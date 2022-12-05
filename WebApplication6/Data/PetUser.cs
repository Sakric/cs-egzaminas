using System;
using System.Collections.Generic;
using WebApplication6.Data;

#nullable disable

namespace WebApplication4.Data
{
    public partial class PetUser
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? UserLastname { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Email { get; set; }
        public int Price { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
