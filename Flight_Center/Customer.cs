using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Center
{
    class Customer:IPoco,IUser
    {
        public long Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string Phone_No { get; set; }
        public string Credit_Card_No { get; set; }
        public long User_Id { get; set; }

        public Customer()
        {


        }

        public Customer(long id,string first_name,string last_name,string address,string phone_no,string credit_card_no,long user_id)
        {
            Id = id;
            First_Name = first_name;
            Last_Name = last_name;
            Address = address;
            Phone_No = phone_no;
            Credit_Card_No = credit_card_no;
            User_Id = user_id;
        }





    }
}
