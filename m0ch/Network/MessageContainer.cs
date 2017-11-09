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
        private readonly Message _message;

        /// <summary>
        /// Number of failed attempts.
        /// </summary>
        private int _sendAttempts;


        /// <summary>
        /// Creates a new MessageContainer object.
        /// </summary>
        /// <param name="message">Message</param>
        public MessageContainer(Message message)
        {
            this._message = message;
            this._sendAttempts = 0;
        }

        /// <summary>
        /// Method to be used in order to access to the message object.
        /// </summary>
        /// <returns></returns>
        public Message GetMessage()
        {
            return this._message;
        }

        /// <summary>
        /// Method to be used in order to retrieve the send attemps
        /// </summary>
        /// <returns></returns>
        public int GetSendAttemps()
        {
            return this._sendAttempts;
        }

        /// <summary>
        /// Increases the send attempts of this particular message.
        /// </summary>
        public void IncreaseNumberofAttempts()
        {
            this._sendAttempts++;
        }
        
    }
}