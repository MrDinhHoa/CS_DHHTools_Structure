using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using BIMSoftLib.MVVM;


namespace _02_ETABSTools.MVVM.Model
{
    public class mDisplacement: PropertyChangedBase
    {
        private string _storyName;
        public string StoryName
        {
            get => _storyName;
            set
            {
                _storyName = value;
                OnPropertyChanged(nameof(StoryName));
            }
        }

        private double _displacementX;
        public double DisplacementX
        {
            get => _displacementX;
            set
            {
                _displacementX = value;
                OnPropertyChanged(nameof(DisplacementX));
            }
        }

        private double _displacementY;
        public double DisplacementY
        {
            get => _displacementY;
            set
            {
                _displacementY = value;
                OnPropertyChanged(nameof(DisplacementY));
            }
        }

        private string _checkOk;
        public string CheckOK
        {
            get => _checkOk;
            set
            {
                _checkOk = value;
                OnPropertyChanged(nameof(CheckOK));
            }
        }

        private double _storyHeight;
        public double StoryHeight
        {
            get => _storyHeight;
            set
            {
                _storyHeight = value;
                OnPropertyChanged(nameof(StoryHeight));
            }
        }

        private double _limit;
        public double Limit
        {
            get => _limit;
            set
            {
                _limit = value;
                OnPropertyChanged(nameof(Limit));
            }
        }



    }
}
