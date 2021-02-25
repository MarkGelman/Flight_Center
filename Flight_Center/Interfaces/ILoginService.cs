using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center.Interfaces
{
    interface ILoginService
    {
        bool TryLogin(string username, string password);
    }
}
