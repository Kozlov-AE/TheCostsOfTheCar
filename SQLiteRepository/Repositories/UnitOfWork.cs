using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Common.RepositoryInterfaces;
using Common.RepositoryInterfaces.Repositories;
using SQLite;
using SQLiteRepository.Entities;

namespace SQLiteRepository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private SQLiteAsyncConnection _Context;
        private SQLiteAsyncConnection Conext
        {
            get
            {
                if (_Context == null)
                {
                    _Context = new SQLiteAsyncConnection(_DbPath);
                }
                return _Context;
            }
        }
        private string _DbPath;
        private ICarRepository _CarRepository;
        private IMileageRepository _MileageRepository;

        public UnitOfWork(string dbpath)
        {
            _DbPath = dbpath;
        }

        public ICarRepository CarRepository 
            => _CarRepository ?? (_CarRepository = new CarRepository(Conext));
        public IMileageRepository MileageRepository 
            => _MileageRepository ?? (_MileageRepository = new MileageRepository(Conext));

        public void Dispose()
        {
            _Context.CloseAsync();
        }
    }
}
