using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using DigDes.DSchool.SUPS.DataAccess.Interface;
using DigDes.DSchool.SUPS.BusinessLogic;
using DigDes.DSchool.SUPS.DataAccess;

namespace DigDes.DSchool.SUPS.DataAccess.Database
{
    /// <summary>
    /// Вспомогательный класс, реализующий методы для представления БД
    /// </summary>
    public class PresentData : BaseDAC
    {
        public PresentData() { }

        /// <summary>
        /// Метод, осуществляющий выборку данных
        /// </summary>
        /// <returns></returns>
        public IList<HelpPresentData> GetAllInfo()
        {
            HelpPresentData row;

            using (SqlConnection sqlCon = Configurations.Connection())
            {
                //using (SqlCommand sqlCmd = GetCommand("spSelectAllCarInfo"))
                using (SqlCommand sqlCmd = new SqlCommand("SELECT * FROM ResultTable", sqlCon))
                {
                    sqlCon.Open();

                    IList<HelpPresentData> list = new List<HelpPresentData>();

                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            row = new HelpPresentData();
                            row.carNumber = ConvertFromDBVal<string>(dr["CarNumber"]);
                            row.weight = ConvertFromDBVal<string>(dr["Weight"]);
                            row.cargoName = ConvertFromDBVal<string>(dr["CargoName"]);
                            row.cargoDescr = ConvertFromDBVal<string>(dr["CargoDescr"]);
                            row.cargoGNGName = ConvertFromDBVal<string>(dr["CargoGNGName"]);
                            row.cargoETSNGName = ConvertFromDBVal<string>(dr["CargoETSNGName"]);
                            row.operationName = ConvertFromDBVal<string>(dr["OperationName"]);
                            row.roadName = ConvertFromDBVal<string>(dr["RoadName"]);
                            row.regionName = ConvertFromDBVal<string>(dr["RegionName"]);
                            row.CTM_CountryName = ConvertFromDBVal<string>(dr["CTM_CountryName"]);
                            row.trainIndex = ConvertFromDBVal<string>(dr["TrainIndex"]);
                            row.trainNumber = ConvertFromDBVal<string>(dr["TrainNumber"]);
                            list.Add(row);
                        }
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
