using CSiAPIv1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _02_ETABSTools.MVVM.Model
{
    public class ETABsClass
    {
        public static cOAPI MyEtabsObject { get; set; }
        public static cSapModel MySapModel { get; set; }
        public static cHelper MyHelper { get; set; }
        public void SelectETABS()
        {
            MyHelper = new Helper();
            MyEtabsObject = (CSiAPIv1.cOAPI)System.Runtime.InteropServices.Marshal.GetActiveObject("CSI.ETABS.API.ETABSObject");
            MySapModel = MyEtabsObject.SapModel;
            MessageBox.Show("Connected ETABS Complete");
        }
        public class JointDisplacement
        {
            public string Level { get; set; }
            public string Name { get; set; }
            public double Ux { get; set; }
            public double Uy { get; set; }
            public double Uz { get; set; }
            public double Rx { get; set; }
            public double Ry { get; set; }
            public double Rz { get; set; }

        }

        public class JointDrift
        {
            public string Level { get; set; }
            public string Name { get; set; }
            public double DisX { get; set; }
            public double DisY { get; set; }
            public double DriftX { get; set; }
            public double DriftY { get; set; }

        }

        public mDisplacement CheckDisplacement(string StoryName)
        {

                int NumberPointNames = 1;
                string[] uniqueName = null;
            
                MySapModel.SetPresentUnits(eUnits.kN_m_C);
                MySapModel.Results.Setup.DeselectAllCasesAndCombosForOutput();
                int v = MySapModel.Results.Setup.SetComboSelectedForOutput("ENVESLS");
                double StoryHeight = 0;
                MySapModel.Story.GetElevation(StoryName, ref StoryHeight);
                MySapModel.PointObj.GetNameListOnStory(StoryName, ref NumberPointNames, ref uniqueName);

                List<JointDisplacement> jdisps = uniqueName.AsParallel().Select(unique =>
                {
                    Stopwatch jointDisplStopwatch = Stopwatch.StartNew();
                    int NumberResults = 1;
                    string[] Obj = null;
                    string[] Elm = null;
                    string[] LoadCase = null;
                    string[] StepType = null;
                    double[] StepNum = null;
                    double[] U1 = null;
                    double[] U2 = null;
                    double[] U3 = null;
                    double[] R1 = null;
                    double[] R2 = null;
                    double[] R3 = null;
                    MySapModel.Results.JointDispl(unique, eItemTypeElm.Element, ref NumberResults, ref Obj, ref Elm, ref LoadCase, ref StepType, ref StepNum,
                                                 ref U1, ref U2, ref U3, ref R1, ref R2, ref R3);
                    jointDisplStopwatch.Stop();


                    return new JointDisplacement()
                    {
                        Name = unique,
                        Ux = U1[0],
                        Uy = U2[0],
                        Uz = U3[0],
                        Rx = R1[0],
                        Ry = R2[0],
                        Rz = R3[0]
                    };
                }).ToList();

                double maxUx = jdisps.Select(k => Math.Abs(k.Ux)).Max();
                double maxUy = jdisps.Select(k => Math.Abs(k.Uy)).Max();
                string check;


                if (maxUx < StoryHeight / 500 && maxUy < StoryHeight / 500)
                { 
                    check = "OK";
                }
                else 
                {
                    check = "Not OK";
                }
                return new mDisplacement()
                {
                    StoryName = StoryName,
                    StoryHeight = StoryHeight,
                    DisplacementX = maxUx,
                    DisplacementY = maxUy,
                    Limit = StoryHeight / 500,
                    CheckOK = check,

                };

        }

        public mDrift CheckDrift(string StoryName)
        {
            int NumberPointNames = 1;
            string[] uniqueName = null;

            MySapModel.SetPresentUnits(eUnits.kN_m_C);
            MySapModel.Results.Setup.DeselectAllCasesAndCombosForOutput();
            int v = MySapModel.Results.Setup.SetComboSelectedForOutput("ENVESLS");
            double StoryHeight = 0;
            MySapModel.Story.GetElevation(StoryName, ref StoryHeight);
            MySapModel.PointObj.GetNameListOnStory(StoryName, ref NumberPointNames, ref uniqueName);
            int NumberResults = 1;
            string[] Story = null;
            string[] Label = null;
            string[] LoadCase = null;
            string[] Name = null;
            string[] StepType = null;
            double[] StepNum = null;
            double[] DisplacementX = null;
            double[] DisplacementY = null;
            double[] DriftX = null;
            double[] DriftY = null;
            MySapModel.Results.JointDrifts(ref NumberResults, ref Story, ref Label, ref Name, ref LoadCase, ref StepType, ref StepNum, ref DisplacementX, ref DisplacementY, ref DriftX, ref DriftY);
            List<JointDrift> jdriftFull = new List<JointDrift>();
            List<JointDrift> jointDrifts = new List<JointDrift>();
            if (Story.Contains(StoryName) == true)
            {

                for (int i = 0; i < NumberResults; i++)
                {
                    jdriftFull.Add
                    (
                        new JointDrift()
                        {
                            Level = Story[i],
                            Name = Name[i],
                            DriftX = DriftX[i],
                            DriftY = DriftY[i],
                        }
                    );
                }
                jointDrifts = jdriftFull.Where(x => x.Level == StoryName)
                                        .Select(x => new JointDrift
                                        {
                                            Level = x.Level,
                                            Name = x.Name,
                                            DriftX = x.DriftX,
                                            DriftY = x.DriftY,
                                        }).ToList();


                double maxUx = jointDrifts.Select(k => Math.Abs(k.DriftX)).Max();
                double maxUy = jointDrifts.Select(k => Math.Abs(k.DriftY)).Max();
                string check;


                if (maxUx < 0.002 && maxUy < 0.002)
                {
                    check = "OK";
                }
                else
                {
                    check = "Not OK";
                }
                return new mDrift()
                {
                    StoryName = StoryName,
                    StoryHeight = StoryHeight,
                    DriftX = maxUx,
                    DriftY = maxUy,
                    Limit = 0.002,
                    CheckOK = check,
                };
            }
            else {
                return new mDrift()
                {
                    StoryName = StoryName,
                    StoryHeight = StoryHeight,
                    DriftX = 0,
                    DriftY = 0,
                    Limit = 0.002,
                    CheckOK = "No Check",
                }; 
            }
        }

    }
}
