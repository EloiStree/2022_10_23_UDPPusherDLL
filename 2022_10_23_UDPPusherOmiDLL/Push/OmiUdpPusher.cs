namespace UDPPusherOmiDLL
{
    public class OmiUdpPusher {
        public UDPPusher m_commandPusher = new UDPPusher();
        public void SetWith(in string address, in int port) { m_commandPusher.SetWith(new UDPTarget( address, port)); }
        public void SetWith(in UDPTarget target) { m_commandPusher.SetWith(target); }
        public void PushCommandLine(string commandLine) {
            m_commandPusher.SendMessageWithUDP(commandLine);
        }
        public void PushCommandLine_SetBoolean(string booleanName, bool isTrueValue)
        {
            string commandLine = "Ḇ" + (isTrueValue ? 1 : 0) + booleanName;
            m_commandPusher.SendMessageWithUDP(commandLine);
        }
        public void PushCommandLine_SwitchBoolean(string booleanName, bool isTrueValue)
        {
            string commandLine = "Ḇ↕"+ booleanName;
            m_commandPusher.SendMessageWithUDP(commandLine);
        }

    }
}
