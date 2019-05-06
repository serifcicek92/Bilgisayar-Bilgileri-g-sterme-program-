﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;

namespace DesktopApp1
{
    public class HardDrive
    {
        public string Model { get; set; }
        public string InterfaceType { get; set; }
        public string Caption { get; set; }
        public string SerialNo { get; set; }
        private void HDD()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                HardDrive hd = new HardDrive();
                hd.Model = wmi_HD["Model"].ToString();
                hd.InterfaceType = wmi_HD["InterfaceType"].ToString();
                hd.Caption = wmi_HD["Caption"].ToString();
                hd.SerialNo = wmi_HD.GetPropertyValue("SerialNumber").ToString();//get the serailNumber of diskdrive
                string hdd_id = hd.SerialNo;
                //labelControl5.Text = hdd_id;
            }

        }
    }

}
