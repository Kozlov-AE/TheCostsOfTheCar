using Common.Enums;
using System;

namespace Common.DTO.Interfaces
{
    public interface IMileageDTO : IBaseIdDTO
    {
        DateTime Date { get; set; }
        int Count { get; set; }
        int CarId { get; set; }
        MileageTypeEnum Type { get; set; }
    }
}