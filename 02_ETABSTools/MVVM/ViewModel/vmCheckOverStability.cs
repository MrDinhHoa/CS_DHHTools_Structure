using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using _02_ETABSTools.MVVM.Model;
using BIMSoftLib.MVVM;
using System.Windows.Input;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Media;
using System.Globalization;
using System.Windows.Data;

namespace _02_ETABSTools.MVVM.ViewModel
{
    public class vmCheckOverStability: PropertyChangedBase
    {
        private static vmCheckOverStability _dcCheckDisplacement = new vmCheckOverStability();

        public static vmCheckOverStability DcCheckDisplacement
        {
            get { return _dcCheckDisplacement; }
        }

        private ObservableRangeCollection<mDisplacement> _dgDisplacment = new ObservableRangeCollection<mDisplacement>();

        public ObservableRangeCollection<mDisplacement> DgDisplacment
        {
            get
            {
                
                return _dgDisplacment;
            }
            set
            {
                _dgDisplacment = value;
                OnPropertyChanged(nameof(DgDisplacment));
            }
        }

        private ObservableRangeCollection<mDrift> _dgDrift = new ObservableRangeCollection<mDrift>();

        public ObservableRangeCollection<mDrift> DgDrift
        {
            get
            {

                return _dgDrift;
            }
            set
            {
                _dgDrift = value;
                OnPropertyChanged(nameof(DgDrift));
            }
        }

        ETABsClass ETABsClass { get; set; } = new ETABsClass();

        #region Method
        private ActionCommand displacementUpdate;

        public ICommand DisplacementUpdate
        {
            get
            {
                if (displacementUpdate == null)
                {
                    displacementUpdate = new ActionCommand(PerformDisplacementUpdate);
                }

                return displacementUpdate;
            }
        }



        private void PerformDisplacementUpdate()
        {
            DgDisplacment.Clear();
            DgDrift.Clear();
            int StoryNumber = 1;
            string[] StoryName = null;
            double[] StoryHeight = null;
            double[] StoryElevation = null;
            bool[] IsMasterstory = null;
            string[] SimilarToStrory = null;
            bool[] SpiliceAbove = null;
            double[] SpliceHeight = null;
            ETABsClass.MySapModel.Story.GetStories(ref StoryNumber, ref StoryName, ref StoryElevation, ref StoryHeight, ref IsMasterstory, ref SimilarToStrory, ref SpiliceAbove, ref SpliceHeight);
            foreach(string eStoryName in StoryName )
            {
                if(eStoryName =="Base")
                {
                    continue;
                }
                else
                {
                    mDisplacement mDisplacement = ETABsClass.CheckDisplacement(eStoryName);
                    
                    DgDisplacment.Add(mDisplacement);
                    try
                    {
                        mDrift mDrift = ETABsClass.CheckDrift(eStoryName);
                        DgDrift.Add(mDrift);
                    }
                    catch
                    {

                    }

                }

            }
            
        }


        
        #endregion
    }
}
