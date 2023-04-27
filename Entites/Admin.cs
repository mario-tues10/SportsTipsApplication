using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class Admin : User
    {
        public Admin(string username, string email, string password, UserRole userRole) : base(username, email, password, userRole) {}
    }
}
