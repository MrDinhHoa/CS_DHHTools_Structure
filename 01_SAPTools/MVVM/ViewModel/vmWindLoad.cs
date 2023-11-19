using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BIMSoftLib.MVVM;
using System.Windows.Input;
using _01_SAPTools.MVVM.View;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using _01_SAPTools.Object;
using _01_SAPTools.MVVM.Model;
using WLCase = _01_SAPTools.Object.WLCase;

namespace _01_SAPTools.MVVM.ViewModel
{
    class vmWindLoad: PropertyChangedBase
    {
        public static vmWindLoad DcWindLoad = new vmWindLoad();

        private ObservableRangeCollection<WLCase> _dgWindLoadCaseA = new ObservableRangeCollection<WLCase>();
        public ObservableRangeCollection<WLCase> DGWindLoadCaseA
        {
            get 
            { 
                _dgWindLoadCaseA.Clear();
                for(int i = 1;i<9;i++)
                {
                    string NameCaseTemp = null;
                    if (i == 1)
                    {
                        NameCaseTemp = "WA1_(i+)";
                    }
                    else if (i == 5)
                    {
                        NameCaseTemp = "WA1_(i-)";
                    }
                    else NameCaseTemp = "";
                    double GCpiTemp;
                    if (i < 5)
                    {
                        GCpiTemp = GCpi;
                    }
                    else GCpiTemp = -GCpi;
                    string GCpfName;
                    int ZoneTemp;
                    if (i < 5)
                    {
                        GCpfName = "GCpf" + i.ToString() + "_LcA";
                        ZoneTemp = i;
                    }
                    else
                    { 
                        GCpfName = "GCpf" + (i - 4).ToString()+"_LcA"; 
                        ZoneTemp = i-4;
                    }

                    double GCpfValue = (double)GetType().GetProperty(GCpfName).GetValue(DcWindLoad);
                    WLCase wLCase = new WLCase
                    {
                        NameCase = NameCaseTemp,
                        Zone = ZoneTemp,
                        GCpf = GCpfValue,
                        GCpi = GCpiTemp,
                        GCpf_GCpi = GCpfValue - GCpiTemp,
                        WLoadOnFrame = QzPressure * (GCpfValue - GCpiTemp) * BayLength,
                    };
                    _dgWindLoadCaseA.Add(wLCase);
                }
                return _dgWindLoadCaseA; 
            }
            set
            {
                _dgWindLoadCaseA = value;
                OnPropertyChanged(nameof(DGWindLoadCaseA));
            }
        }

        private ObservableRangeCollection<WLCase> _dgWindLoadCaseB = new ObservableRangeCollection<WLCase>();
        public ObservableRangeCollection<WLCase> DGWindLoadCaseB
        {
            get
            {
                _dgWindLoadCaseB.Clear();
                for (int i = 1; i < 9; i++)
                {
                    string NameCaseTemp = null;
                    if (i == 1)
                    {
                        NameCaseTemp = "WB1";
                    }
                    else if (i == 5)
                    {
                        NameCaseTemp = "WB2";
                    }
                    else NameCaseTemp = "";
                    double GCpiTemp;
                    if (i < 5)
                    {
                        GCpiTemp = GCpi;
                    }
                    else GCpiTemp = -GCpi;
                    string GCpfName;
                    int ZoneTemp;
                    if (i < 5)
                    {
                        GCpfName = "GCpf" + i.ToString() +"_LcB";
                        ZoneTemp = i;
                    }
                    else
                    {
                        GCpfName = "GCpf" + (i - 4).ToString() + "_LcB";
                        ZoneTemp = i - 4;
                    }

                    double GCpfValue = (double)GetType().GetProperty(GCpfName).GetValue(DcWindLoad);
                    WLCase wLCase = new WLCase
                    {
                        NameCase = NameCaseTemp,
                        Zone = ZoneTemp,
                        GCpf = GCpfValue,
                        GCpi = GCpiTemp,
                        GCpf_GCpi = GCpfValue - GCpiTemp,
                        WLoadOnFrame = QzPressure * (GCpfValue - GCpiTemp) * BayLength,
                    };
                    _dgWindLoadCaseB.Add(wLCase);
                }
                return _dgWindLoadCaseB;
            }
            set
            {
                _dgWindLoadCaseB = value;
                OnPropertyChanged(nameof(DGWindLoadCaseB));
            }
        }

