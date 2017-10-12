using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using ModelLib;

namespace JsonUDPReceiver
{
    public class JsonReceiver
    {
        private int Port = 10003;

        public void Start()
        {
            Console.WriteLine("Afventer en JSON-Car ... \n");
            while (true)
            {
                using (UdpClient client = new UdpClient(Port))
                {
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, Port);

                    try
                    {
                        byte[] receivedDataGram = client.Receive(ref endPoint);

                        String receivedData = Encoding.ASCII.GetString(receivedDataGram);

                        Console.WriteLine($"ASCII-versionen af det modtaget datagram: \n{receivedData}");

                        Car jsonCar = JsonConvert.DeserializeObject<Car>(receivedData);

                        Console.WriteLine($"\nDeserialisering af ASCII-string til et Car-object: \n{jsonCar}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
        }
    }
}
