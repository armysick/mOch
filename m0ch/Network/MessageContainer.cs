using m0ch.Utils;

namespace m0ch.Network
{
    
    /// <summary>
    /// Class responsible for storing not just the message but other atributes needed for a better server management.
    /// </summary>
    public class MessageContainer
    {
        
        /// <summary>
        /// Stored Message.
        /// </summary>
        private Message message;

        /// <summary>
        /// Number of failed attempts.
        /// </summary>
        private int sendAttempts;


        /// <summary>
        /// Creates a new MessageContainer object.
        /// </summary>
        /// <param name="message">Message</param>
        public MessageContainer(Message message)
        {
            this.message = message;
            this.sendAttempts = 0;
        }

        /// <summary>
        /// Method to be used in order to access to the message object.
        /// </summary>
        /// <returns></returns>
        public Message GetMessage()
        {
            return this.message;
        }

        /// <summary>
        /// Method to be used in order to retrieve the send attemps
        /// </summary>
        /// <returns></returns>
        public int GetSendAttemps()
        {
            return this.sendAttempts;
        }
        
        
    }
}