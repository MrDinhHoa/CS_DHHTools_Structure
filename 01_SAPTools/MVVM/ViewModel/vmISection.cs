using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIMSoftLib.MVVM;
using System.Windows.Input;
using _01_SAPTools.MVVM.Model;
using static _01_SAPTools.MVVM.ViewModel.vmMain;

namespace _01_SAPTools.MVVM.ViewModel
{
    class vmISection : PropertyChangedBase
    {
        public static vmISection dcISection = new vmISection();

        private ISection _ISection = new ISection();

        public ISection ISection
        {
            get => _ISection;
            set 
            {
                _ISection = value;
                OnPropertyChanged(nameof(ISection));
            }
        }

        private ActionCommand _addISectionCmd;

        public ICommand AddISectionCmd
        {
            get
            {
                if (_addISectionCmd == null)
                {
                    _addISectionCmd = new ActionCommand(PerformAddISectionCmd);
                }

                return _addISectionCmd;
            }
        }

        private void PerformAddISectionCmd()
        {
            try
            {
                ISection newSection = new ISection
                {
                    NameSection = dcISection.ISection.NameSection,
                    OutsideHeight_t3 = dcISection.ISection.OutsideHeight_t3,
                    TopFlangeWidth_t2 = dcISection.ISection.TopFlangeWidth_t2,
                    BotFlangeWidth_t2b = dcISection.ISection.BotFlangeWidth_t2b,
                    TopFlangeThickness_tf = dcISection.ISection.TopFlangeThickness_tf,
                    BotFlangeThickness_tfb = dcISection.ISection.BotFlangeThickness_tfb,
                    WebThickness_tw = dcISection.ISection.WebThickness_tw,
                };
                DcMain.ISource.Add(newSection);
                DcMain.ListSection.Add(newSection);
            }
            catch 
            { 
            }
        }
    }
}