        private string _standardDesign;
        public string StandardDesign
        {
            get
            {
                _standardDesign = vmMain.DcMain.StandardSelected;
                return _standardDesign;
            }
            set
            {
                _standardDesign = value;
                OnPropertyChanged(nameof(StandardDesign));
            }

        }

        private dynamic _standardWindLoad;
        public dynamic StandardWindLoad
        {
            get 
            { 
                if (_standardDesign == "ASCE 7-05")
                {
                    _standardWindLoad = new ASCE7_05();
                }    
                else
                {
                    _standardWindLoad = new ASCE7_10();
                }    
                return _standardWindLoad; 
            }
            set
            {
                _standardWindLoad = value; OnPropertyChanged(nameof(StandardWindLoad));
            }
        }


        SAPMethod SAPMethod { get; set; } = new SAPMethod();

        private string _exporsure;
        public string Exporsure
        {
            get
            {
                _exporsure = vmMain.DcMain.ExpSelected;
                return _exporsure;
            }
            set
            {
                _exporsure = value;
                OnPropertyChanged(nameof(Exporsure));
            }

        }

        private double _h;
        public double H
        {
            get
            {
                if (vmMain.DcMain.EaveHeight<=4.6)
                {
                    _h = 4.6;
                }
                else 
                {
                    _h = vmMain.DcMain.EaveHeight;
                }

                return _h;
            }
            set
            {
                _h = value;
                OnPropertyChanged(nameof(H));
            }

        }

        private double _bayLength;
        public double BayLength
        {
            get
            {
                _bayLength = vmMain.DcMain.BayLength;
                return _bayLength;
            }
            set
            {
                _bayLength = value;
                OnPropertyChanged(nameof(BayLength));
            }

        }

        private double _roofAngle;
        public double RoofAngle
        {
            get
            {
                _roofAngle = vmMain.DcMain.RoofAngle;
                return _roofAngle;
            }
            set
            {
                _roofAngle = value;
                OnPropertyChanged(nameof(RoofAngle));
            }

        }

        private double _vCal;
        public double VCal
        {
            get
            {
                _vCal = vmMain.DcMain.VeloWindCal;
                return _vCal;
            }
            set
            {
                _vCal = value;
                OnPropertyChanged(nameof(VCal));
                OnPropertyChanged(nameof(QzPressure));
            }

        }

        private double _alpha;
        public double Alpha
        {
            get
            {
                if(Exporsure == "B")
                {
                    _alpha = 7;
                }
                else if (Exporsure == "C")
                {
                    _alpha = 9.5;
                }
                else if (Exporsure == "D")
                {
                    _alpha = 11.5;
                }    
                return _alpha;
            }
            set
            {
                _alpha = value;
                OnPropertyChanged(nameof(Alpha));
            }

        }

        private double _zG;
        public double ZG
        {
            get
            {
                if (Exporsure == "B")
                {
                    _zG= 365.76;
                }
                else if (Exporsure == "C")
                {
                    _zG = 274.32;
                }
                else if (Exporsure == "D")
                {
                    _zG = 213.36;
                }
                return _zG;
            }
            set
            {
                _zG = value;
                OnPropertyChanged(nameof(ZG));
            }

        }

        private double _kzRatio;
        public double KzRatio
        {
            get
            {
                if(Exporsure == "B" && H <=9.1)
                {
                    _kzRatio = 0.7;
                }
                else 
                {
                    _kzRatio = 2.01 * Math.Pow((H / ZG), (2 / Alpha));
                }
                
                return _kzRatio;
            }
            set
            {
                _kzRatio = value;
                OnPropertyChanged(nameof(KzRatio));
            }

        }

        private double _kdRatio =0.85;
        public double KdRatio
        {
            get
            {
                return _kdRatio;
            }
            set
            {
                _kdRatio = value;
                OnPropertyChanged(nameof(KdRatio));
            }

        }

