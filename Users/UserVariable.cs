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
        public int id;
        public string name;
        public string phoneno;
        public string email;
        public string password;
        public double balance;
        private SqlCommand sqlCommand;
        /*public int quantity;*/
    }
}
