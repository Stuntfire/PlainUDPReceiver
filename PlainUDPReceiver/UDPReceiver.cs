using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PlainUDPReceiver
{
    public class UDPReceiver
    {
        public UDPReceiver()
        {
            
        }


        private int Port = 11001;

        public void Start()
        {
            UdpClient receiverClient = new UdpClient(Port);

            IPEndPoint sendersEndPoint = new IPEndPoint(IPAddress.Any, Port);

            byte[] recievedBytes = receiverClient.Receive(ref sendersEndPoint);

            Console.WriteLine($"Afsenders adr : {sendersEndPoint.Address} og port : {sendersEndPoint.Port}");

            String recievedString = Encoding.ASCII.GetString(recievedBytes);
            Console.WriteLine(recievedString);
        }
    }
}
