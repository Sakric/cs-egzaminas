using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication6.Data
{
    public partial class User
    {
        public User()
        {
            Pets = new HashSet<Pet>();
            Visits = new HashSet<Visit>();
        }

        public long Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Lastname { get; set; }
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }

        public virtual bool isExpnesive(int num)
        {
            return false;
        }
        public string ToUpperCase(string word)
        {
            return char.ToUpper(word[0]) + word.Substring(1);
        }
    }
}
