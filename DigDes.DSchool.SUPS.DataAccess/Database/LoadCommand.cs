using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DigDes.DSchool.SUPS.DataAccess.Database
{
    /// <summary>
    /// Вспомогательный класс, отвечающий за создание команд и их выполнение
    /// </summary>
    public class LoadCommand : BaseDAC
    {
        private SqlCommand sqlCmd;

        public LoadCommand(string spName)
        {
            sqlCmd = CreateCommand(spName);
        }

        public LoadCommand(string spName, SqlParameter[] parameters)
        {
            sqlCmd = CreateCommand(spName, parameters);
        }

        public void ExecuteCommand()
        {
            using (sqlCmd.Connection)
            {
                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
            }
        }
    }
}
