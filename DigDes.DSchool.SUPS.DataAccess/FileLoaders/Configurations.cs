using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DigDes.DSchool.SUPS.BusinessLogic
{
    public static class Configurations
    {
        public static SqlConnection Connection()
        {
            try
            {
                var sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SUPSDB"].ConnectionString.ToString());
                return sqlConn;
            }
            catch (Exception e)
            {
                throw new ConfigurationErrorsException("Невозможно установить соединение", e);
            }
        }
    }
}
