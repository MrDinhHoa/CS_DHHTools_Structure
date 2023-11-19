using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIMSoftLib.MVVM;
namespace _01_SAPTools.Object
{
    public class ASCE7_05: PropertyChangedBase
    {
        //private string _exposure;
        //public string Exposure
        //{
        //    get => _exposure;
        //    set
        //    {
        //        _exposure = value;
        //        OnPropertyChanged(nameof(Exposure));
        //    }

        //}
        //private double _alpha;
        //public double Alpha
        //{
        //    get => _alpha;
        //    set
        //    {
        //        _alpha = value;
        //        OnPropertyChanged(nameof(Alpha));
        //    }

        //}
        public double[,] figure6_10 =
        {
            { 0.4,  -0.69, -0.37, -0.29, -0.45, -0.45, 0.61, -1.07, -0.53, -0.43},
            {0.53, -0.69, -0.48, -0.43, -0.45, -0.45,  0.8, -1.07, -0.69, -0.64},
            {0.56,  0.21, -0.43, -0.37, -0.45, -0.45, 0.69,  0.27, -0.53, -0.48},
            {0.56,  0.56, -0.37, -0.37, -0.45, -0.45, 0.69,  0.69, -0.48, -0.48},
        };
       
    }

}
