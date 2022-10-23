namespace UDPPusherOmiDLL
{
    [System.Serializable]
    public class UDPTarget
    {
        public string   m_ipAddress = UDPPusherDefault.m_defaultIpAddress;
        public int      m_ipPort = UDPPusherDefault.m_defaultIpPort;
        public UDPTarget()
        {
            m_ipAddress = UDPPusherDefault.m_defaultIpAddress;
            m_ipPort = UDPPusherDefault.m_defaultIpPort;
        } 

        public UDPTarget(string ipAddress, int ipPort)
        {
            m_ipAddress = ipAddress;
            m_ipPort = ipPort;
        }

        public void SetAddress(string address) { m_ipAddress = address; }
        public void SetPort(int ipPort) { m_ipPort = ipPort; }
        public void SetWith(string address, int ipPort) { m_ipAddress = address; m_ipPort = ipPort; }
        public string GetAddress() { return m_ipAddress; }
        public int GetPort() { return m_ipPort; }
    }
}
