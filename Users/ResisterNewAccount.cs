using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public partial class User
    {
        SqlConnection con = new SqlConnection("server=DEL1-LHP-N70493;database=TradingCopies;integrated security=true");
        public void resisternewaccount()
        {
            Console.WriteLine("========New Account============");
            Console.WriteLine("===============================");
            Console.WriteLine("Enter your Name");
            name = Console.ReadLine();
            Console.WriteLine("Enter your phone number");
            phoneno = Console.ReadLine();
            Console.WriteLine("Enter your Email");
            email = Console.ReadLine();
            Console.WriteLine("Enter your password");
            password = Console.ReadLine();
            Console.WriteLine("Enter your balance");
            balance = double.Parse(Console.ReadLine());

            Console.WriteLine("===============================");


            SqlCommand cmd = new SqlCommand("insert into NewAccount values('" + name + "','" + phoneno + "','" + email + "','" + password + "'," + balance + ")", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Record inserted successfully");
        }
    }
}
