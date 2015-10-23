using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using DigDes.DSchool.SUPS.DataAccess.Interface;

namespace DigDes.DSchool.SUPS.DataAccess.PresentData
{
    public class ReportPresent
    {
        private static readonly string key = "SUPSDB";

        public static ReportInfo GetReportInfo(SqlDataReader sqlDR)
        {
            ReportInfo row = new ReportInfo();

            row.CarNumber = DBNullToString(sqlDR["CarNumber"]);
            row.LoadTime = sqlDR["LoadTime"].ToString();
            row.UnloadTime = DBNullToString(sqlDR["UnloadTime"]);
            row.DepartTime = DBNullToString(sqlDR["DepartTime"]);
            row.ArriveTime = DBNullToString(sqlDR["ArriveTime"]);

            return row;
        }

        public static List<ReportInfo> GetAllReports()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[key].ConnectionString;

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("spReport", sqlConn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    List<ReportInfo> report = new List<ReportInfo>();
                    sqlConn.Open();

                    using (SqlDataReader sqlDR = sqlCmd.ExecuteReader())
                    {
                        while (sqlDR.Read())
                            report.Add(GetReportInfo(sqlDR));
                    }
                    return report;
                }
            }
        }

        public static List<ReportInfo> GetOneReport(string CarNumber)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[key].ConnectionString;

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("spOneReport", sqlConn))
                {
                    sqlCmd.Parameters.AddWithValue("@CarNumber", CarNumber);

                    List<ReportInfo> report = new List<ReportInfo>();
                    sqlConn.Open();

                    using (SqlDataReader sqlDR = sqlCmd.ExecuteReader())
                    {
                        while (sqlDR.Read())
                            report.Add(GetReportInfo(sqlDR));
                    }
                    return report;
                }
            }
        }

        public static DateTime DBNullToDateTime(object obj)
        {
            if (obj is DBNull)
                return new DateTime();
            else
                return (DateTime)obj;
        }

        public static string DBNullToString(object obj)
        {
            if (obj is DBNull)
                return string.Empty;
            else
                return obj.ToString();
        }
    }
}
