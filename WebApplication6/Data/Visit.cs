using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApplication6.Data
{
    public partial class Visit : Ivisit
    {
        public long Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public long PetId { get; set; }
        [Range(1, 1000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public int Price { get; set; }

        public virtual Pet Pet { get; set; }
        public virtual User User { get; set; }

        public string isAverage(double avg)
        {
            if(avg > Price)
            {
                return "Mažesnis";
            }
            if (avg == Price)
            {
                return "Lygus";
            }
            return "Didesnis";

        }
    }
}
