using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication6.Data
{
    public partial class Pet
    {
        public Pet()
        {
            Visits = new HashSet<Visit>();
        }

        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string PetName { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Group { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
