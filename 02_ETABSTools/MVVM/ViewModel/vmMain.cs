using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIMSoftLib.MVVM;
using System.Windows.Input;
using _02_ETABSTools.MVVM.View;
using _02_ETABSTools.MVVM.Model;

namespace _02_ETABSTools.MVVM.ViewModel
{
    public class vmMain: PropertyChangedBase
    {
        private static vmMain _dcMain = new vmMain();

        public static vmMain DcMain
        {
            get { return _dcMain; }
        }

        ETABsClass ETABsClass { get; set; } = new ETABsClass();


        private ActionCommand checkDisplacement;

        public ICommand CheckDisplacement
        {
            get
            {
                if (checkDisplacement == null)
                {
                    checkDisplacement = new ActionCommand(PerformCheckDisplacement);
                }

                return checkDisplacement;
            }
        }

        private void PerformCheckDisplacement()
        {
            vCheckOverStability vCheckOverStability = new vCheckOverStability();    
            vCheckOverStability.Show();
        }

        private ActionCommand connectEtabs;

        public ICommand ConnectEtabs
        {
            get
            {
                if (connectEtabs == null)
                {
                    connectEtabs = new ActionCommand(PerformConnectEtabs);
                }

                return connectEtabs;
            }
        }

        private void PerformConnectEtabs()
        {
            ETABsClass.SelectETABS();
        }
    }
}
