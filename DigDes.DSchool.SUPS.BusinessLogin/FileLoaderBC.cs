using DigDes.DSchool.SUPS.DataAccess.Database;
using DigDes.DSchool.SUPS.DataAccess.FileLoaders;
using DigDes.DSchool.SUPS.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigDes.DSchool.SUPS.BusinessLogic
{
    public class FileLoaderBC
    {
        public void LoadMyFile1(string filePath)
        {
            var loader = new LoadCarInfo();

            try
            {
                if (!loader.Check(filePath))
                {
                    throw new Exception();
                }
                else
                {
                    Console.WriteLine("Читаем данные ...");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Неверный тип файла: нужен .out");
            }

           FileLoaderDAC.InsertListRows(loader.Load(filePath));
        }
    }
}
