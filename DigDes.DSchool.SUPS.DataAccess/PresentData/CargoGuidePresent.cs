using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Configuration;

namespace DigDes.DSchool.SUPS.DataAccess.PresentData
{
    public class CargoGuidePresent
    {
        private static readonly string key = "SUPSDB";
        string connectionString = ConfigurationManager.ConnectionStrings[key].ConnectionString;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public class CargoGuide
        {
            public CargoGuide() { }

            public string Cargo_ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string ShortCode { get; set; }
            public string Code { get; set; }
            public string CodeGNG { get; set; }
            public string Mnemocode { get; set; }
            public string IsUsed { get; set; }
            public string IsEmpty { get; set; }
        }

        public int GetTotalNumberOfCargo()
        {
            using(SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("spGetTotalNumber", sqlCon))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCon.Open();
                    int number = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    sqlCon.Close();
                    return number;
                }
            }
        }

        public CargoGuide GetCargoGuideInfo(SqlDataReader sqlDR)
        {
            CargoGuide row = new CargoGuide();

            row.Cargo_ID = DBNullToString(sqlDR["Cargo_ID"]);
            row.Name = DBNullToString(sqlDR["Name"]);
            row.Description = DBNullToString(sqlDR["Description"]);
            row.ShortCode = DBNullToString(sqlDR["ShortCode"]);
            row.Code = DBNullToString(sqlDR["Code"]);
            row.CodeGNG = DBNullToString(sqlDR["CodeGNG"]);
            row.Mnemocode = DBNullToString(sqlDR["Mnemocode"]);
            row.IsUsed = DBNullToString(sqlDR["IsUsed"]);
            row.IsEmpty = DBNullToString(sqlDR["IsEmpty"]);

            return row;
        }

        public List<CargoGuide> GetCargoGuide(int startIndex, int pageSize)
        {
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("spSelectCargo", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@startIndex", startIndex);
                    sqlCmd.Parameters.AddWithValue("@pageSize", pageSize);
                    
                    sqlConn.Open();

                    List<CargoGuide> cargo = new List<CargoGuide>();

                    using (SqlDataReader sqlDR = sqlCmd.ExecuteReader())
                    {
                        while (sqlDR.Read())
                            cargo.Add(GetCargoGuideInfo(sqlDR));

                        if (sqlDR != null)
                            sqlDR.Close();
                        sqlConn.Close();
                    }
                    return cargo;
                }
            }
        }

        /// <summary>
        /// Выбрать строку из справочника по коду груза
        /// </summary>
        /// <param name="CargoCode">Код груза</param>
        /// <returns></returns>
        public CargoGuide GetCargoByCode(string Cargo_ID)
        {
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {

                using (SqlCommand sqlCmd = sqlConn.CreateCommand())
                {
                    sqlCmd.CommandText = "SELECT * FROM Cargo where Cargo.Cargo_ID = @Cargo_ID";
                    sqlCmd.Parameters.AddWithValue("@Cargo_ID", Int32.Parse(Cargo_ID));
                    CargoGuide cargo = new CargoGuide();
                    sqlConn.Open();

                    using (SqlDataReader sqlDR = sqlCmd.ExecuteReader())
                    {
                        while (sqlDR.Read())
                            cargo = GetCargoGuideInfo(sqlDR);

                        if (sqlDR != null)
                            sqlDR.Close();
                        sqlConn.Close();
                    }
                    return cargo;
                }
            }
        }

        public static byte[] GetImage(int Cargo_ID)
        {
            string connString = ConfigurationManager.ConnectionStrings[key].ConnectionString;

            byte[] image = null;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand sqlCmd = new SqlCommand("SELECT Image FROM Cargo WHERE Cargo_ID = @Cargo_ID", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Cargo_ID", Cargo_ID);
                    sqlConn.Open();

                    image = DBNullToByteArr((byte[])sqlCmd.ExecuteScalar());
                }
            }
            return image;
        }

        /// <summary>
        /// Удалить строку из справочника грузов по ID
        /// </summary>
        /// <param name="Cargo_ID">ID груза</param>
        public void DeleteOneRowCargoGuide(string Cargo_ID)
        {
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCmd = sqlConn.CreateCommand())
                {
                    sqlCmd.CommandText = "DELETE FROM Cargo WHERE Cargo_ID = @Cargo_ID";
                    //sqlCmd.CommandText = "spDeleteOneRowCargoGuide";
                    //sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Cargo_ID", Cargo_ID);
                    sqlConn.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Изменить значения одной строки в справочнике грузов
        /// </summary>
        /// <param name="CargoCode"></param>
        /// <param name="Description"></param>
        /// <param name="CargoName"></param>
        /// <param name="Mnemocode"></param>
        /// <param name="IsUsed"></param>
        /// <param name="IsEmpty"></param>
        public void UpdateOneRowCargoGuide(
            string Cargo_ID,
            string Name,
            byte[] Image,
            string Description,
            string ShortCode,
            string Code,
            string CodeGNG,
            string Mnemocode,
            bool IsUsed,
            bool IsEmpty
            )
        {
            if (Name == null) Name = string.Empty;
            if (Description == null) Description = string.Empty;
            if (ShortCode == null) ShortCode = string.Empty;
            if (Code == null) Code = string.Empty;
            if (CodeGNG == null) CodeGNG = string.Empty;
            if (Mnemocode == null) Mnemocode = string.Empty;

            var connstring = ConfigurationManager.ConnectionStrings[key].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connstring))
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Cargo_ID", Cargo_ID),
                    new SqlParameter("@Name", Name),
                    new SqlParameter("@Description", Description),
                    new SqlParameter("@ShortCode", ShortCode),
                    new SqlParameter("@Code", Code),
                    new SqlParameter("@CodeGNG", CodeGNG),
                    new SqlParameter("@Mnemocode", Mnemocode),
                    new SqlParameter("@IsUsed", IsUsed),
                    new SqlParameter("@IsEmpty", IsEmpty)
                };

                using (SqlCommand sqlCmd = sqlConn.CreateCommand())
                {
                    sqlCmd.CommandText = "spUpdateCargoGuide";
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddRange(parameters);
                    sqlCmd.Parameters.Add("@Image", SqlDbType.VarBinary).Value = Image;

                    sqlConn.Open();
                    sqlCmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
            }
        }

        public void InsertOneRowCargoGuide(
            string Name,
            byte[] Image,
            string Description,
            string ShortCode,
            string Code,
            string CodeGNG,
            string Mnemocode,
            bool IsUsed,
            bool IsEmpty
            )
        {
            if (Name == null) Name = string.Empty;
            if (Description == null) Description = string.Empty;
            if (ShortCode == null) ShortCode = string.Empty;
            if (Code == null) Code = string.Empty;
            if (CodeGNG == null) CodeGNG = string.Empty;
            if (Mnemocode == null) Mnemocode = string.Empty;

            var connstring = ConfigurationManager.ConnectionStrings[key].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connstring))
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Name", Name),
                    new SqlParameter("@Description", Description),
                    new SqlParameter("@ShortCode", ShortCode),
                    new SqlParameter("@Code", Code),
                    new SqlParameter("@CodeGNG", CodeGNG),
                    new SqlParameter("@Mnemocode", Mnemocode),
                    new SqlParameter("@IsUsed", IsUsed),
                    new SqlParameter("@IsEmpty", IsEmpty)
                };

                using (SqlCommand sqlCmd = sqlConn.CreateCommand())
                {
                    sqlCmd.CommandText = "INSERT INTO Cargo(Name, Description, ShortCode, Code, CodeGNG, Mnemocode, IsUsed, IsEmpty) " +
                        "VALUES (@Name, @Description, @ShortCode, @Code, @CodeGNG, @Mnemocode, @IsUsed, @IsEmpty); ";
                   // sqlCmd.CommandText = "spInsertCargoGuide";
                   // sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddRange(parameters);
                    sqlCmd.Parameters.Add("@Image", SqlDbType.VarBinary).Value = Image;

                    sqlConn.Open();
                    sqlCmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
            }
        }

        public static string DBNullToString(object obj)
        {
            if (obj is DBNull)
                return string.Empty;
            else
                return obj.ToString();
        }

        public static byte[] DBNullToByteArr(object obj)
        {
            if (obj is DBNull)
                return null;
            else
                return (byte[])obj;
        }
    }
}
