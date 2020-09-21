using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Interfaces
{
    public interface IBaseIdDTO
    {
        /// <summary>Уникальный Id, по умолчанию равен 0</summary>
        int Id { get; set; }
    }
}
