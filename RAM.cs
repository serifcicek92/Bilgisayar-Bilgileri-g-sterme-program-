using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Management;
using System.Management.Instrumentation;
using System.Windows.Forms;

namespace DesktopApp1
{
    class RAM
    {
        public string deger { get; set; }
        public  string RAMget()
        {
            ManagementObjectSearcher Search = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");

            foreach (ManagementObject Mobject in Search.Get())
            {
                double Ram_Bytes = (Convert.ToDouble(Mobject["TotalPhysicalMemory"]));
                double ramgb = Ram_Bytes / 1073741824;
                double islem = Math.Ceiling(ramgb);
                deger = islem.ToString() + " GB";
                return deger;
            }
            return null;
        }
    }
}
