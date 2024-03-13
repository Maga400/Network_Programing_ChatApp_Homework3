using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide;

public class User
{
    public string? UserName { get; set; }
    public TcpClient? UserTcpClient {  get; set; }
    public User() 
    {  

    }
    public User(string? userName, TcpClient? userTcpClient)
    {
        UserName = userName;
        UserTcpClient = userTcpClient;
    }
}
