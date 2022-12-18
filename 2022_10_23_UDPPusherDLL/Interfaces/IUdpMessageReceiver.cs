using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPPusherDLL
{
    public interface IUdpMessageReceiver
    {
         void FlushReceivedMessages(out List<string> messagesReceived);
         void FlushReceivedMessagesInRef(ref List<string> messagesReceived);
         void KillAndDisposeTheThread();
    }
}
