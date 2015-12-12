using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Core
{
    public class ClasterizeBigram
    {
        const int DIMENSIONS = 3;

        private Claster _termClaster = new Claster("Термин", DIMENSIONS);
        private Claster _notTermClaster = new Claster("Не термин", DIMENSIONS);
        private string _text;
        private List<ClasterItem> _items;
        private List<ClasterAccessory> _accessories;

        private float _m;

        public ClasterizeBigram(string text, List<ClasterItem> items)
        {
            _text = text;
            _items = items;
            _accessories = new List<ClasterAccessory>();
            _accessories.AddRange(_items.Select(i => new ClasterAccessory() { Claster = _termClaster, Item = i, Accessory = 0.0F }));
            _accessories.AddRange(_items.Select(i => new ClasterAccessory() { Claster = _notTermClaster, Item = i, Accessory = 0.0F }));
        }

        /// <summary>
        /// Запускает механизм кластеризации
        /// </summary>
        /// <param name="m">Степень нечёткости кластеризации (от 1 до 2)</param>
        public void Run(float m = 1.5F, int maxIterations = 1000, float eps = 0.001F)
        {
            _m = m;
            _Init();
            for (int stepCounter = 0; stepCounter < maxIterations; stepCounter++)
            {
                _CalculateCentres();
                _CalculateAccessories();

                var maxEps = _GetMaxEps();
                if (maxEps < eps)
                    break;
            }
        }

        public void PrintResult(string fileName)
        {
            var top10Terms = _accessories.Where(i => i.Claster == _termClaster).OrderByDescending(i => i.Accessory).Take(50);
            var top10NotTerms = _accessories.Where(i => i.Claster == _notTermClaster).OrderByDescending(i => i.Accessory).Take(50);

            Trace.Listeners.Add(new TextWriterTraceListener(fileName));
            Trace.WriteLine("ТОП 50 терминов:");
            foreach(var item in top10Terms)
            {
                Trace.WriteLine(item.Item.Item);
            }
            Trace.WriteLine("");
            Trace.WriteLine("ТОП 50 не терминов:");
            foreach (var item in top10NotTerms)
            {
                Trace.WriteLine(item.Item.Item);
            }
            Trace.Flush();
        }

        private void _Init()
        {
            for (int i = 0; i < _termClaster.Dimensions; i++)
            {
                var minValue = _items.Min(j => j.GetValue(i));
                var maxValue = _items.Max(j => j.GetValue(i));
                _notTermClaster.SetCentre(i, minValue);
                _termClaster.SetCentre(i, maxValue);
            }
            _CalculateAccessories();
        }

        private void _CalculateCentres()
        {
            _CalculateCentre(_termClaster);
            _CalculateCentre(_notTermClaster);
        }

        private void _CalculateCentre(Claster claster)
        {
            var tmpAcessories = _accessories.Where(i => i.Claster == claster);
            var denomSum = tmpAcessories.Sum(i => Math.Pow(i.Accessory, _m));
            for (int i = 0; i < claster.Dimensions; i++)
            {
                var numSum = tmpAcessories.Sum(j => Math.Pow(j.Accessory, _m) * j.Item.GetValue(i));
                claster.SetCentre(i, numSum / denomSum);
            }
        }

        private void _CalculateAccessories()
        {
            foreach(var a in _accessories)
            {
                double denom = 0.0F;
                denom += _CalculateAccessory(_termClaster, a);
                denom += _CalculateAccessory(_notTermClaster, a);
                a.Accessory = 1 / denom;
            }
        }

        private double _CalculateAccessory(Claster claster, ClasterAccessory accessory)
        {
            double result = 0.0F;
            var neededAccessory = _accessories.First(i => i.Item == accessory.Item && i.Claster == claster);
            result = accessory.FitnessValue / neededAccessory.FitnessValue;
            result = Math.Pow(result, _m * 2);
            return result;
        }

        private double _GetMaxEps()
        {
            double maxEps = 0.0F;
            foreach (var accessory in _accessories)
            {
                if (Math.Abs(accessory.Accessory - accessory.AccessoryOld) > maxEps)
                    maxEps = Math.Abs(accessory.Accessory - accessory.AccessoryOld);
            }
            return maxEps;
        }
    }
}
