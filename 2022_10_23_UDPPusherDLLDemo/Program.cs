using System;
using System.Collections.Generic;
using System.Threading;
using UDPPusherDLL;

namespace UDPPusherOmiDLLDemo
{
    class Program
    {
        public static int m_defaultPort = UDPPusherDefault.m_defaultIpPort;
        public static string m_defaultAddress = UDPPusherDefault.m_defaultIpAddress;
        public static bool m_keepAlive=true;
        public static DefaultCommandLineUdpServer m_server;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            UDPPusher pusherOn = new UDPPusher();
            (new Thread(new ThreadStart(() => SenderPush(500, "A")))).Start();
            (new Thread(new ThreadStart(() => SenderPush(1000, "B")))).Start();
            (new Thread(new ThreadStart(() => SenderPush(2000, "C")))).Start();
            (new Thread(new ThreadStart(() => ListenToMessage(10)))).Start();
        }
        ~Program() {
            m_keepAlive = false;
        }

        private static void SenderPush(int milliSeconds, string id)
        {
            UDPPusher pusherOn = new UDPPusher(m_defaultAddress, m_defaultPort);
            while (m_keepAlive)
            {
                pusherOn.SendMessageWithUDP(id + ":" + DateTime.Now.ToString());
                Thread.Sleep(milliSeconds);
            }
        }
        private static void ListenToMessage(int milliSeconds)
        {
            try
            {
                m_server = new DefaultCommandLineUdpServer();
                List<string> m_messageReceived = new List<string>();
                while (m_keepAlive)
                {
                    m_server.FlushReceivedMessagesInRef(ref m_messageReceived);
                    foreach (var item in m_messageReceived)
                    {
                        Console.WriteLine(item);
                    }
                    m_messageReceived.Clear();
                    Thread.Sleep(milliSeconds);
                }
            }
            catch (Exception ) {
                Console.Write("E:Server not.");
            
            }
        }
    }
}
