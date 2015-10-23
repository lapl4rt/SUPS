using DigDes.DSchool.SUPS.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigDes.DSchool.SUPS.DataAccess.FileLoaders
{
    public class LoadCarInfo : ILoader<CarInfo>
    {
        public bool Check(string filePath)
        {
            if (System.IO.Path.GetExtension(filePath) != ".out")
                return false;
            return true;
        }

        public IEnumerable<CarInfo> Load(string filePath)
        {
            using (var streamreader = new System.IO.StreamReader(filePath, Encoding.UTF8))
            {
                String line;
                while ((line = streamreader.ReadLine()) != null)
                {
                    var row = new CarInfo();

                    row.carNumber = line.Substring(0, 8);
                    row.weight = line.Substring(8, 3);
                    row.arriveStation = line.Substring(11, 5);
                    row.cargoCode = line.Substring(16, 5);
                    row.receiverCode = line.Substring(21, 4);
                    row.carType = line.Substring(25, 2);
                    row.departStation = line.Substring(27, 5);
                    row.operationCode = line.Substring(32, 2);

                    row.operationDate = line.Substring(34, 4);
                    row.operationYear = line.Substring(38, 2);
                    row.operationTime = line.Substring(40, 4);

                    int date = Int32.Parse(line.Substring(34, 2));
                    int month = Int32.Parse(line.Substring(36, 2));
                    int year = 2000 + Int32.Parse(line.Substring(38,2));
                    int hours = Int32.Parse(line.Substring(40,2));
                    int minutes = Int32.Parse(line.Substring(42, 2));

                    row.operationStation = line.Substring(44, 5);
                    row.deliveryRoad = line.Substring(49, 2);
                    row.receiptRoad = line.Substring(51, 2);
                    row.trainIndex = line.Substring(53, 13);
                    row.trainNumber = line.Substring(66, 4);

                    row.carDateTime = new DateTime(year, month, date, hours, minutes, 0);

                    yield return row;
                }
            }
        }
    }
}