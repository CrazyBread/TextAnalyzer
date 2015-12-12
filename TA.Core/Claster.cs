using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Core
{
    /// <summary>
    /// Класс, описывающий кластер
    /// </summary>
    public class Claster
    {
        public string Name { set; get; }
        public int Dimensions { protected set; get; }

        private double[] _centre;

        public Claster(string name, int dimensions)
        {
            Name = name;
            Dimensions = dimensions;
            _centre = new double[Dimensions];
        }

        /// <summary>
        /// Получает значение центра кластера по измерению (начиная с 0).
        /// </summary>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public double GetCentreCoordinate(int dimension)
        {
            return _centre[dimension];
        }

        /// <summary>
        /// Задаёт центр кластера в конкретном измерении (отсчёт с 0).
        /// </summary>
        /// <param name="dimension"></param>
        /// <param name="value"></param>
        public void SetCentre(int dimension, double value)
        {
            _centre[dimension] = value;
        }

        public override string ToString()
        {
            return base.ToString() + ": " + Name;
        }
    }
}
