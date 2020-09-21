using Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.ViewModels
{
    public class MileageVM : BaseINotify, IMileageVM
    {
        public int Id { get; set; }

        private DateTime _Date;
        public DateTime Date
        {
            get => _Date;
            set => Set(ref _Date, value);
        }

        private int _Count;
        public int Count
        {
            get => _Count;
            set => Set(ref _Count, value);
        }

        private int _CarId;
        public int CarId
        {
            get => _CarId;
            set => Set(ref _CarId, value);
        }


        private MileageTypeEnum _Type;
        public MileageTypeEnum Type
        {
            get => _Type;
            set => Set(ref _Type, value);
        }


        public MileageVM(int id = 0)
        {
            Id = id;
        }
        public MileageVM(){}
        
    }
}
