using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.Threading;

namespace TCPServer
{
    public class Client
    {
        static IPEndPoint ipe;//服务器地址 
        static Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建一个Socket
        static string IP = "None";
        static int Port = 0;
        static Thread Thread0 = new Thread(new ThreadStart(StartClient));
        public static bool StopGet = false;
        public static bool ClientRunning = false;

        public static void ConnectTo(string IPAddress0, int Port0)
        {
            StopGet = false;
            ClientRunning = true;
            IP = IPAddress0;
            Port = Port0;
            Thread0.IsBackground = true;
            Thread0.Start();
        }
        static void StartClient()
        {
            if (IP != "None" && Port != 0)
            {
                ipe = new IPEndPoint(IPAddress.Parse(IP), Port);//服务器地址 
            }
            ShowMessage.Message("尝试连接服务器......地址：" + ipe.Address.ToString() + ":" + ipe.Port);
            while (true)
            {
                try
                {
                    c.Connect(ipe);//连接到服务器
                    SendMessage("<ZhanLingSignIn> </ZhanLingSignIn>");
                    break;
                }
                catch { }
            }
            GetMessage();
        }

        public static void GetMessage()
        {
            while (true)
            {
                if (StopGet)
                {
                    break;
                }
                SendMessage("<KeepAlive> </KeepAlive>");
                try
                {
                    byte[] recvBytes = new byte[1024 * 4];
                    c.ReceiveTimeout = 6400;
                    int bytes = c.Receive(recvBytes);//从服务器接受信息，返回接收的数据长度
                    string recvStr = Encoding.UTF8.GetString(recvBytes, 0, bytes);
                    string Message = recvStr;
                    while (true)
                    {
                        MatchCollection Tag0 = Regex.Matches(Message, "[<][^>]+[>]");
                        if (Tag0.Count > 0)
                        {
                            String Tag = "";
                            foreach (Match M in Tag0)
                            {
                                Tag = M.ToString();
                                break;
                            }
                            Tag = Tag.Replace("<", "");
                            Tag = Tag.Replace(">", "");
                            MatchCollection Content0 = Regex.Matches(Message, "[<][^>]+[>][^<]{0,}[<][^>]+[>]");
                            String Content = "";
                            if (Content0.Count > 0)
                            {
                                foreach(Match M in Content0)
                                {
                                    Content = M.ToString();
                                    break;
                                }
                            }
                            if (Content == "")
                            {
                                break;
                            }
                            Message = Message.Replace(Content, "");
                            Content = Content.Replace("<" + Tag + ">", "");
                            Content = Content.Replace("</" + Tag + ">", "");
                            MessageCenter.NewMessage(Tag, Content);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch
                {

                }
            }
        }

        public static void SendMessage(string Message)
        {
            try
            {
                Message = MyRegex.MyOwnRegex.mRegex(Message);
                byte[] bs = Encoding.UTF8.GetBytes(Message);
                c.Send(bs);
            }
            catch { }
        }

        public static void CloseClient()
        {
            ClientRunning = false;
            StopGet = true;
            if (Thread0 != null)
            {
                Thread0.Abort();
            }
            c.Close();
            c = null;
            Console.Write("已断开至服务器的连接");
        }
    }
}