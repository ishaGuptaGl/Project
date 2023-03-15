using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    public class StockTable
    {
        SqlConnection con = new SqlConnection("server=DEL1-LHP-N70493;database=TradingCopies;integrated security=true");
        static int tableWidth = 120;

        public void viewStockDetails()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Stock", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Stock");

            Console.Clear();
            PrintLine();
            PrintRow("SNO.", "Stock_ID", "Stock_Name", "Company_Name", "Buy_Price", "Sell_Price", "Quantity", "Trading_Fee");
            List<StockCommonVariable> stockList = new List<StockCommonVariable>();
            int i;

            int c = ds.Tables[0].Rows.Count;
            for (i = 0; i < c; i++)
            {
                StockCommonVariable stock = new StockCommonVariable();

                stock.id = int.Parse(ds.Tables[0].Rows[i][0].ToString().Trim());
                stock.stockname = ds.Tables[0].Rows[i][1].ToString().Trim();
                stock.companyname = ds.Tables[0].Rows[i][2].ToString().Trim();
                stock.buyprice = double.Parse(ds.Tables[0].Rows[i][3].ToString().Trim());
                stock.sellprice = double.Parse(ds.Tables[0].Rows[i][4].ToString().Trim());
                stock.quantity = int.Parse(ds.Tables[0].Rows[i][5].ToString().Trim()); ;
                stock.tradingfee = double.Parse(ds.Tables[0].Rows[i][3].ToString().Trim()); ;
                stockList.Add(stock);
            }
            i = 0;
            foreach (var stock in stockList)
            {
                i++;
                PrintLine();
                PrintRow(i.ToString(), stock.id.ToString(), stock.stockname, stock.companyname,
                    stock.buyprice.ToString(), stock.sellprice.ToString(), stock.quantity.ToString(), stock.tradingfee.ToString());
                PrintLine();
            }

        }
        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }


        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
