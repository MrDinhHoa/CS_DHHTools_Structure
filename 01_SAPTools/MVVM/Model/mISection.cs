using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIMSoftLib.MVVM;

namespace _01_SAPTools.MVVM.Model
{
    class ISection: PropertyChangedBase 
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
        private double _outsideHeight_t3;
        public double OutsideHeight_t3
        {
            get => _outsideHeight_t3;
            set
            {
                _outsideHeight_t3 = value;
                OnPropertyChanged("OutsideHeight_t3");
            }
        }
        private double _topFlangeWidth_t2;
        public double TopFlangeWidth_t2
        {
            get => _topFlangeWidth_t2;
            set
            {
                _topFlangeWidth_t2 = value;
                OnPropertyChanged("TopFlangeWidth_t2");
            }
        }
        private double _botFlangeWidth_t2b;
        public double BotFlangeWidth_t2b
        {
            get => _botFlangeWidth_t2b;
            set
            {
                _botFlangeWidth_t2b = value;
                OnPropertyChanged("BotFlangeWidth_t2b");
            }
        }
        private double _topFlangeThickness_tf;
        public double TopFlangeThickness_tf
        {
            get => _topFlangeThickness_tf;
            set
            {
                _topFlangeThickness_tf = value;
                OnPropertyChanged("TopFlangeThickness_tf");
            }
        }
        private double _botflangeThickness_tfb;
        public double BotFlangeThickness_tfb
        {
            get => _botflangeThickness_tfb;
            set
            {
                _botflangeThickness_tfb = value;
                OnPropertyChanged(nameof(BotFlangeThickness_tfb));
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
