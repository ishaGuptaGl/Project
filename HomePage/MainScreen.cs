using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin;
using Users;

namespace HomePage
{
    public class MainScreen
    {
        /*Admin.AdminLogin al = new Admin.AdminLogin();*/
        admin al = new admin();
        User user = new User();
        public void mainscreen()
        {
            
            while (true)
            {

                Console.WriteLine("1.> Admin ");
                Console.WriteLine("-----------------------");
                Console.WriteLine("2.> User  ");
                Console.WriteLine("-----------------------");
                Console.WriteLine("3.> Resister Account  ");
                Console.WriteLine("-----------------------");

                int n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        al.admin_login();
                        break;
                    case 2:
                        user.userlogin();
                        
                        break;
                    case 3:
                        user.resisternewaccount();
                        break;
                }
            }
        }
    }
}
