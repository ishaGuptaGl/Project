using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public partial class User
    {
        public void uoperations()
        {
            while (true)
            {

                Console.WriteLine("1.> Buy Stocks :");
                Console.WriteLine("2.> Sell Stocks :");
                Console.WriteLine("3.> View Balance :");
                Console.WriteLine("4.> Add Money :");
                Console.WriteLine("5.> Withdraw Money :");
                Console.WriteLine("6.> Exit ");

                int n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        buy_stock();
                        break;
                    case 2:
                        sellStock();
                        break;
                    case 3:
                        checkBalance();
                        break;
                    case 4:
                        addBalance();
                        break;
                    case 5:
                        withdrawBalance();
                        break;
                    case 6:

                        break;
                }
            }
        }
    }
}
