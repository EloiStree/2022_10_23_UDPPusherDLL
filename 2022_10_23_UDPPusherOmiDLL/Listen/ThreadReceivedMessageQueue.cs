using System.Collections.Generic;

namespace UDPPusherOmiDLL
{
    [System.Serializable]
    public class ThreadReceivedMessageQueue {


        Queue<string> m_receivedQueueMessage = new Queue<string>();
        public void AddMessageReceived(in string messageReceived)
        {
            m_receivedQueueMessage.Enqueue(messageReceived);
        }
        public void AddMessageReceived( string messageReceived)
        {
            m_receivedQueueMessage.Enqueue(messageReceived);
        }

        public void FlushReceivedMessages(out List<string> fifoList)
        {
            fifoList = new List<string>();
            while (m_receivedQueueMessage.Count > 0)
                fifoList.Insert(0, m_receivedQueueMessage.Dequeue());
        }
        public void FlushReceivedMessagesInRef(ref List<string> fifoList)
        {
            if (fifoList == null)
                fifoList = new List<string>();
            while (m_receivedQueueMessage.Count > 0)
                fifoList.Insert(0, m_receivedQueueMessage.Dequeue());
        }
    }
}
