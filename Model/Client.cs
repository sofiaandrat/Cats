using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkCommsDotNet;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Model
{
    public class Client:IClient
    {
        static int port = 8005; // порт сервера
        static string address = "127.0.0.1"; // адрес сервера
        Socket socket;
        public Client()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public int AskTime()
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            try
            {
                socket.Connect(ipPoint);
                byte[] data = Encoding.Unicode.GetBytes("Time");
                SendMessage(data);
                return Convert.ToInt32(TakeMessage());
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public void EstablishTime(int speed)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            
            try
            {
                socket.Connect(ipPoint);
                byte[] data = Encoding.Unicode.GetBytes("SpeedOfTime");
                SendMessage(data);
                Thread.Sleep(300);
                data = Encoding.Unicode.GetBytes(speed.ToString());
                SendMessage(data);
            }
            catch (Exception)
            {
                return ;
            }
        }

        private void SendMessage (byte[] data)
        {
            socket.Send(data);
        }

        private string TakeMessage ()
        {
           byte [] data = new byte[256];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            if (builder.Length != 0)
                return builder.ToString();
            else
                return "";
        }
    }
            
} 
