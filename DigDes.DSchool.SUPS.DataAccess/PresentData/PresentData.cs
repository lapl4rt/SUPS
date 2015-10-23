using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Configuration;
using DigDes.DSchool.SUPS.DataAccess.Interface;
using DigDes.DSchool.SUPS.DataAccess.Database;

namespace DigDes.DSchool.SUPS.DataAccess.PresentData
{
    public class PresentData
    {
        public PresentData() { }

        public SqlDataReader GetInfo()
        {
            using (var sqlCmd = BaseDAC.CreateCommand("spSelectDislocations"))
            {
                return sqlCmd.ExecuteReader();
            }
        }

        public Dislocation GetCarInfo(SqlDataReader sqlDR)
        {
            Dislocation row = new Dislocation();

            row.cargoName = ConvertFromDBVal<string>(sqlDR["CargoName"]);
            row.carNumber = ConvertFromDBVal<string>(sqlDR["CarNumber"]);
            row.weight = ConvertFromDBVal<string>(sqlDR["Weight"]);
            row.receiverCode = ConvertFromDBVal<string>(sqlDR["ReceiverCode"]);
            row.carType = ConvertFromDBVal<string>(sqlDR["CarType"]);
            row.operationName = ConvertFromDBVal<string>(sqlDR["OperationName"]);
            row.arriveStation = ConvertFromDBVal<string>(sqlDR["ArriveStation"]);
            row.operationStation = ConvertFromDBVal<string>(sqlDR["OperationStationName"]);
            row.departStation = ConvertFromDBVal<string>(sqlDR["DepartStation"]);
            row.operationDate = ConvertFromDBVal<string>(sqlDR["OperationDate"]);
            row.operationYear = ConvertFromDBVal<string>(sqlDR["OperationYear"]);
            row.operationTime = ConvertFromDBVal<string>(sqlDR["OperationTime"]);
            row.deliveryRoad = ConvertFromDBVal<string>(sqlDR["DeliveryRoad"]);
            row.receiptRoad = ConvertFromDBVal<string>(sqlDR["ReceiptRoad"]);
            row.trainIndex = ConvertFromDBVal<string>(sqlDR["TrainIndex"]);
            row.trainNumber = ConvertFromDBVal<string>(sqlDR["TrainNumber"]);

            return row;
        }

        public List<Dislocation> GetDislocations()
        {
            List<Dislocation> list = new List<Dislocation>();
            string connectionString = ConfigurationManager.ConnectionStrings["SUPSDB"].ConnectionString.ToString();

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("spSelectDislocations", sqlConn))
                {

                    sqlConn.Open();

                    //using(SqlDataReader sqlDR = GetInfo())
                    using (SqlDataReader sqlDR = sqlCmd.ExecuteReader())
                    {
                        while (sqlDR.Read())
                            list.Add(GetCarInfo(sqlDR));
                    }
                    return list;
                }
            }
        }

        /// <summary>
        /// Метод, осуществляющий преобразование типа System.DBNull к типу <see cref=" T"/>
        /// </summary>
        /// <typeparam name="T">Тип, к которому осуществляется преобразование</typeparam>
        /// <param name="obj">Объект, преобразование типа которого происходит</param>
        /// <returns>тип <see cref=" T"/></returns>
        public static T ConvertFromDBVal<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(T);
            }
            else
            {
                return (T)obj;
            }
        }
    }
}
