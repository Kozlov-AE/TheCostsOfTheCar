using SQLite;
using SQLiteRepository.Entities;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SQLiteRepository
{
    public class BaseCreator
    {
        string path;
        SQLiteAsyncConnection connection;

        public BaseCreator(string path)
        {
            this.path = path;
        }

        public static void CreateDB(string path)
        {
            var connection = new SQLiteAsyncConnection(path);
            connection.CreateTableAsync<Car>();
            connection.CreateTableAsync<Mileage>();
            connection.CloseAsync();
        }
    }
}
