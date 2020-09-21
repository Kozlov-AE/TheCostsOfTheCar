using Common.DTO.Classes;
using Common.DTO.Interfaces;
using Common.RepositoryInterfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.RepositoryInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository CarRepository { get; }
        IMileageRepository MileageRepository { get; }
    }
}
