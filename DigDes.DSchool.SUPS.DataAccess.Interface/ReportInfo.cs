using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DigDes.DSchool.SUPS.DataAccess.Interface
{
    public class ReportInfo : LoaderBaseDTO
    {
        public ReportInfo() { }

        /// <summary>
        /// Номер вагона
        /// </summary>
        [DisplayName("Car number")]
        public string CarNumber { get; set; }

        /// <summary>
        /// Время погрузки
        /// </summary>
        [DisplayName("Load time")]
        public string LoadTime { get; set; }

        /// <summary>
        /// Время разгрузки
        /// </summary>
        [DisplayName("Unload time")]
        public string UnloadTime { get; set; }

        /// <summary>
        /// Время отправления
        /// </summary>
        [DisplayName("Departure time")]
        public string DepartTime { get; set; }

        /// <summary>
        /// Время прибытия
        /// </summary>
        [DisplayName("Arrive time")]
        public string ArriveTime { get; set; }
    }
}
