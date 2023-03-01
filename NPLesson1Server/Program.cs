using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NPLesson1Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.IP);
            IPEndPoint point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80);

            socket.Bind(point);
            socket.Listen(1000);

            try 
            {
                while (true)
                { 
                    Socket listener = socket.Accept();
                    Console.WriteLine(listener.RemoteEndPoint.ToString());
                    listener.Send(Encoding.UTF8.GetBytes("Здравствуй, пользователь.\n"));
                    listener.Send(Encoding.UTF8.GetBytes("А у меня сейчас " + DateTime.Now.ToString()));
                    listener.Shutdown(SocketShutdown.Both);
                    listener.Close();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}