using System.Collections.Generic;
using System.Threading;

namespace UDPPusherOmiDLL
{
    /// <summary>
    /// Will create a thread 
    /// </summary>
    public class DefaultCommandLineUdpServer {

        ThreadReceivedMessageQueue m_messageHolder;
        UDPListenerThread m_udpThreadListener;

        public DefaultCommandLineUdpServer(ThreadPriority priorityThread, int port)
        {
            m_udpThreadListener = new UDPListenerThread(priorityThread, port);
            m_messageHolder = new ThreadReceivedMessageQueue();
            m_udpThreadListener.AddListener(m_messageHolder.AddMessageReceived);

        }
        public DefaultCommandLineUdpServer()
        {
            m_udpThreadListener = new UDPListenerThread(ThreadPriority.Normal, UDPPusherDefault.m_defaultIpPort);
            m_messageHolder = new ThreadReceivedMessageQueue();
            m_udpThreadListener.AddListener(m_messageHolder.AddMessageReceived);

        }
        public void FlushReceivedMessages(out List<string> list)
        {
            m_messageHolder.FlushReceivedMessages(out list);
        }
        public void FlushReceivedMessagesInRef(ref List<string> list)
        {
            m_messageHolder.FlushReceivedMessagesInRef(ref list);
        }

        ~DefaultCommandLineUdpServer() {
            m_udpThreadListener.RemoveListener(m_messageHolder.AddMessageReceived); 
        }

      

    }
}
