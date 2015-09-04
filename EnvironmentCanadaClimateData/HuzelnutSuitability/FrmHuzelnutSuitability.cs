﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DotSpatial.Data;

namespace HAWKLORRY.HuzelnutSuitability
{
    public partial class FrmHuzelnutSuitability : Form
    {
        public FrmHuzelnutSuitability()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HuzelnutSuitabilityProject project = new HuzelnutSuitabilityProject(
                @"D:\Michael\git\fromwanhongreneedyourhelpwithprogrammingforclimate\County_Southern_ONT.shp");

            List<ECStationInfo> stations = project.getStationsAvailableInYearRange(2000, 2014);
            for (int i = 0; i < stations.Count; i++)
            {
                ECStationInfo info = stations[i];
                System.Diagnostics.Debug.WriteLine(string.Format("\n#{0},{1}", i, info.Name));
                if (!info.IsAvailableForYear(2000, 2014))
                {
                    System.Diagnostics.Debug.Write("skip");
                    continue;
                }
                for (int year = 2000; year <= 2014; year++)
                {
                    System.Diagnostics.Debug.Write(year);
                    if (!info.IsAvailableForYear(year))
                    {
                        System.Diagnostics.Debug.Write(",skip");
                        continue;
                    }
                    System.Diagnostics.Debug.Write(",");
                    info.getTemperatureForOneYear(year);
                }
            }
        }

        private void FrmHuzelnutSuitability_Load(object sender, EventArgs e)
        {

        }
    }
}
