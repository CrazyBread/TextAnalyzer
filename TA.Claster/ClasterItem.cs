using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Claster
{
    public class ClasterItem
    {
        public object Item { set; get; }
        public int Dimensions { protected set; get; }

        private double[] _values;

        public ClasterItem(int dimensions)
        {
            Dimensions = dimensions;
            _values = new double[Dimensions];
        }
        
        public double GetValue(int dimension)
        {
            return _values[dimension];
        }
        
        public void SetValue(int dimension, double value)
        {
            _values[dimension] = value;
        }
    }
}
