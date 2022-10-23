using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPPusherOmiDLL
{
    public class UDPPusher
    {
        UDPTarget m_target;
        IPEndPoint m_destinationEndPoint;
        Socket m_destinationSock;


        public UDPTarget GetCurrentTarget() { return m_target; }

        public UDPPusher()
        {
            m_target = new UDPTarget();
            SetWith(m_target);
        }
        public UDPPusher(string adddres, int port)
        {
            m_target = new UDPTarget();
            m_target.SetWith(adddres, port);
            SetWith(m_target);
        }


        public void SetWith(in string address, int port) {
            m_target.SetWith(address, port);
            SetWith(m_target);
        
        }
        public void SetWith(UDPTarget target) {

            m_target = target;
            m_destinationSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress serverAddr = IPAddress.Parse(m_target.m_ipAddress);
            m_destinationEndPoint = new IPEndPoint(serverAddr, m_target.m_ipPort);
        }

        public void SendMessageWithUDP(string message)
        {
            m_destinationSock.SendTo(Encoding.Unicode.GetBytes(message), m_destinationEndPoint);
        }
       
    }
}
