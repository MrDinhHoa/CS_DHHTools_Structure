using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIMSoftLib.MVVM;

namespace _01_SAPTools.MVVM.Model
{
    class AngleSection: PropertyChangedBase
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
        private double _outsideVerticalLeg_t3;
        public double OutsideVerticalLeg_t3
        {
            get => _outsideVerticalLeg_t3;
            set
            {
                _outsideVerticalLeg_t3 = value;
                OnPropertyChanged(nameof(OutsideVerticalLeg_t3));
            }
        }
        private double _outsideHorizontalLeg_t3;
        public double OutsideHorizontalLeg_t3
        {
            get => _outsideHorizontalLeg_t3;
            set
            {
                _outsideHorizontalLeg_t3 = value;
                OnPropertyChanged(nameof(OutsideHorizontalLeg_t3));
            }
        }
        private double _verticalLegThickness_tw;
        public double VerticalLegThickness_tw
        {
            get => _verticalLegThickness_tw;
            set
            {
                _verticalLegThickness_tw = value;
                OnPropertyChanged(nameof(VerticalLegThickness_tw));
            }
        }
        private double _horizontalLegThickness_tf;
        public double HorizontalLegThickness_tf
        {
            get => _horizontalLegThickness_tf;
            set
            {
                _horizontalLegThickness_tf = value;
                OnPropertyChanged(nameof(HorizontalLegThickness_tf));
            }
        }
    }
}
