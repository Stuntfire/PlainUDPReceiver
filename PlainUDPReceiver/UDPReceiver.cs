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
        private int Port = 11001;

        public void Start()
        {
            UdpClient receiverClient = new UdpClient(Port);

            IPEndPoint sendersEndPoint = new IPEndPoint(IPAddress.Any, Port);

            try
            {
                byte[] recievedBytes = receiverClient.Receive(ref sendersEndPoint);

                String recievedString = Encoding.ASCII.GetString(recievedBytes);

                Console.WriteLine($"Modtog: \n{recievedString} fra afsenders adr: \n{sendersEndPoint.Address} og port: \n{sendersEndPoint.Port}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
