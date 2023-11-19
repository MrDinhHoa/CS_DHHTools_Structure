using _01_SAPTools.Library;
using _01_SAPTools.MVVM.Model;
using _01_SAPTools.MVVM.ViewModel;
using SAP2000v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _01_SAPTools.MVVM.View
{
    /// <summary>
    /// Interaction logic for vMain.xaml
    /// </summary>
    public partial class vMain : Window
    {
        public vMain()
        {
            vmMain.DcMain.StandardSelected = vmMain.DcMain.StandardList[1];
            vmMain.DcMain.ExpSelected = vmMain.DcMain.ExposureList[1];
            vmMain.DcMain.FrameTypeSelected = vmMain.DcMain.FrameTypeList[1];
            vmMain.DcMain.NoSlopeSelected = vmMain.DcMain.NoSlopeList[1];
            vmMain.DcMain.BuildingCategorySelected = vmMain.DcMain.BuildingCategoryList[1];
            SapMaterial fy3450 = new SapMaterial()
            {
                NSteelMat = "fy3450",
                Fy = 3450,
                Fu = 3450,
                EFy = 3450,
                EFu = 3450,
            };
            SapMaterial fy2350 = new SapMaterial()
            {
                NSteelMat = "fy2350",
                Fy = 2350,
                Fu = 2350,
                EFy = 2350,
                EFu = 2350,
            };
            ISection iSection = new ISection()
            {
                NameSection = "I-200x6+200x8",
                OutsideHeight_t3 = 216,
                TopFlangeWidth_t2 = 200,
                TopFlangeThickness_tf = 8,
                BotFlangeWidth_t2b =200,
                BotFlangeThickness_tfb = 8,
                WebThickness_tw = 6,
            };
            RodSection rodSection = new RodSection()
            {
                NameSection = "ROD 20",
                Diameter = 20,
            };
            AngleSection angleSection = new AngleSection() 
            { 
                NameSection = "L-50x50x5",
                OutsideHorizontalLeg_t3 = 50,
                OutsideVerticalLeg_t3 = 50,
                HorizontalLegThickness_tf = 5,
                VerticalLegThickness_tw = 5,

            };
            CSection cSection = new CSection()
            {
                NameSection = "C-100x50x2",
                OutsideDepth_t3 = 100,
                OutsideFlangeWidth_t3 = 50,
                FlangeThickness_tf = 2, 
                WebThickness_tw = 2,    
            };
            vmMain.DcMain.ISource.Add(iSection);
            vmMain.DcMain.RodSource.Add(rodSection);
            vmMain.DcMain.AngleSource.Add(angleSection);
            vmMain.DcMain.CSource.Add(cSection);
            vmMain.DcMain.ListSection.Add(iSection);
            vmMain.DcMain.ListSection.Add(rodSection);
            vmMain.DcMain.ListSection.Add(cSection);
            vmMain.DcMain.ListSection.Add(angleSection);
            vmMain.DcMain.MaterialSource.Add(fy3450);
            vmMain.DcMain.MaterialSource.Add(fy2350);
            vmMain.DcMain.ColumnSelected = vmMain.DcMain.ISource[0];
            vmMain.DcMain.BeamSelected = vmMain.DcMain.ISource[0];
            vmMain.DcMain.MidColumnSelected = vmMain.DcMain.ISource[0];
            vmMain.DcMain.RodSelected = vmMain.DcMain.RodSource[0];
            vmMain.DcMain.MaterialSelected = vmMain.DcMain.MaterialSource[0];
            vmMain.DcMain.IsIntBay = true;
            InitializeComponent();
        }
    }
}
