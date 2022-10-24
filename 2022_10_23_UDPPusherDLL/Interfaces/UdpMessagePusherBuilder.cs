using System.Threading;

namespace UDPPusherOmiDLL
{
    public class UdpMessagePusherBuilder {

        public static void ConnectWithDefault(out IUdpMessagePusher pusher)
        {
            pusher = new OmiUdpPusher(UDPPusherDefault.m_defaultIpAddress, UDPPusherDefault.m_defaultIpPort);
        }
        public static void Connect(in string address, in int port, out IUdpMessagePusher pusher)
        {
            pusher = new OmiUdpPusher(address, port);
        }
        public static void Connect(in UDPTargetParams target, out IUdpMessagePusher pusher)
        {
            pusher = new OmiUdpPusher(target);
        }

        public static void CreateServer(ThreadPriority thread, int serverPort, out IUdpMessageReceiver server)
        {
            server = new DefaultCommandLineUdpServer(thread, serverPort);
        }
        public static void CreateDefaultServer(ThreadPriority thread, out IUdpMessageReceiver server)
        {
            server = new DefaultCommandLineUdpServer(thread, UDPPusherDefault.m_defaultIpPort);
        }
        public static void CreateDefaultServer( out IUdpMessageReceiver server)
        {
            server = new DefaultCommandLineUdpServer(ThreadPriority.Normal, UDPPusherDefault.m_defaultIpPort);
        }
    }
}
