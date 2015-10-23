using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigDes.DSchool.SUPS.DataAccess.Interface
{
    /// <summary>
    /// Пример класса переноса данных (модель). Отвечает за одну строку, считанную из файла
    /// </summary>
    public class CarInfo : LoaderBaseDTO
    {
        /// <summary>
        /// номер вагона
        /// </summary>
        public string carNumber { get; set; }

        /// <summary>
        /// вес груза в тоннах
        /// </summary>
        public string weight { get; set; }

        /// <summary>
        /// станция назначения
        /// </summary>
        public string arriveStation { get; set; }

        /// <summary>
        /// код груза
        /// </summary>
        public string cargoCode { get; set; }

        /// <summary>
        /// код грузополучателя
        /// </summary>
        public string receiverCode { get; set; }

        /// <summary>
        /// тип парка вагона
        /// </summary>
        public string carType { get; set; }

        /// <summary>
        /// станция начала рейса
        /// </summary>
        public string departStation { get; set; }

        /// <summary>
        /// код операции
        /// </summary>
        public string operationCode { get; set; }

        /// <summary>
        /// дата операции
        /// </summary>
        public string operationDate { get; set; }

        /// <summary>
        /// год операции
        /// </summary>
        public string operationYear { get; set; }

        /// <summary>
        /// время операции
        /// </summary>
        public string operationTime { get; set; }

        /// <summary>
        /// станция сверш. операции
        /// </summary>
        public string operationStation { get; set; }

        /// <summary>
        /// дорога сдачи
        /// </summary>
        public string deliveryRoad { get; set; }

        /// <summary>
        /// дорога приема
        /// </summary>
        public string receiptRoad { get; set; }

        /// <summary>
        /// индекс поезда
        /// </summary>
        public string trainIndex { get; set; }

        /// <summary>
        /// номер поезда
        /// </summary>
        public string trainNumber { get; set; }

        public DateTime carDateTime { get; set; }
    }
}