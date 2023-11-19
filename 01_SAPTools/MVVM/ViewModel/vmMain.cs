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
using _01_SAPTools.Library;
using _01_SAPTools.MVVM.View;
using _01_SAPTools.MVVM.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.Remoting.Messaging;
using System.Collections;
using System.Diagnostics.Eventing.Reader;

namespace _01_SAPTools.MVVM.ViewModel
{
    class vmMain : PropertyChangedBase
    {
        private static vmMain _dcMain = new vmMain();

        public static vmMain DcMain
        {
            get { return _dcMain; }
        }

        readonly SAPClass sapClass = new SAPClass();
        
        private ObservableRangeCollection<dynamic> _listSection = new ObservableRangeCollection<dynamic>();

        public ObservableRangeCollection<dynamic> ListSection
        {
            get
            {
                var param = "NameSection";
                var propertyInfo = typeof(ISection).GetProperty(param);
                _listSection.OrderBy(x => propertyInfo.GetValue(x, null));
                return _listSection;
            }
            set
            {
                _listSection = value;
                //_listSection.Clear();
                //foreach (var item in value)
                //{
                //    _listSection.Add(item);
                //}
                OnPropertyChanged(nameof(ListSection));
            }
        }

        private ObservableRangeCollection<ISection> _iSource = new ObservableRangeCollection<ISection>();

        public ObservableRangeCollection<ISection> ISource
        {
            get { return _iSource; }
            set
            {
                _iSource = value;
                OnPropertyChanged(nameof(ISource));
            }
        }

        private ObservableRangeCollection<CSection> _cSource = new ObservableRangeCollection<CSection>();

        public ObservableRangeCollection<CSection> CSource
        {
            get { return _cSource; }
            set
            {
                _cSource = value;
                OnPropertyChanged(nameof(CSource));
            }
        }

        private ObservableRangeCollection<RodSection> _rodSource = new ObservableRangeCollection<RodSection>();

        public ObservableRangeCollection<RodSection> RodSource
        {
            get { return _rodSource; }
            set
            {
                _rodSource = value;
                OnPropertyChanged(nameof(RodSource));
            }
        }

        private ObservableRangeCollection<AngleSection> _angleSource = new ObservableRangeCollection<AngleSection>();

        public ObservableRangeCollection<AngleSection> AngleSource
        {
            get { return _angleSource; }
            set
            {
                _angleSource = value;
                OnPropertyChanged(nameof(AngleSource));
            }
        }

        private ObservableRangeCollection<string> _listLoadPattern = new ObservableRangeCollection<string>();

        public ObservableRangeCollection<string> ListLoadPattern
        {
            get
            {
                _listLoadPattern.Add("DL");
                _listLoadPattern.Add("Co");
                _listLoadPattern.Add("Lr");
                _listLoadPattern.Add("L");
                _listLoadPattern.Add("WA1_L");
                _listLoadPattern.Add("WA1_R");
                _listLoadPattern.Add("WA2_L");
                _listLoadPattern.Add("WA2_R");
                _listLoadPattern.Add("WB1");
                _listLoadPattern.Add("WB2");
                return _listLoadPattern;
            }
            set
            {
                _listLoadPattern = value;
                OnPropertyChanged(nameof(ListLoadPattern));
            }
        }

        private ObservableRangeCollection<SapMaterial> _materialSource = new ObservableRangeCollection<SapMaterial>();

        public ObservableRangeCollection<SapMaterial> MaterialSource
        {
            get { return _materialSource; }
            set
            {
                _materialSource = value;
                OnPropertyChanged(nameof(MaterialSource));
            }
        }

        private int _numberBay = 7;

        public int NumberBay
        {
            get => _numberBay;
            set
            {
                _numberBay = value;
                OnPropertyChanged("NumberBay");
            }

        }

        private double _bayLength = 10;

        public double BayLength
        {
            get => _bayLength;
            set
            {
                _bayLength = value;
                OnPropertyChanged("BayLength");
            }

        }

        private double _endbayLength = 8;

