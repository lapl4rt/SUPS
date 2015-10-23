using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigDes.DSchool.SUPS.DataAccess.Interface
{
    /// <summary>
    /// Интерфейс загрузка файлов определённого типа
    /// </summary>
    public interface ILoader<RowT> where RowT : LoaderBaseDTO
    {
        /// <summary>
        /// Проверка типа файла 
        /// (по расширению, первым строка содержимого (длине строки например), ...)
        /// </summary>
        /// <param name="filePath">Полный путь к файлу</param>
        /// <returns>Может ли данный загрузчик загрузить указанный в <paramref name="filePath"/> файл</returns>
        bool Check(string filePath);

        /// <summary>
        /// Загрузка файла по указанному пути
        /// </summary>
        /// <param name="filePath">Полный путь к файлу</param>
        IEnumerable<RowT> Load(string filePath);
    }

}
