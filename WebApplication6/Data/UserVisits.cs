using System;
using System.Collections.Generic;
using System.Web;
using WebApplication6.Data;

#nullable disable

namespace WebApplication4.Data
{
    public partial class UserVisits : User
    {   

        public DateTime Date { get; set; }
        public int Price { get; set; }
        public bool? Expensvive { get; set; }

        public UserVisits(string name, string lastname, string email, DateTime date, int price)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
            Date = date;
            Price = price;
            Expensvive = isExpnesive(price);
        }
        public override bool isExpnesive(int num)
        {
            if (num >= 120)
            {
                return true;
            }
            return false;

        }
    }
}