        public double EndBayLength
        {
            get => _endbayLength;
            set
            {
                _endbayLength = value;
                OnPropertyChanged("EndBayLength");
            }

        }

        private double _spanWidth = 20;

        public double SpanWidth
        {
            get => _spanWidth;
            set
            {
                _spanWidth = value;
                OnPropertyChanged("SpanWidth");
            }

        }

        private double _panWidthEndBay = 5;

        public double SpanWidthEndBay
        {
            get => _panWidthEndBay;
            set
            {
                _panWidthEndBay = value;
                OnPropertyChanged(nameof(SpanWidthEndBay));
            }

        }

        private double _eaveHeight = 7;

        public double EaveHeight
        {
            get => _eaveHeight;
            set
            {
                _eaveHeight = value;
                OnPropertyChanged("EaveHeight");
            }

        }

        private double _buildingHeight = 10.5;

        public double BuildingHeight
        {
            get => _buildingHeight;
            set
            {
                _buildingHeight = value;
                OnPropertyChanged("BuildingHeight");
            }

        }

        private double _roofAngle = 5;

        public double RoofAngle
        {
            get => _roofAngle;
            set
            {
                _roofAngle = value;
                OnPropertyChanged(nameof(RoofAngle));
            }

        }

        private double _deadLoad = 0.12;

        public double DeadLoad
        {
            get => _deadLoad;
            set
            {
                _deadLoad = value;
                OnPropertyChanged(nameof(DeadLoad));
            }
        }

        private double _collateralLoad = 0.2;

        public double CollateralLoad
        {
            get => _collateralLoad;
            set
            {
                _collateralLoad = value;
                OnPropertyChanged(nameof(CollateralLoad));
            }
        }

        private double _liveRoofLoad = 0.3;

        public double LiveRoofLoad
        {
            get => _liveRoofLoad;
            set
            {
                _liveRoofLoad = value;
                OnPropertyChanged(nameof(LiveRoofLoad));
            }
        }

        private double _liveLoad;

        public double LiveLoad
        {
            get => _liveLoad;
            set
            {
                _liveLoad = value;
                OnPropertyChanged(nameof(LiveLoad));
            }
        }

        private double _windPressure = 95;

        public double WindPressure
        {
            get => _windPressure;
            set
            {
                _windPressure = value;
                OnPropertyChanged(nameof(WindPressure));
                OnPropertyChanged(nameof(VeloWind3s20));
                OnPropertyChanged(nameof(VeloWind3s50));
                OnPropertyChanged(nameof(VeloWindCal));
            }
        }

        private double _veloWind3s20;

        public double VeloWind3s20
        {
            get
            {
                _veloWind3s20 = Math.Sqrt(WindPressure / 0.0613);
                return _veloWind3s20;
            }
            set
            {
                if (_veloWind3s20 == value)
                {
                    _veloWind3s20 = value;
                    OnPropertyChanged(nameof(VeloWind3s20));
                    OnPropertyChanged(nameof(VeloWind3s50));
                    OnPropertyChanged(nameof(VeloWindCal));
                }

            }
        }

        private double _veloWind3s50;

        public double VeloWind3s50
        {
            get
            {
                _veloWind3s50 = VeloWind3s20 / (0.36 + 0.1 * Math.Log(12 * 20));
                return _veloWind3s50;
            }
            set
            {
                _veloWind3s50 = value;
                OnPropertyChanged(nameof(VeloWind3s50));
                OnPropertyChanged(nameof(VeloWindCal));
            }
        }

        private double _veloWindCal;

        public double VeloWindCal
        {
            get
            {
                _veloWindCal = VeloWind3s50 * (0.36 + 0.1 * Math.Log(12 * 700));
                return _veloWindCal;
            }
            set
            {
                _veloWindCal = value;
                OnPropertyChanged(nameof(VeloWindCal));
            }
        }

        private bool _isEndBay;

        public bool IsEndBay
        {
            get { return _isEndBay; }
            set
            {
                _isEndBay = value;
                OnPropertyChanged(nameof(IsEndBay));
            }
        }

        private bool _isIntBay;

