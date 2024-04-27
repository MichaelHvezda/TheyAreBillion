using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TheyAreBillions.Classes
{
    public class WetherStation
    {
        public WetherStation()
        {
        }

        public WetherStation(double temp)
        {
            this.Min = temp;
            this.Max = temp;
            this.Sum = temp;
            Count++;
        }

        public void AddData(double val)
        {
            if (val < this.Min)
            {
                this.Min = val;
            }
            if (val > this.Max)
            {
                this.Max = val;
            }
            Sum += val;
            Count++;
        }

        public WetherStation AddDataAndReturn(double val)
        {
            if (val < this.Min)
            {
                this.Min = val;
            }
            if (val > this.Max)
            {
                this.Max = val;
            }
            Sum += val;
            Count++;
            return this;
        }

        //public string Name { get; set; }
        public double Min { get; set; } = double.MaxValue;
        public double Max { get; set; }
        public double Sum { get; set; }
        public int Count { get; set; }

    }
}
