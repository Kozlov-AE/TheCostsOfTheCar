using SQLite;
using SQLiteRepository.Entities;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SQLiteRepository
{
    public static class BaseCreator
    {
        /// <summary>начальная инициализация БД </summary>
        /// <param name="path">Путь к БД</param>
        public static void CreateDB(string path)
        {
            var connection = new SQLiteConnection(path);
            connection.CreateTable<Car>();
            connection.CreateTable<Mileage>();
            connection.Close();
        }
    }
}
