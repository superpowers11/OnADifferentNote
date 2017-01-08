using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnADifferentNote.Services
{
    public interface IUserService
    {
        User CreateUser(string email = "NoEmail@none.no", string userName = "NoUserName", string password="Password");
    }
}
