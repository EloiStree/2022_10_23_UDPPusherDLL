using System.Collections.Generic;

namespace UDPPusherDLL
{

    /// <summary>
    /// When you do multithreading application you need a temp queue to avoid conflict between the thread that received and the thread that process the message received.
    /// </summary>
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
