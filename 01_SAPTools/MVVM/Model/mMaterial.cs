using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIMSoftLib.MVVM;

namespace _01_SAPTools.MVVM.Model
{
    public class SapMaterial: PropertyChangedBase
    {
        private string _nSteelMat;
        public string NSteelMat
        {
            get => _nSteelMat;
            set
            {
                _nSteelMat = value;
                OnPropertyChanged(nameof(NSteelMat));
            }
        }
        private double _fy;
        public double Fy
        {
            get => _fy;
            set
            {
                _fy = value;
                OnPropertyChanged(nameof(Fy));
            }
        }
        private double _fu;
        public double Fu
        {
            get => _fu;
            set
            {
                _fu = value;
                OnPropertyChanged(nameof(Fu));
            }
        }
        private double _efy;
        public double EFy
        {
            get => _efy;
            set
            {
                _efy = value;
                OnPropertyChanged(nameof(EFy));
            }
        }
        private double _efu;
        public double EFu
        {
            get => _efu;
            set
            {
                _efu = value;
                OnPropertyChanged(nameof(EFu));
            }
        }
    }
}
