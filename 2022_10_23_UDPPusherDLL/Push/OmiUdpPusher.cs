namespace UDPPusherOmiDLL
{
    /// <summary>
    /// Allows to set the boolean name in OMI application by using UDP message.
    /// </summary>
    public class OmiUdpPusher : IUdpMessagePusher {
        public UDPPusher m_commandPusher = new UDPPusher();
        public OmiUdpPusher(in string address, in int port) { SetWith(address, port); }
        public OmiUdpPusher(in UDPTargetParams target) { SetWith(target); }
        public void SetWith(in string address, in int port) { m_commandPusher.SetWith(new UDPTargetParams( address, port)); }
        public void SetWith(in UDPTargetParams target) { m_commandPusher.SetWith(target); }

        public void PushCommandLine(string commandLine) {
            m_commandPusher.SendMessageWithUDP(commandLine);
        }
        public void PushCommandLine_SetBoolean(string booleanName, bool isTrueValue)
        {
            string commandLine = "Ḇ" + (isTrueValue ? 1 : 0) + booleanName;
            m_commandPusher.SendMessageWithUDP(commandLine);
        }
        public void PushCommandLine_SwitchBoolean(string booleanName)
        {
            string commandLine = "Ḇ↕"+ booleanName;
            m_commandPusher.SendMessageWithUDP(commandLine);
        }
    }
}
