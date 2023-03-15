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
        public void withdrawBalance()
        {
            Console.WriteLine("Enter the Amount to be Withdraw");
            double balance = double.Parse(Console.ReadLine());
            SqlDataAdapter da2 = new SqlDataAdapter("select * from NewAccount", con);
            DataSet ds3 = new DataSet();
            da2.Fill(ds3, "NewAccount");
            int count = ds3.Tables[0].Rows.Count;
            double balance1 = 0;


            for (int i = 0; i < count; i++)
            {
                if (ds3.Tables[0].Rows[i][3].ToString() == email)
                {
                    balance1 = double.Parse(ds3.Tables[0].Rows[i][5].ToString());
                    balance = balance1 - balance;
                    SqlCommand cmd3 = new SqlCommand("update NewAccount set user_Balance=" + balance + "where userEmail= '" + email + "'", con);
                    Console.WriteLine(balance);
                    con.Open();
                    cmd3.ExecuteNonQuery();


                    con.Close();
                    Console.WriteLine("Stock is buyed Successfully");
                    Console.WriteLine("==============================================================================================");
                    break;

                }
            }
        }
    }
}
