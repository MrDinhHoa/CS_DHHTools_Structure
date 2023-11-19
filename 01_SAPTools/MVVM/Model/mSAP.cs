using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SAP2000v1;
using BIMSoftLib.MVVM;
using _01_SAPTools.MVVM.Model;

namespace _01_SAPTools.Library
{
    public class SAPClass
    {
        public static cOAPI MySapObject { get; set; }
        public static cSapModel MySapModel { get; set; }
        public static cHelper MyHelper { get; set; }
        public void SelectSAP ()
        {
            MyHelper = new Helper();
            MySapObject = (cOAPI)System.Runtime.InteropServices.Marshal.GetActiveObject("CSI.SAP2000.API.SapObject");
            MySapModel = MySapObject.SapModel;
            MessageBox.Show("Connected SAP2000 Complete");
        }
        public void QuickCreate2DModel(double eveaheight, double buildingHeight, double spanWidth, 
                                       ObservableRangeCollection<SapMaterial> MaterialSteelList, ObservableRangeCollection<dynamic> ListSection,
                                       dynamic ColumnSelected, dynamic BeamSelected, dynamic MidColumnSelectd )
        {   
            MySapModel.InitializeNewModel(eUnits.kN_m_C);
            MySapModel.File.NewBlank();
            string[] FrameName = new string[4];
            string temp_string1 = FrameName[0];
            //initialize new material property
            foreach (SapMaterial vMat in MaterialSteelList)
            {
                MySapModel.PropMaterial.SetMaterial(vMat.NSteelMat, eMatType.Steel);
                //assign other properties
                MySapModel.PropMaterial.SetOSteel_1(vMat.NSteelMat, vMat.Fy, vMat.Fu, vMat.EFy, vMat.EFu, 1, 2, 0.02, 0.1, 0.2, -0.1);
            }

            foreach (dynamic eSection in ListSection)
            {
                if(eSection.GetType().ToString() == "_01_SAPTools.MVVM.Model.ISection")
                {
                    ISection iSection = (ISection)eSection;
                    MySapModel.PropFrame.SetISection(iSection.NameSection, MaterialSteelList[0].NSteelMat, 
                                                        iSection.OutsideHeight_t3 * 0.001, iSection.TopFlangeWidth_t2 * 0.001,
                                                        iSection.TopFlangeThickness_tf * 0.001, iSection.WebThickness_tw * 0.001, 
                                                        iSection.BotFlangeWidth_t2b * 0.001, iSection.BotFlangeThickness_tfb * 0.001);
                }
                else if (eSection.GetType().ToString() == "_01_SAPTools.MVVM.Model.CSection")
                {
                    CSection cSection = (CSection)eSection;
                    MySapModel.PropFrame.SetChannel(cSection.NameSection, MaterialSteelList[1].NSteelMat,
                                                        cSection.OutsideDepth_t3 * 0.001,cSection.OutsideFlangeWidth_t3 * 0.001,
                                                        cSection.FlangeThickness_tf * 0.001, cSection.WebThickness_tw * 0.001);
                }
            }    

            //add Frame 
            MySapModel.FrameObj.AddByCoord(0, 0, 0, 0, 0, eveaheight, ref temp_string1, ColumnSelected.NameSection, "1", "Global");
            MySapModel.FrameObj.AddByCoord(0, 0, eveaheight, spanWidth/2, 0, buildingHeight, ref temp_string1, BeamSelected.NameSection, "2", "Global");
            MySapModel.FrameObj.AddByCoord(spanWidth, 0, 0, spanWidth, 0, eveaheight, ref temp_string1, ColumnSelected.NameSection, "3", "Global");
            MySapModel.FrameObj.AddByCoord(spanWidth, 0, eveaheight, spanWidth / 2, 0, buildingHeight, ref temp_string1, BeamSelected.NameSection, "4", "Global");
            bool temp_bool = false;
            MySapModel.View.RefreshView(0, temp_bool);

            //assign Load Pattern
            //MySapModel.FrameObj.SetLoadDistributed(FrameName[1], "DL",1,10,0,1,DeadLoad,DeadLoad,"Global");
        }

        public void QuickCreate3DModel(double NumberBay, double BayLength, double EndBayLength, double SpanWidth, double SWEndBay, double EaveHeight, double BuildingHeight)
        {
            MySapModel.InitializeNewModel(eUnits.kN_m_C);
            MySapModel.File.NewBlank();
            string[] FrameName = new string[4];
            string temp_string1 = FrameName[0];
            //initialize new material property
            MySapModel.PropMaterial.SetMaterial("fy3450", eMatType.Steel);
            //assign other properties
            MySapModel.PropMaterial.SetOSteel_1("fy3450", 3450, 3450, 3450, 3450, 1, 2, 0.02, 0.1, 0.2, -0.1);
            //initialize new Section
            MySapModel.PropFrame.SetISection("I-250x8+200x10", "fy3450", 0.270, 0.200, 0.010, 0.008, 0.200, 0.010);
            for(int i = 1; i < NumberBay; i++)
            {
                double xCoord = EndBayLength + (i - 1) * BayLength;
                MySapModel.FrameObj.AddByCoord(xCoord,0,0,xCoord,0,EaveHeight,ref temp_string1,"I-250x8+200x10");
                MySapModel.FrameObj.AddByCoord(xCoord, 0, EaveHeight, xCoord,SpanWidth/2,BuildingHeight , ref temp_string1, "I-250x8+200x10");
                MySapModel.FrameObj.AddByCoord(xCoord, SpanWidth, 0, xCoord, SpanWidth, EaveHeight, ref temp_string1, "I-250x8+200x10");
                MySapModel.FrameObj.AddByCoord(xCoord, SpanWidth, EaveHeight, xCoord, SpanWidth / 2, BuildingHeight, ref temp_string1, "I-250x8+200x10");
                MySapModel.View.RefreshView(0, true);
            }    

        }

        public void CreateLoadPattern(ObservableRangeCollection<string> ListLoadpattern)
        {
            bool addAnalysisCase = true;
            foreach(string loadpattern in ListLoadpattern)
            {
                if (loadpattern == "DL")
                { MySapModel.LoadPatterns.Add(loadpattern, eLoadPatternType.Dead, 1, addAnalysisCase); }
                else if(loadpattern == "Co")
                { MySapModel.LoadPatterns.Add(loadpattern, eLoadPatternType.SuperDead, 0, addAnalysisCase); }
                else if (loadpattern == "Lr" || loadpattern == "L")
                { MySapModel.LoadPatterns.Add(loadpattern, eLoadPatternType.Live, 0, addAnalysisCase); }
                else if (loadpattern.StartsWith("W"))
                { MySapModel.LoadPatterns.Add(loadpattern, eLoadPatternType.Wind, 0, addAnalysisCase); }
                else
                { MySapModel.LoadPatterns.Add(loadpattern, eLoadPatternType.Other, 0, addAnalysisCase); }
            }    
        }
    }

}
