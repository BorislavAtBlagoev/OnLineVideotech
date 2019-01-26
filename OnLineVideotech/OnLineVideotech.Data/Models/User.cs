using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnLineVideotech.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public List<HistoryCustomer> Histories { get; set; }
    }
}