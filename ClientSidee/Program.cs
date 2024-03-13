using System.Net.Sockets;
using System.Net;

TcpClient client = new TcpClient();

IPAddress ip = IPAddress.Parse("127.0.0.1");
int port = 27002;
IPEndPoint clientEP = new IPEndPoint(ip, port);

client.Connect(clientEP);

NetworkStream clientStream = client.GetStream();
BinaryWriter writer = new BinaryWriter(clientStream);
Console.WriteLine("Adinizi daxil edin: ");
string name = Console.ReadLine();
writer.Write(name);


while (true)
{
    Console.WriteLine("Kime messagene gondereceksizse onun adin daxil edin");
    string recepient = Console.ReadLine();
    Console.WriteLine("Messageni daxil edin");
    string message = Console.ReadLine();


    string Message = name + ":" + recepient + ":" + message + ":";


    writer.Write(Message);

    Task a = new Task(() =>
    {
        while (true)
        {
            BinaryReader reader = new BinaryReader(clientStream);
            Console.WriteLine(reader.ReadString());
        }

    });

    a.Start();

}






