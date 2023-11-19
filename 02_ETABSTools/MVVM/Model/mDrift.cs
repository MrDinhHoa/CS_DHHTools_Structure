using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIMSoftLib.MVVM;

namespace _02_ETABSTools.MVVM.Model
{
    public class mDrift: PropertyChangedBase
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

        private double _driftX;
        public double DriftX
        {
            get => _driftX;
            set
            {
                _driftX = value;
                OnPropertyChanged(nameof(DriftX));
            }
        }

        private double _driftY;
        public double DriftY
        {
            get => _driftY;
            set
            {
                _driftY = value;
                OnPropertyChanged(nameof(DriftY));
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
