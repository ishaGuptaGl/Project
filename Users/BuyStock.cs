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
    public partial class User:IBuy_Stock
    {
        

        public void buy_stock()
        {

           StockCommonVariable scv = new StockCommonVariable();

            Console.Clear();
            Console.WriteLine("You are here to BuY the Stock");
            Console.WriteLine("Enter the name of the Stock you want to buy");
            scv.stockname = Console.ReadLine();
            Console.WriteLine("Enter the Quantity of the Stock");
            int quantity = int.Parse(Console.ReadLine());

            SqlDataAdapter da = new SqlDataAdapter("select * from Stock", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Stock");

            int count = ds.Tables[0].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (ds.Tables[0].Rows[i][1].ToString() == scv.stockname)
                {
                    scv.id= int.Parse(ds.Tables[0].Rows[i][0].ToString());
                    scv.quantity = int.Parse(ds.Tables[0].Rows[i][5].ToString());
                    scv.buyprice = double.Parse(ds.Tables[0].Rows[i][3].ToString());
                    scv.tradingfee = double.Parse(ds.Tables[0].Rows[i][6].ToString());
                    Console.WriteLine(scv.quantity + " " + scv.buyprice + " " + scv.tradingfee);
                    break;
                }
            }
            SqlDataAdapter da1 = new SqlDataAdapter("select * from NewAccount", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "NewAccount");
            count = ds1.Tables[0].Rows.Count;
            double balance1 = 0;


            for (int i = 0; i < count; i++)
            {
                if (ds1.Tables[0].Rows[i][3].ToString() == email)
                {
                    balance1 = double.Parse(ds1.Tables[0].Rows[i][5].ToString());
                    id = int.Parse(ds1.Tables[0].Rows[i][0].ToString());
                    name = ds1.Tables[0].Rows[i][1].ToString();
                    break;
                }
            }

            double brokrage = (quantity * scv.buyprice * scv.tradingfee) / 100;
            balance1 = balance1 - (quantity * scv.buyprice) - brokrage;


            if (balance1 >= 0)
            {
                if (scv.quantity > quantity)
                {
                    scv.quantity -= quantity;

                    SqlCommand cmd = new SqlCommand("update Stock set quantity=" + scv.quantity + " where stockName='" + scv.stockname + "' ", con);
                    SqlCommand cmd1 = new SqlCommand("update NewAccount set user_Balance=" + balance1 + " where userEmail= '" + email + "' ", con);
                    SqlCommand cmd2 = new SqlCommand("insert into UserStockdetails values('" + email + "','"+name+"',"+scv.id+",'" + scv.stockname + "'," + scv.buyprice + "," + scv.sellprice + "," + quantity + ",'buy',"+brokrage+")", con);
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    Console.WriteLine("Stock is buyed Successfully");
                    Console.WriteLine("********************************");
                }
                else
                {
                    Console.WriteLine("Numbers of stock you want Buy is Greater than Stock's stock Plz buy less stocks");
                }
            }
            else
            {
                Console.WriteLine("Balance is Low! add Balance using sqlServer value");
            }
            Console.WriteLine("Press 1 to go Back");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:

                    break;
            }
        }
    }
}
