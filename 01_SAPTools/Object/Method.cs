using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_SAPTools.Object
{
    public class SAPMethod
    {
        public double GCpfA { get; private set; }
        public double GCpfB { get; private set; }
        public double GetGCpfARatio(string StandardDesign,double RoofAngle, int Zone ) 
        {
            double GT1 = 0;
            double GT2 = 0;
            double GT3 = 0;
            double GT4 = 0;
            if (StandardDesign == "ASCE 7-05")
            {
                ASCE7_05 aSCE7_05 = new ASCE7_05();
                GT1 = aSCE7_05.figure6_10[0, Zone - 1];
                GT2 = aSCE7_05.figure6_10[1, Zone - 1];
                GT3 = aSCE7_05.figure6_10[2, Zone - 1];
                GT4 = aSCE7_05.figure6_10[3, Zone - 1];
            }
            else if( StandardDesign == "ASCE 7-10")
            {
                ASCE7_10 aSCE7_10 = new ASCE7_10();
                GT1 = aSCE7_10.figure28_4_1_LCA[0, Zone - 1];
                GT2 = aSCE7_10.figure28_4_1_LCA[1, Zone - 1];
                GT3 = aSCE7_10.figure28_4_1_LCA[2, Zone - 1];
                GT4 = aSCE7_10.figure28_4_1_LCA[3, Zone - 1];
            }    

            if (RoofAngle <= 5)
            {
                GCpfA = GT1;
            }
            else if (RoofAngle > 5 && RoofAngle < 20)
            {
                GCpfA = GT1 + (GT2 - GT1) * (RoofAngle - 5)/(20 - 5);
            }
            else if (RoofAngle == 20)
            {
                GCpfA = GT2;
            }
            else if (RoofAngle > 20 && RoofAngle < 30)
            {
                GCpfA = GT2 + (GT3 - GT2) * (RoofAngle - 20) / (30 - 20);
            }
            else if (RoofAngle >= 30 && RoofAngle <= 45)
            {
                GCpfA = GT3;
            }
            else if (RoofAngle > 45 && RoofAngle < 90)
            {
                GCpfA = GT2 + (GT4 - GT3) * (RoofAngle - 45) / (90 - 45);
            }
            else
            {
                GCpfA = GT4;
            }

            return GCpfA;

        }
        public double GetGCpfBRatio(string StandardDesign, double RoofAngle, int Zone)
        {
            if (StandardDesign == "ASCE 7-05")
            {
                ASCE7_05 aSCE7_05 = new ASCE7_05();
                double GT1 = aSCE7_05.figure6_10[0, Zone - 1];
                double GT2 = aSCE7_05.figure6_10[1, Zone - 1];
                double GT3 = aSCE7_05.figure6_10[2, Zone - 1];
                double GT4 = aSCE7_05.figure6_10[3, Zone - 1];

                if (RoofAngle <= 5)
                {
                    GCpfB = GT1;
                }
                else if (RoofAngle > 5 && RoofAngle < 20)
                {
                    GCpfB = GT1 + (GT2 - GT1) * (RoofAngle - 5) / (20 - 5);
                }
                else if (RoofAngle == 20)
                {
                    GCpfB = GT2;
                }
                else if (RoofAngle > 20 && RoofAngle < 30)
                {
                    GCpfB = GT2 + (GT3 - GT2) * (RoofAngle - 20) / (30 - 20);
                }
                else if (RoofAngle >= 30 && RoofAngle <= 45)
                {
                    GCpfB = GT3;
                }
                else if (RoofAngle > 45 && RoofAngle < 90)
                {
                    GCpfB = GT2 + (GT4 - GT3) * (RoofAngle - 45) / (90 - 45);
                }
                else
                {
                    GCpfB = GT4;
                }
            }
            else if(StandardDesign == "ASCE 7-10")
            {
                ASCE7_10 aSCE7_10 = new ASCE7_10();
                GCpfB = aSCE7_10.figure28_4_1_LCB[Zone - 1];
            }

            return GCpfB;
        }
    }
}
