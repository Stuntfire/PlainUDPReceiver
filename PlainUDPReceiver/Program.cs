﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainUDPReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPReceiver udp = new UDPReceiver();
            udp.Start();
        }
    }
}
