using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace YoungHastaneProje
{
    class SqlBaglanti
    {
        public SqlConnection Baglan()
        { 
            SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-6QV6JSF\SQLEXPRESS;Initial Catalog=dbo_YoungHastane;Integrated Security=True");
            bag.Open();
            return bag;
       }
    }
}