        private double _kztRatio = 1;
        public double KztRatio
        {
            get
            {
                return _kztRatio;
            }
            set
            {
                _kztRatio = value;
                OnPropertyChanged(nameof(KztRatio));
            }

        }

        private double _qzPressure;
        public double QzPressure
        {
            get
            {
                _qzPressure = 0.613 * KzRatio * KztRatio * KdRatio * VCal * VCal * 0.001;
                return _qzPressure;
            }
            set
            {
                _qzPressure = value;
                OnPropertyChanged(nameof(QzPressure));
            }

        }

        private double _gCpf1_LcA;
        public double GCpf1_LcA
        {
            get
            {
                _gCpf1_LcA = SAPMethod.GetGCpfARatio(StandardDesign, RoofAngle, 1);
                return _gCpf1_LcA;
            }
            set
            {
                _gCpf1_LcA = value;
                OnPropertyChanged(nameof(GCpf1_LcA));
            }

        }

        private double _gCpf2_LcA;
        public double GCpf2_LcA
        {
            get
            {
                _gCpf2_LcA = SAPMethod.GetGCpfARatio(StandardDesign, RoofAngle, 2);
                return _gCpf2_LcA;
            }
            set
            {
                _gCpf2_LcA = value;
                OnPropertyChanged(nameof(GCpf2_LcA));
            }
        }

        private double _gCpf3_LcA;
        public double GCpf3_LcA
        {
            get
            {
                _gCpf3_LcA = SAPMethod.GetGCpfARatio(StandardDesign, RoofAngle, 3);
                return _gCpf3_LcA;
            }
            set
            {
                _gCpf3_LcA = value;
                OnPropertyChanged(nameof(GCpf3_LcA));
            }
        }

        private double _gCpf4_LcA;
        public double GCpf4_LcA
        {
            get
            {
                _gCpf4_LcA = SAPMethod.GetGCpfARatio(StandardDesign, RoofAngle, 4);
                return _gCpf4_LcA;
            }
            set
            {
                _gCpf4_LcA = value;
                OnPropertyChanged(nameof(GCpf4_LcA));
            }
        }

        private double _gCpf1_LcB;
        public double GCpf1_LcB
        {
            get
            {
                _gCpf1_LcB = SAPMethod.GetGCpfBRatio(StandardDesign, RoofAngle, 1);
                return _gCpf1_LcB;
            }
            set
            {
                _gCpf1_LcB = value;
                OnPropertyChanged(nameof(GCpf1_LcB));
            }
        }

        private double _gCpf2_LcB;
        public double GCpf2_LcB
        {
            get
            {
                _gCpf2_LcB = SAPMethod.GetGCpfBRatio(StandardDesign, RoofAngle, 2);
                return _gCpf2_LcB;
            }
            set
            {
                _gCpf2_LcB = value;
                OnPropertyChanged(nameof(GCpf2_LcB));
            }
        }

        private double _gCpf3_LcB;
        public double GCpf3_LcB
        {
            get
            {
                _gCpf3_LcB = SAPMethod.GetGCpfBRatio(StandardDesign, RoofAngle, 3);
                return _gCpf3_LcB;
            }
            set
            {
                _gCpf3_LcB = value;
                OnPropertyChanged(nameof(GCpf3_LcB));
            }
        }

        private double _gCpf4_LcB;
        public double GCpf4_LcB
        {
            get
            {
                _gCpf4_LcB = SAPMethod.GetGCpfBRatio(StandardDesign, RoofAngle, 4);
                return _gCpf4_LcB;
            }
            set
            {
                _gCpf4_LcB = value;
                OnPropertyChanged(nameof(GCpf4_LcB));
            }
        }

        private double _gCpi = 0.18;
        public double GCpi
        {
            get => _gCpi;
            set
            {
                _gCpi = value;
                OnPropertyChanged(nameof(GCpi));
            }
        }

        private ActionCommand _btnOk;
        public ICommand BtnOk
        {
            get
            {
                if (_btnOk == null)
                {
                    _btnOk = new ActionCommand(PerformBtnOK);
                }

                return _btnOk;
            }
        }
        private void PerformBtnOK()
        {
            
        }

    }
}
