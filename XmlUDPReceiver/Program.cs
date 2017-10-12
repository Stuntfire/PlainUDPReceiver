using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlUDPReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlUDPReceiver xmlUdpReceiver = new XmlUDPReceiver();
            xmlUdpReceiver.Start();
        }
    }
}
