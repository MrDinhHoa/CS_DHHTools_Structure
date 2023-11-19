using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using _01_SAPTools.MVVM.Model;
using static _01_SAPTools.MVVM.ViewModel.vmMain;
using BIMSoftLib.MVVM;
using Microsoft.Xaml.Behaviors.Core;

namespace _01_SAPTools.MVVM.ViewModel
{
    class vmRodSection: PropertyChangedBase
    {
        public static vmRodSection dcRodSection = new vmRodSection();

        private RodSection _rodSection = new RodSection();

        public RodSection RodSection
        {
            get => _rodSection;
            set
            {
                _rodSection = value;
                OnPropertyChanged(nameof(RodSection));
            }
        }

        private ActionCommand _addRodSectionCmd;

        public ICommand AddRodSectionCmd
        {
            get
            {
                if (_addRodSectionCmd == null)
                {
                    _addRodSectionCmd = new ActionCommand(PerformAddRodSectionCmd);
                }

                return _addRodSectionCmd;
            }
        }

        private void PerformAddRodSectionCmd()
        {
            try
            {
                RodSection newSection = new RodSection
                {
                    NameSection = dcRodSection.RodSection.NameSection,
                    Diameter = dcRodSection.RodSection.Diameter,
                };
                DcMain.RodSource.Add(newSection);
                DcMain.ListSection.Add(newSection);
            }
            catch
            {
            }
        }
    }
}

