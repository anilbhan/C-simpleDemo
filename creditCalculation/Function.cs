using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace creditCalculation
{
  public class Function
    {
        public static void FunctionCalling()
        {
            string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection)) ;
            
        }


    }
}
