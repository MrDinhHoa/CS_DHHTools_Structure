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
    class vmCSection: PropertyChangedBase
    {
        public static vmCSection dcCSection = new vmCSection();

        private CSection _cSection = new CSection();

        public CSection CSection
        {
            get => _cSection;
            set
            {
                _cSection = value;
                OnPropertyChanged(nameof(CSection));
            }
        }

        private ActionCommand _addCSectionCmd;

        public ICommand AddCSectionCmd
        {
            get
            {
                if (_addCSectionCmd == null)
                {
                    _addCSectionCmd = new ActionCommand(PerformAddCSectionCmd);
                }

                return _addCSectionCmd;
            }
        }

        private void PerformAddCSectionCmd()
        {
            try
            {
                CSection newCSection = new CSection
                {
                    NameSection = dcCSection.CSection.NameSection,
                    OutsideDepth_t3 = dcCSection.CSection.OutsideDepth_t3,
                    OutsideFlangeWidth_t3 = dcCSection.CSection.OutsideFlangeWidth_t3,
                    FlangeThickness_tf = dcCSection.CSection.FlangeThickness_tf,
                    WebThickness_tw = dcCSection.CSection.WebThickness_tw,
                };
                DcMain.CSource.Add(newCSection);
                DcMain.ListSection.Add(newCSection);
            }
            catch
            {
            }
        }
    }
}
