using DigDes.DSchool.SUPS.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigDes.DSchool.SUPS.BusinessLogic;

namespace DigDes.DSchool.SUPS.DataAccess.Database
{
    public class FileLoaderDAC : BaseDAC
    {
        private static readonly string key = "SUPSDB";
        /// <summary>
        /// Метод, загружающий строку, полученную из файла, в БД
        /// </summary>
        /// <param name="row">Строка, полученная из файла</param>
        public static void InsertRow(CarInfo row)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[key].ConnectionString;

            //using (SqlConnection sqlConn = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand sqlCmd = sqlConn.CreateCommand())
            //    {
            //        sqlCmd.CommandText = "DELETE FROM CarDB";
            //        sqlConn.Open();
            //        sqlCmd.ExecuteNonQuery();
            //    }
            //}
            

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCmd = sqlConn.CreateCommand())
                {
                    sqlCmd.CommandText = "insert into CarDB (CarNumber, Weight, ArriveStation, CargoCode, ReceiverCode, CarType, DepartStation, OperationCode, OperationDate, OperationYear, OperationTime, OperationStation, DeliveryRoad, ReceiptRoad, TrainIndex, TrainNumber, CarDateTime) " +
                        " values (@carNumber, @weight, @arriveStation, @cargoCode, @receiverCode, @carType, @departStation, @operationCode, @operationDate, @operationYear, @operationTime, @operationStation, @deliveryRoad, @receiptRoad, @trainIndex, @trainNumber, @carDateTime)";
                    SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@carNumber", row.carNumber),
                        new SqlParameter("@weight", row.weight),
                        new SqlParameter("@arriveStation", row.arriveStation),
                        new SqlParameter("@cargoCode", row.cargoCode),
                        new SqlParameter("@receiverCode", row.receiverCode),
                        new SqlParameter("@carType", row.carType),
                        new SqlParameter("@departStation", row.departStation),
                        new SqlParameter("@operationCode", row.operationCode),
                        new SqlParameter("@operationDate", row.operationDate),
                        new SqlParameter("@operationYear", row.operationYear),
                        new SqlParameter("@operationTime", row.operationTime),
                        new SqlParameter("@operationStation", row.operationStation),
                        new SqlParameter("@deliveryRoad", row.deliveryRoad),
                        new SqlParameter("@receiptRoad", row.receiptRoad),
                        new SqlParameter("@trainIndex", row.trainIndex),
                        new SqlParameter("@trainNumber", row.trainNumber),
                        new SqlParameter("@carDateTime", row.carDateTime)
                    };

                    sqlConn.Open();
                    sqlCmd.Parameters.AddRange(parameters);

                    sqlCmd.ExecuteNonQuery();
                }
            }


            //BaseDAC baseDAC = new BaseDAC();
            //BaseDAC.CreateCommand("spInsertRowCarDB", parameters);

            //baseDAC.CreateCommand("spInsertRowCarDB", parameters);
        }

        /// <summary>
        /// Метод, загружающий все строки, полученные из файла, в БД
        /// </summary>
        /// <param name="rows">Строки, полученные из файла</param>
        public static void InsertListRows(IEnumerable<CarInfo> rows)
        {
            foreach (var row in rows)
                InsertRow(row);
        }
    }
}
