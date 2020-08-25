using SQLite;
using System;
using System.Collections.Generic;

namespace SQLiteRepository.Entities
{
    public class Car
    {
        public Car(string title)
        {
            Title = title;
            BuyDate = DateTime.Now;
            BuyPrice = 0;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime BuyDate { get; set; }
        public double BuyPrice { get; set; }

        public virtual ICollection<Mileage> Mileages { get; set; }

        //public virtual ICollection<Cost> CarCosts { get; set; }
        //public virtual ICollection<Mileage> Mileages { get; set; }
    }
}
