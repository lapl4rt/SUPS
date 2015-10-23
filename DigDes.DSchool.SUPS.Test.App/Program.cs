using DigDes.DSchool.SUPS.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigDes.DSchool.SUPS.Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLoaderBC businessComponent = new FileLoaderBC();

            //businessComponent.LoadMyFile1(@"D:\DDproject\railwaytracking2013\Исхдоные данные\Загрузчики. Дислокация\Примеры данных_70\30.06-дисл.out");

            for(int i = 1; i <= 9; ++i)
                businessComponent.LoadMyFile1(@"D:\DDproject\railwaytracking2013\Исхдоные данные\Загрузчики. Дислокация\Примеры данных_70\0" + i.ToString() + ".02.out");
            for (int i = 10; i <= 28; ++i)
                businessComponent.LoadMyFile1(@"D:\DDproject\railwaytracking2013\Исхдоные данные\Загрузчики. Дислокация\Примеры данных_70\" + i.ToString() + ".02.out");

        }
    }
}
