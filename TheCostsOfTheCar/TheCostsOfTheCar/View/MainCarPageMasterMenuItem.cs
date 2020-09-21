using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCostsOfTheCar.View
{

    public class MainCarPageMasterMenuItem
    {
        public MainCarPageMasterMenuItem()
        {
            TargetType = typeof(MainCarPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}