using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center.Interfaces.DAO
{
    interface ICustomerDAO:IBasicDb<Customer>
    {
        Customer GetCustomerByUsername(string username);
    }
}
