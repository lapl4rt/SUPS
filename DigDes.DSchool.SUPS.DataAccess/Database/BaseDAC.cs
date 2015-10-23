using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using DigDes.DSchool.SUPS.BusinessLogic;

namespace DigDes.DSchool.SUPS.DataAccess.Database
{
    /// <summary>
    /// Вспомогательный класс, отвечающий за создание комманд по хранимой процедуре
    /// </summary>
    public class BaseDAC 
    {
        private static SqlConnection sqlConn = Configurations.Connection();

        public static SqlCommand CreateCommand(string spName)
        {
            var sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = spName;
            return sqlCmd;
        }

        public static SqlCommand CreateCommand(string spName, SqlParameter[] parameters)
        {
            var sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = spName;
            sqlCmd.Parameters.AddRange(parameters);
            return sqlCmd;
        }
    }
}
