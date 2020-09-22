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
        public static async void CreateDB(string path)
        {
            var connection = new SQLiteAsyncConnection(path);
            await connection.CreateTableAsync<Car>().ConfigureAwait(false);
            await connection.CreateTableAsync<Mileage>().ConfigureAwait(false);
            await connection.CloseAsync();
        }
    }
}
