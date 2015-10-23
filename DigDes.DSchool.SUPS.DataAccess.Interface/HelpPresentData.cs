using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using DigDes.DSchool.SUPS.DataAccess;
using DigDes.DSchool.SUPS.DataAccess.Interface;

namespace DigDes.DSchool.SUPS.DataAccess.Database
{
    /// <summary>
    /// Вспомогательный класс-модель представления данных
    /// </summary>
    public class HelpPresentData
    {
        public string carNumber { get; set; }
        public string weight { get; set; }
        public string cargoName { get; set; }
        public string cargoDescr { get; set; }
        public string cargoGNGName { get; set; }
        public string cargoETSNGName { get; set; }
        public string operationName { get; set; }
        public string roadName { get; set; }
        public string regionName { get; set; }
        public string CTM_CountryName { get; set; }
        public string trainIndex { get; set; }
        public string trainNumber { get; set; }
    }
}







/* public IEnumerable<MyLoader1DTO> SelectAllData(string carNumber, string weight, string cargoName,
            string cargoDescr, string cargoGNGName, string cargoETSNGName, string operationName,
            string roadName, string regionName, string CTM_CountryName, string trainIndex, string trainNumber)
        {
            using (var sqlConn = new SqlConnection(BaseDAC.connectionString))
            {
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@CarNumber", carNumber),
                        new SqlParameter("@Weight", weight),
                        new SqlParameter("@CargoName", cargoName),
                        new SqlParameter("@CargoDescr", cargoDescr),
                        new SqlParameter("@CargoGNGName", cargoGNGName),
                        new SqlParameter("@CargoETSNGName", cargoETSNGName),
                        new SqlParameter("@OperationName", operationName),
                        new SqlParameter("@RoadName", roadName),
                        new SqlParameter("@RegionName", regionName),
                        new SqlParameter("@CTM_CountryName", CTM_CountryName),
                        new SqlParameter("@TrainIndex", trainIndex),
                        new SqlParameter("@TrainNumber", trainNumber),
                    };

                sqlConn.Open();
                string query = "SELECT * FROM ResultTable";
                SqlCommand sqlCmd = new SqlCommand(query, sqlConn);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                MyLoader1DTO row;

                while (dr.Read())
                {
                    row = new MyLoader1DTO();
                    row.carNumber = (string)dr["CarNumber"];
                    row.weight = (string)dr["Weight"];
                    row.arriveStation = (string)dr["ArriveStation"];
                    row.cargoCode = (string)dr["CargoCode"];
                    row.receiverCode = (string)dr["ReceiverCode"];
                    row.carType = (string)dr["CarType"];
                    row.departStation = (string)dr["DepartStation"];
                    row.operationCode = (string)dr["OperationCode"];
                    row.dateOfOperation = (string)dr["OperationDate"];
                    row.operationYear = (string)dr["OperationYear"];
                    row.operationTime = (string)dr["OperationTime"];
                    row.stationOfOperation = (string)dr["StationOfOperation"];
                    row.deliveryRoad = (string)dr["DeliveryRoad"];
                    row.receiptRoad = (string)dr["ReceiptRoad"];
                    row.trainIndex = (string)dr["TrainIndex"];
                    row.trainNumber = (string)dr["TrainNumber"];
                    yield return row;
                }
            }*/