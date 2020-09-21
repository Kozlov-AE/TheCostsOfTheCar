using Common.DTO.Interfaces;
using Common.Enums;
using System;

namespace Common.DTO.Classes
{
    public class MileageDTO : BaseIdDTO, IMileageDTO
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public int CarId { get; set; }
        public MileageTypeEnum Type { get; set; }

        public MileageDTO(int id = 0) : base(id)
        {}
    }
}
