using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Interfaces
{
    public interface ICarDTO : IBaseIdDTO
    {
        /// <summary>Наименование</summary>
        string Title { get; set; }
        /// <summary>Дата покупки</summary>
        DateTime BuyDate { get; set; }
        /// <summary>Стоимость покупки</summary>
        double BuyPrice { get; set; }
        /// <summary>Пробег на момент покупки</summary>
        //IMileageDTO BuyMileage { get; set; }
        int BuyMileage { get; set; }

        /// <summary>Пробег на данный момент</summary>
        //IMileageDTO CurrentMileage { get; set; }
        int CurrentMileage { get; set; }
    }
}
