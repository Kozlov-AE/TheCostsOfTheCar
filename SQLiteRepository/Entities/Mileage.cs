using Common.Enums;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;


namespace SQLiteRepository.Entities
{
    [Table ("Mileages")]
    public class Mileage
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public int Count { get; set; }
        public MileageTypeEnum Type { get;  set; }
        
        [ForeignKey(typeof(Car))]
        public int CarId { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Car Car { get; set; }

        public Mileage() { }
        public Mileage(int count)
        {
            Count = count;
            Date = DateTime.Now;
            Type = MileageTypeEnum.Regular;
        }
        public Mileage(DateTime date, int count)
        {
            Date = date;
            Count = count;
            Type = MileageTypeEnum.Regular;
        }
    }
}