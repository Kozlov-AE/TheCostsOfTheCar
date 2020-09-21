using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;
using Common.Static;
using SQLiteNetExtensions.Attributes;

namespace SQLiteRepository.Entities
{
    [Table ("Cars")]
    public class Car
    {
        public Car(string title)
        {
            Title = title;
            BuyDate = DateTime.Now;
            BuyPrice = 0;
            Mileages = new List<Mileage>();
        }

        public Car()
        {
            Mileages = new List<Mileage>();
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime BuyDate { get; set; }
        public double BuyPrice { get; set; }

        [Ignore]
        public Mileage BuyMileage
        {
            get => Mileages.FirstOrDefault(m => m.Type == MileageTypeEnum.First);
        }
        [Ignore]
        public Mileage CurrentMileage
        {
            get => Mileages.FirstOrDefault(m => m.Type == MileageTypeEnum.Current);
        }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Mileage> Mileages { get; set; }

        public void AddMileage(Mileage mileage)
        {
            mileage.CarId = this.Id;
            Mileages.Add(mileage);
        }
    }
}
