using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPPusherOmiDLL
{
    /// <summary>
    /// This class is just a quick UDP server in case you need a demo of default for your application.
    /// </summary>
    public class UDPListenerThread
    {
        public bool m_threadMustDie=false;
        public int m_portObserved=UDPPusherDefault.m_defaultIpPort;
        public bool m_isRunning;

        UnicodeTextReceived m_onTextReceived;
        public delegate void UnicodeTextReceived(in string unicodeText);
        public void AddListener(UnicodeTextReceived listener)
        {
            m_onTextReceived += listener;
        }
        public void RemoveListener(UnicodeTextReceived listener)
        {
            m_onTextReceived -= listener;

        }
        public UDPListenerThread(ThreadPriority priority): this( priority, UDPPusherDefault.m_defaultIpPort)
        {
        }
        public UDPListenerThread(ThreadPriority priority, int portObserved)
        {
            this.m_portObserved = portObserved;
            Thread t = new Thread(StartThreadLoopListener);
            t.Priority = priority;
            t.Start();
        }


        ~UDPListenerThread() {
            Kill();
        }

        public void Kill() {
            m_threadMustDie = true;
            m_isRunning = false;
        }
       

        public void StartThreadLoopListener()
        {
            try
            {
                UdpClient udpServer = new UdpClient(m_portObserved);
                m_isRunning = true;
                while (!m_threadMustDie)
                {
                    var remoteEP = new IPEndPoint(IPAddress.Any, m_portObserved);
                    var data = udpServer.Receive(ref remoteEP);
                    string text = Encoding.Unicode.GetString(data);
                    if (m_onTextReceived != null)
                        m_onTextReceived(in text);
                    Thread.Sleep(1);
                    //
                    //Console.Write("receive data from " + remoteEP.ToString());
                    //udpServer.Send(new byte[] { 1 }, 1, remoteEP); // reply back
                }
            }
            catch (Exception) {
                m_isRunning = false;
            }
        }

       
    }
}
