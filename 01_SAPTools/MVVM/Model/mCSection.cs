using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIMSoftLib.MVVM;

namespace _01_SAPTools.MVVM.Model
{
    class CSection : PropertyChangedBase
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
        private double _outsideDepth_t3;
        public double OutsideDepth_t3
        {
            get => _outsideDepth_t3;
            set
            {
                _outsideDepth_t3 = value;
                OnPropertyChanged(nameof(OutsideDepth_t3));
            }
        }
        private double _outsideFlangeWidth_t3;
        public double OutsideFlangeWidth_t3
        {
            get => _outsideFlangeWidth_t3;
            set
            {
                _outsideFlangeWidth_t3 = value;
                OnPropertyChanged(nameof(OutsideFlangeWidth_t3));
            }
        }
        private double _flangeThickness_tf;
        public double FlangeThickness_tf
        {
            get => _flangeThickness_tf;
            set
            {
                _flangeThickness_tf = value;
                OnPropertyChanged(nameof(FlangeThickness_tf));
            }
        }
        private double _webThickness_tw;
        public double WebThickness_tw
        {
            get => _webThickness_tw;
            set
            {
                _webThickness_tw = value;
                OnPropertyChanged(nameof(WebThickness_tw));
            }
        }
    }
}
