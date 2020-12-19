using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPFinal.Models;
using Microsoft.AspNetCore.Identity;

namespace ASPFinal.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public List<Transaction> Transactions { get; set; }
    }
}
