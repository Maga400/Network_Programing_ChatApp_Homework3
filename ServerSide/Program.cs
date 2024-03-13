using ServerSide;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;

IPAddress ip = IPAddress.Parse("127.0.0.1");
int port = 27002;
IPEndPoint listenerEP = new IPEndPoint(ip, port);

using TcpListener listener = new TcpListener(listenerEP);

listener.Start();

Console.WriteLine(listener.LocalEndpoint + " Server Started ...");
List<TcpClient> clients = new List<TcpClient>();

while (true)
{
    var client = listener.AcceptTcpClient();
    Console.Write(client.Client.RemoteEndPoint + " ");
    clients.Add(client);
    NetworkStream clientStreamm = client.GetStream();
    BinaryReader reader = new BinaryReader(clientStreamm);
    Console.WriteLine(reader.ReadString() + " Connected ...");
    //var user = new User(readerr.ReadString(), client);
    //Clients.Users?.Add(user);


    //Thread.Sleep(1000);
    Task a = new Task(() =>
    {

        while (true)
        {

            BinaryReader reader = new BinaryReader(clientStreamm);
            string readerString = reader.ReadString();
            string name = readerString.Split(":")[0];
            string name2 = readerString.Split(":")[1];
            string name3 = readerString.Split(":")[2];
            
            Console.WriteLine(name + " - den : " + name2 + " - e olan Message: " + name3);

            //foreach (var item in clients)
            //{
            //    NetworkStream clientStream2 = item.GetStream();
            //    BinaryReader reader2 = new BinaryReader(clientStream2);
            //    BinaryWriter writer2 = new BinaryWriter(clientStream2);
            //    //string readerString2 = reader2.ReadString();
            //    string name4 = reader2.ReadString().Split(":")[1];
            //    string message = reader2.ReadString().Split(":")[2];

            //    Console.WriteLine(name4);
            //    //writer2.Write("Her kese salam");

            //    if (name4 == name2)
            //    {

            //        writer2.Write(name4 + " - den size gelen Message: " + message);
                   
            //    }

            //}
        }
    });
    a.Start();
}

