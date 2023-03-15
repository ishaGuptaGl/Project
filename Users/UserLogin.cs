using Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public partial class User
    {
        StockTable st = new StockTable();
        public void userlogin()
        {
            Console.WriteLine("Enter your Email :");
            email = Console.ReadLine();
            Console.WriteLine("Enter your Password :");
            password = Console.ReadLine();
            Console.WriteLine("=====================");


            if (authenticate())
            {
                //st.viewStockDetails();
                uoperations();
            }

            Console.WriteLine("....................................................................................................................................................................");

            Console.WriteLine(".............................................................................................................................");

        }
        public bool authenticate()
        {



            SqlDataAdapter da = new SqlDataAdapter("select * from NewAccount", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "NewAccount");
            bool flag = true;

            int c = ds.Tables[0].Rows.Count;
            for (int i = 0; i < c; i++)
            {

                if (email == ds.Tables[0].Rows[i][3].ToString().Trim() && password == ds.Tables[0].Rows[i][4].ToString().Trim())
                {
                    Console.WriteLine("authenticated");
                    return true;
                    break;
                }


            }

            Console.WriteLine("Account does not exists");

            return false;

        }
    }
}
