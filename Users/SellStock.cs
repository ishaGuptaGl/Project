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
        StockCommonVariable scv = new StockCommonVariable();
        public void sellStock()
        {
            

            Console.Clear();
            Console.WriteLine("You are here to Sell the Stock");
            Console.WriteLine("Enter the name of the Stock you want to sell");
            scv.stockname = Console.ReadLine();
            Console.WriteLine("Enter the Quantity of the Stock");
            int quantity = int.Parse(Console.ReadLine());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from UserStockdetails", con);
            
            da.Fill(ds, "UserStockdetails");
            int buysell = 0;
            int count = ds.Tables[0].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                if (ds.Tables[0].Rows[i][3].ToString().Trim() == scv.stockname &&
                    ds.Tables[0].Rows[i][0].ToString().Trim() == email)
                {
                    if (ds.Tables[0].Rows[i][7].ToString().Trim() == "buy")
                        buysell += int.Parse(ds.Tables[0].Rows[i][6].ToString().Trim());
                    else if (ds.Tables[0].Rows[i][7].ToString().Trim() == "sell")
                        buysell -= int.Parse(ds.Tables[0].Rows[i][6].ToString().Trim());

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
                    
                    id = int.Parse(ds1.Tables[0].Rows[i][0].ToString());
                    name = ds1.Tables[0].Rows[i][1].ToString();
                    balance = double.Parse(ds1.Tables[0].Rows[i][5].ToString());
                    break;
                }
            }

            

            if (quantity > 0 && buysell >= quantity && getStockDetails())
            {
                
                scv.quantity += buysell;
                double brokrage = (quantity * scv.sellprice * scv.tradingfee) / 100;
                balance = balance + (quantity * scv.sellprice) - brokrage;

                
                sqlCommand = new SqlCommand("insert into UserStockdetails values("
                    + id + ",'"
                    + name + "',"
                    + scv.id + ",'"
                    + scv.stockname + "',"

                    + "'SELL',"
                    + scv.sellprice + ","
                    + buysell + ","
                    + brokrage + ")", con);
                SqlCommand cmd = new SqlCommand("update Stock set quantity=" + scv.quantity + " where stockName='" + scv.stockname + "' ", con);
                SqlCommand cmd1 = new SqlCommand("update NewAccount set user_Balance=" + balance + " where userEmail= '" + email + "' ", con);
                SqlCommand cmd2 = new SqlCommand("insert into UserStockdetails values('" +email+ "','" + name + "',"+scv.id+",'" + scv.stockname + "'," + scv.buyprice + "," + scv.sellprice + "," + quantity + ",'sell'," + brokrage + ")", con);
                con.Open();
                cmd2.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                con.Close();
                


                Console.WriteLine("Stock Sell Successfully");



            }
            else
            {
                Console.WriteLine("You don't have that much quantity to sell");
            }

        }

        bool getStockDetails()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Stock", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Stock");

            int count = ds.Tables[0].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (ds.Tables[0].Rows[i][1].ToString() == scv.stockname)
                {
                    scv.quantity = int.Parse(ds.Tables[0].Rows[i][5].ToString());
                    scv.sellprice = double.Parse(ds.Tables[0].Rows[i][4].ToString());
                    scv.tradingfee = double.Parse(ds.Tables[0].Rows[i][6].ToString());
                    Console.WriteLine(scv.quantity + " " + scv.buyprice + " " + scv.tradingfee);
                    return true;
                }
            }
            return false;
        }


    }
}
