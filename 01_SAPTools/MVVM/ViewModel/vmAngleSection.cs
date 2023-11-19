using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_SAPTools.MVVM.Model;
using _01_SAPTools.MVVM.View;
using System.Windows.Input;
using BIMSoftLib.MVVM;
using Microsoft.Xaml.Behaviors.Core;
using static _01_SAPTools.MVVM.ViewModel.vmMain;

namespace _01_SAPTools.MVVM.ViewModel
{
    class vmAngleSection: PropertyChangedBase
    {
        public static vmAngleSection dcAngleSection = new vmAngleSection();

        private AngleSection _angleSection = new AngleSection();

        public AngleSection AngleSection
        {
            get => _angleSection;
            set
            {
                _angleSection = value;
                OnPropertyChanged(nameof(AngleSection));
            }
        }

        private ActionCommand _addAngleSectionCmd;

        public ICommand AddAngleSectionCmd
        {
            get
            {
                if (_addAngleSectionCmd == null)
                {
                    _addAngleSectionCmd = new ActionCommand(PerformAddAngleSectionCmd);
                }

                return _addAngleSectionCmd;
            }
        }

        private void PerformAddAngleSectionCmd()
        {
            try
            {
                AngleSection newSection = new AngleSection
                {
                    NameSection = dcAngleSection.AngleSection.NameSection,
                    OutsideHorizontalLeg_t3 = dcAngleSection.AngleSection.OutsideHorizontalLeg_t3,
                    OutsideVerticalLeg_t3 = dcAngleSection.AngleSection.OutsideVerticalLeg_t3,
                    HorizontalLegThickness_tf = dcAngleSection.AngleSection.HorizontalLegThickness_tf,
                    VerticalLegThickness_tw = dcAngleSection.AngleSection.VerticalLegThickness_tw,
                };
                DcMain.AngleSource.Add(newSection);
                DcMain.ListSection.Add(newSection);
            }
            catch
            {
            }
        }
    }
}
