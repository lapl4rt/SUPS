using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DigDes.DSchool.SUPS.DataAccess.PresentData
{
    public class RoadGuidePresent
    {
        private static readonly string key = "SUPSDB";
        string connectionString = ConfigurationManager.ConnectionStrings[key].ConnectionString;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public RoadGuidePresent() { }

        public RoadGuide GetRoadGuideInfo(SqlDataReader sqlDR)
        {
            RoadGuide row = new RoadGuide();

            row.Road_ID = (sqlDR["Road_ID"]).ToString();
            row.Name = (sqlDR["Name"]).ToString();
            row.Code = (sqlDR["Code"]).ToString();
            row.Mnemocode = (sqlDR["Mnemocode"]).ToString();

            return row;
        }

        public List<RoadGuide> GetRoadGuide()
        {
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("spSelectRoadGuide", sqlConn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConn.Open();

                    List<RoadGuide> roads = new List<RoadGuide>();

                    using (SqlDataReader sqldR = sqlCmd.ExecuteReader())
                    {
                        while (sqldR.Read())
                            roads.Add(GetRoadGuideInfo(sqldR));

                        if (sqldR != null)
                            sqldR.Close();
                    }
                    return roads;
                }
            }
        }

        public RoadGuide GetRoadByID(string Road_ID)
        {
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCmd = sqlConn.CreateCommand())
                {
                    sqlCmd.CommandText = "Select * from Road where Road_ID = @Road_ID";
                    sqlCmd.Parameters.AddWithValue("@Road_ID", Road_ID);

                    RoadGuide roads = new RoadGuide();
                    sqlConn.Open();

                    using (SqlDataReader sqlDR = sqlCmd.ExecuteReader())
                    {
                        while (sqlDR.Read())
                            roads = GetRoadGuideInfo(sqlDR);

                        if (sqlDR != null)
                            sqlDR.Close();
                    }
                    return roads;
                }
            }
        }

        public void DeleteOneRowRoadGuide(string Road_ID)
        {
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCmd = sqlConn.CreateCommand())
                {
                    sqlCmd.CommandText = "DELETE FROM Road WHERE Road_ID = @Road_ID";
                    sqlCmd.Parameters.AddWithValue("@Road_ID", Road_ID);
                    sqlConn.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateOneRowRoadGuide(
            string Road_ID,
            string Name,
            string Code,
            string Mnemocode
            )
        {
            if (Name == null) Name = string.Empty;
            if (Code == null) Code = string.Empty;
            if (Mnemocode == null) Mnemocode = string.Empty;

            var connstring = ConfigurationManager.ConnectionStrings[key].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connstring))
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Road_ID", Road_ID),
                    new SqlParameter("@Name", Name),
                    new SqlParameter("@Code", Code),
                    new SqlParameter("@Mnemocode", Mnemocode)
                };

                using (SqlCommand sqlCmd = sqlConn.CreateCommand())
                {
                    sqlCmd.CommandText = "UPDATE Road SET Name=@Name, Code=@Code, Mnemocode=@Mnemocode, " +
                        " WHERE Road_ID = @Road_ID";
                    sqlCmd.Parameters.AddRange(parameters);
                    sqlConn.Open();
                    sqlCmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
            }
        }

        public void InsertRowRoadGuide(
            string Name,
            string Code,
            string Mnemocode
            )
        {
            if (Name == null) Name = string.Empty;
            if (Code == null) Code = string.Empty;
            if (Mnemocode == null) Mnemocode = string.Empty;

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Name", Name),
                    new SqlParameter("@Code", Code),
                    new SqlParameter("@Mnemocode", Mnemocode)
                };

                using (SqlCommand sqlCmd = sqlConn.CreateCommand())
                {
                    sqlCmd.CommandText = "INSERT INTO Road  " +
                        " (Name, Code, Mnemocode) " +
                        " Values(@Name, @Code, @Mnemocode)";

                    sqlCmd.Parameters.AddRange(parameters);
                    sqlConn.Open();
                    sqlCmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
            }
        }

    }
}
