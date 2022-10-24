using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPPusherOmiDLL
{
    public interface IUdpMessagePusher
    {
        void PushCommandLine(string commandLine);
        void PushCommandLine_SetBoolean(string booleanName, bool isTrueValue);
        void PushCommandLine_SwitchBoolean(string booleanName);
    }
}
