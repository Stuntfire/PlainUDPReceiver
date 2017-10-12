using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ModelLib;

namespace XmlUDPReceiver
{
    class XmlUDPReceiver
    {
        private int Port = 10002;

        public void Start()
        {
            Console.WriteLine("Afventer en XML-Car ... \n");

            using (UdpClient receiverClient = new UdpClient(Port))
            {
                IPEndPoint sendersEndPoint = new IPEndPoint(IPAddress.Any, Port);

                try
                {
                    byte[] datagramReceived = receiverClient.Receive(ref sendersEndPoint);

                    Console.WriteLine($"--------------------------------------------------\nAfsenders IP-adresse: {sendersEndPoint.Address} og port nr.: {sendersEndPoint.Port} \n--------------------------------------------------");

                    String str = Encoding.ASCII.GetString(datagramReceived);

                    Console.WriteLine($"\n--------------------------------------------------\nModtaget følgende string fra afsender: \n\n{str} \n--------------------------------------------------");

                    StringReader stringReader = new StringReader(str);

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Car));

                    Car newCar = (Car)xmlSerializer.Deserialize(stringReader);

                    Console.WriteLine($"\n--------------------------------------------------\nXML-deseralisering af ovenstående string \ntilbage til et Car-objekt giver: \n\n{newCar} \n--------------------------------------------------");

                    //Console.WriteLine($"Afsenders adr : {sendersEndPoint.Address} og port : {sendersEndPoint.Port}");

                    //String recievedString = Encoding.ASCII.GetString(recievedBytes);
                    //Console.WriteLine(recievedString);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