        public bool IsIntBay
        {
            get { return _isIntBay; }
            set
            {
                _isIntBay = value;
                OnPropertyChanged(nameof(IsIntBay));
            }
        }

        public List<int> NoSlopeList { get; set; } = new List<int>(new int[] {1, 2});
        private int _noSlopeSelected;

        public int NoSlopeSelected
        {
            get => _noSlopeSelected;
            set
            {
                _noSlopeSelected = value;
                OnPropertyChanged(nameof(NoSlopeSelected));
            }
        }

        public List<string> FrameTypeList { get; set; } =
            new List<string>(new string[] {"1 - No Middle Column", "2 - With Middle Column"});

        private string _frameTypeSelected;

        public string FrameTypeSelected
        {
            get => _frameTypeSelected;
            set
            {
                _frameTypeSelected = value;
                OnPropertyChanged(nameof(FrameTypeSelected));
            }
        }

        private dynamic _columnSelected;

        public dynamic ColumnSelected
        {
            get => _columnSelected;
            set
            {
                _columnSelected = value;
                OnPropertyChanged(nameof(ColumnSelected));
            }
        }

        private dynamic _beamSelected;

        public dynamic BeamSelected
        {
            get => _beamSelected;
            set
            {
                _beamSelected = value;
                OnPropertyChanged(nameof(BeamSelected));
            }
        }

        private dynamic _midColumnSelected;

        public dynamic MidColumnSelected
        {
            get => _midColumnSelected;
            set
            {
                _midColumnSelected = value;
                OnPropertyChanged(nameof(MidColumnSelected));
            }
        }

        private RodSection _rodSelected;

        public RodSection RodSelected
        {
            get => _rodSelected;
            set
            {
                _rodSelected = value;
                OnPropertyChanged(nameof(RodSelected));
            }
        }

        private SapMaterial _materialSelected;

        public SapMaterial MaterialSelected
        {
            get => _materialSelected;
            set
            {
                _materialSelected = value;
                OnPropertyChanged(nameof(MaterialSelected));
            }
        }

        public List<string> StandardList { get; set; } =
            new List<string>(new string[] {"ASCE 7-05", "ASCE 7-10", "ASCE 7-16"});

        private string _standardSelected;

        public string StandardSelected
        {
            get => _standardSelected;
            set
            {
                _standardSelected = value;
                OnPropertyChanged(nameof(StandardSelected));
                OnPropertyChanged(nameof(BuildingCategoryList));
                OnPropertyChanged(nameof(BuildingCategorySelected));
            }
        }

        private ObservableRangeCollection<string> _buildingCategoryList = new ObservableRangeCollection<string>();

        public ObservableRangeCollection<string> BuildingCategoryList 
        { 
            get
            {
                _buildingCategoryList.Clear();
                if (StandardSelected == "ASCE 7-10")
                {
                    _buildingCategoryList.Add("I");
                    _buildingCategoryList.Add("II");
                    _buildingCategoryList.Add("III");
                }
                else
                {
                    _buildingCategoryList.Add("I");
                    _buildingCategoryList.Add("II");
                    _buildingCategoryList.Add("III");
                    _buildingCategoryList.Add("IV");
                }
                return _buildingCategoryList;
            }    
            set
            {
                _buildingCategoryList = value;
                OnPropertyChanged(nameof(BuildingCategoryList));
                OnPropertyChanged(nameof(BuildingCategorySelected));
            } 
        } 
            
        private string _buildingCategorySelected;

        public string BuildingCategorySelected
        {
            get => _buildingCategorySelected;
            set
            {
                _buildingCategorySelected = value;
                OnPropertyChanged(nameof(BuildingCategorySelected));
            }
        }

        public List<string> ExposureList { get; set; } = new List<string>(new string[] {"B", "C", "D"});
        private string _expSelected;

        public string ExpSelected
        {
            get => _expSelected;
            set
            {
                _expSelected = value;
                OnPropertyChanged(nameof(ExpSelected));
            }
        }

        private int _tabSectionSelect;

