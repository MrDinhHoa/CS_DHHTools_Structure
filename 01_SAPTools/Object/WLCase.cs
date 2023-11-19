using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using BIMSoftLib.MVVM;

namespace _01_SAPTools.Object
{
    class WLCase: PropertyChangedBase
    {

        private string _nameCase;
        public string NameCase
        {
            get => _nameCase;
            set
            {
                _nameCase = value;
                OnPropertyChanged(nameof(NameCase));
            }
        }

        private int _zone;
        public int Zone
        {
            get => _zone;
            set
            {
                _zone = value;
                OnPropertyChanged(nameof(Zone));
            }
        }

        private double _gCpf;
        public double GCpf
        {
            get
            {
                return _gCpf;
            }
            set
            {
                _gCpf = value;
                OnPropertyChanged(nameof(GCpf));
            }

        }

        private double _gCpi;
        public double GCpi
        {
            get => _gCpi;
            set
            {
                _gCpi = value;
                OnPropertyChanged(nameof(GCpi));
            }
        }

        private double _gCpf_gCpi;
        public double GCpf_GCpi
        {
            get => _gCpf_gCpi;
            set
            {
                _gCpf_gCpi = value;
                OnPropertyChanged(nameof(_gCpf_gCpi));
            }
        }

        private double _wLoadOnFrame;
        public double WLoadOnFrame 
        {
            get
            {
                return _wLoadOnFrame;
            }
            set
            {
                _wLoadOnFrame = value;
                OnPropertyChanged(nameof(WLoadOnFrame));
            }
        }

    }
}
