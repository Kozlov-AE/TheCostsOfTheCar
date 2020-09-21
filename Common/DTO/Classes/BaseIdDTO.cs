using Common.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Classes
{
    public class BaseIdDTO : IBaseIdDTO
    {
        public BaseIdDTO(int id = 0) => this.Id = id;

        public int Id { get; set; }
    }

}
