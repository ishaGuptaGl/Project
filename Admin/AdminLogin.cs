using Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users;

namespace Admin
{
    public partial class admin
    {
        SqlConnection con = new SqlConnection("server=DEL1-LHP-N70493;database=TradingCopies;integrated security=true");
        StockTable st = new StockTable();
        PrintStar pt = new PrintStar();
        public void admin_login()
        {

            pt.print_line();
            Console.WriteLine("Enter your Email : ");
            email = Console.ReadLine();
            Console.WriteLine("Enter your Password : ");
            pwd = Console.ReadLine();
            pt.print_line();
            authenticate();
        }
        public void authenticate()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Admin", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Admin");

            if (email == ds.Tables[0].Rows[0][0].ToString().Trim() && pwd == ds.Tables[0].Rows[0][1].ToString().Trim())
            {

               st.viewStockDetails();

            }
            else
            {
                Console.WriteLine("Account does not exists");
                Console.WriteLine("=======================");
            }
        }
    }
}