        public int TabSectionSelect
        {
            get => _tabSectionSelect;
            set
            {
                _tabSectionSelect = value;
                OnPropertyChanged(nameof(TabSectionSelect));
            }
        }

        private TabItem _tabSectionSelectItem;

        public TabItem TabSectionSelectItem
        {
            get => _tabSectionSelectItem;
            set
            {
                _tabSectionSelectItem = value;
                OnPropertyChanged(nameof(TabSectionSelectItem));
            }
        }

        //Command Connect SAP
        private ActionCommand _connectSAP;

        public ICommand ConnectSAP
        {
            get
            {
                if (_connectSAP == null)
                {
                    _connectSAP = new ActionCommand(PerformConnectSAP);
                }

                return _connectSAP;
            }
        }

        private void PerformConnectSAP()
        {
            sapClass.SelectSAP();
        }

        //Command Section
        private ActionCommand _addSection;

        public ICommand AddSection
        {
            get
            {
                if (_addSection == null)
                {
                    _addSection = new ActionCommand(PerformAddSection);
                }

                return _addSection;
            }
        }

        private void PerformAddSection()
        {
            switch (_tabSectionSelect) 
            {
                case 0:
                    vAddISection vISection = new vAddISection();
                    vISection.Show();
                    break;
                case 1:
                    vAddCSection vCSection = new vAddCSection();
                    vCSection.Show();
                    break;
                case 2:
                    vAddAngleSection vAngleSection = new vAddAngleSection();
                    vAngleSection.Show();
                    break;
                case 3:
                    vAddRodSection vRodSection = new vAddRodSection();
                    vRodSection.Show();
                    break;

            }
        }

        private ActionCommand _deleteSection;

        public ICommand DeleteSection
        {
            get
            {
                if (_deleteSection == null)
                {
                    _deleteSection = new ActionCommand(PerformDeleteSection);
                }

                return _deleteSection;
            }
        }

        private void PerformDeleteSection()
        {
            MessageBox.Show(TabSectionSelect.ToString());
        }

        //Command Create Model
        private ActionCommand _quickcreate2DModel;

        public ICommand QuickCreate2DModel
        {
            get
            {
                if (_quickcreate2DModel == null)
                {
                    _quickcreate2DModel = new ActionCommand(PerformQuickCreate2DModel);
                }

                return _quickcreate2DModel;
            }
        }

        private void PerformQuickCreate2DModel()
        {
            sapClass.QuickCreate2DModel(EaveHeight, BuildingHeight, SpanWidth, MaterialSource, ListSection,ColumnSelected,BeamSelected,MidColumnSelected);
            sapClass.CreateLoadPattern(ListLoadPattern);
        }

        private ActionCommand _quickcreate3DModel;

        public ICommand QuickCreate3DModel
        {
            get
            {
                if (_quickcreate3DModel == null)
                {
                    _quickcreate3DModel = new ActionCommand(PerformQuickCreate3DModel);
                }

                return _quickcreate3DModel;
            }
        }

        private void PerformQuickCreate3DModel()
        {
            sapClass.QuickCreate3DModel(NumberBay, BayLength, EndBayLength, SpanWidth, SpanWidthEndBay, EaveHeight,
                BuildingHeight);
            sapClass.CreateLoadPattern(ListLoadPattern);
        }

        //Command Wind Load
        private ActionCommand _wLoadIntBay;

        public ICommand WLoadIntBay
        {
            get
            {
                if (_wLoadIntBay == null)
                {
                    _wLoadIntBay = new ActionCommand(PerformWLoadIntBay);
                }

                return _wLoadIntBay;
            }
        }

        private void PerformWLoadIntBay()
        {
        }

        private ActionCommand _wLoadEndBay;

        public ICommand WLoadEndBay
        {
            get
            {
                if (_wLoadEndBay == null)
                {
                    _wLoadEndBay = new ActionCommand(PerformWLoadEndBay);
                }

                return _wLoadEndBay;
            }
        }

        private void PerformWLoadEndBay()
        {
            vWindLoad wWIN = new vWindLoad();
            wWIN.Show();
        }

    }
}
