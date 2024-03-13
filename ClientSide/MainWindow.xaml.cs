using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientSide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TcpClient TcpClient { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            TcpClient = new TcpClient();
        }
        private void SendData(object sender, RoutedEventArgs e)
        {
            NetworkStream clientStream = TcpClient.GetStream();
            BinaryReader reader = new BinaryReader(clientStream);
            BinaryWriter writer = new BinaryWriter(clientStream);
            string Message = nameTextBox.Text + ":" + recepientNameTextBox.Text + ":" + messageTextBox.Text + ":";

            writer.Write(Message);


            MessageBox.Show(reader.ReadString());


        }

        private void SendName(object sender, RoutedEventArgs e)
        {


            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 27001;
            IPEndPoint clientEP = new IPEndPoint(ip, port);

            TcpClient.Connect(clientEP);
            NetworkStream clientStream = TcpClient.GetStream();
            BinaryWriter writer = new BinaryWriter(clientStream);
            writer.Write(nameTextBox.Text);



        }
    }
}