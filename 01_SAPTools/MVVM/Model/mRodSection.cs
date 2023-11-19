using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIMSoftLib.MVVM;

namespace _01_SAPTools.MVVM.Model
{
    class RodSection: PropertyChangedBase
    {
        private string _nameSection;
        public string NameSection
        {
            get => _nameSection;
            set
            {
                _nameSection = value;
                OnPropertyChanged(nameof(NameSection));
            }
        }
        private double _diameter;
        public double Diameter
        {
            get => _diameter;
            set
            {
                _diameter = value;
                OnPropertyChanged(nameof(Diameter));
            }
        }
        
    }
}

