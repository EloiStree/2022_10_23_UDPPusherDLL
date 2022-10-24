using System.Collections.Generic;
using System.Threading;

namespace UDPPusherOmiDLL
{
    /// <summary>
    /// Allows to create quickly a small omi server if you need demo or default version. (Don't mean that the application will use it in the end).
    /// </summary>
    public class DefaultCommandLineUdpServer : IUdpMessageReceiver {

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

        public void KillAndDisposeTheThread()
        {
            m_messageHolder.FlushReceivedMessages(out List<string> l);
            m_udpThreadListener.Kill();
        }

        ~DefaultCommandLineUdpServer() {
            m_udpThreadListener.RemoveListener(m_messageHolder.AddMessageReceived); 
        }

    }
}
