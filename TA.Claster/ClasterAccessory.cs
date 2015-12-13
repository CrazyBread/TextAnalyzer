using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Claster
{
    public class ClasterAccessory
    {
        public Claster Claster { set; get; }
        public ClasterItem Item { set; get; }

        private double accessory;
        private double accessoryOld;
        public double Accessory
        {
            set
            {
                accessoryOld = accessory;
                accessory = value;
            }
            get { return accessory; }

        }
        public double AccessoryOld { get { return accessoryOld; } }
        public double FitnessValue
        {
            get
            {
                double res = 0.0F;
                for (int i = 0; i < Claster.Dimensions; i++)
                {
                    var tempVal = Claster.GetCentreCoordinate(i) - Item.GetValue(i);
                    res += tempVal * tempVal;
                }
                return Math.Sqrt(res);
            }
        }

        public override string ToString()
        {
            return base.ToString() + ": " + Accessory;
        }
    }
}
