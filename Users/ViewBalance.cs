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
        public void checkBalance()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("select * from NewAccount", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "NewAccount");
            int count = ds2.Tables[0].Rows.Count;
            double balance1 = 0;


            for (int i = 0; i < count; i++)
            {
                if (ds2.Tables[0].Rows[i][3].ToString() == email)
                {
                    balance1 = double.Parse(ds2.Tables[0].Rows[i][5].ToString());
                    Console.WriteLine(balance1);
                    break;

                }
            }
        }

    }
}
