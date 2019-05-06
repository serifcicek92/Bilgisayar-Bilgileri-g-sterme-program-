using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesktopApp1
{
    class CPU
    {
        public string LblCpuSayisi()
        {

            string lblcpusayisi = System.Environment.ProcessorCount.ToString();
            return lblcpusayisi;

        }
        public string LblCpuMarka() {
            RegistryKey Rkey1 = Registry.LocalMachine;
            Rkey1 = Rkey1.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
            //string MHz = Rkey1.GetValue("~GHz").ToString();
            //string ProcessorNameString = (string)Rkey1.GetValue("ProcessorNameString");
            string lblcpumarka;
            lblcpumarka = (string)Rkey1.GetValue("ProcessorNameString").ToString();
            lblcpumarka = lblcpumarka.ToString();
            return lblcpumarka;
        }
    }
}
