using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Static
{
    public static class Exceptions
    {
        public static class CarExceptions
        {
            static public string CarIdMissing = "Автомобилю не присвоен Id!!!";
            static public string CarNameIsExists= "Автомобиль с таким именем уже существует в БД!";
        }
        public static class MileageExceptions
        {
            static public string MileageIdMissing = "Данные показания не найдены в БД!!!";
        }

    }
}
