using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigDes.DSchool.SUPS.DataAccess.PresentData
{
    public class Dislocation
    {
        public Dislocation() { }

        public string cargoName { get; set; }
        public string carNumber { get; set; }
        public string weight { get; set; }
        public string receiverCode { get; set; }
        public string carType { get; set; }
        public string operationName { get; set; }
        public string arriveStation { get; set; }
        public string operationStation { get; set; }
        public string departStation { get; set; }
        public string operationDate { get; set; }
        public string operationYear { get; set; }
        public string operationTime { get; set; }
        public string deliveryRoad{ get; set; }
        public string receiptRoad { get; set; }
        public string trainIndex { get; set; }
        public string trainNumber { get; set; }
    }
}
