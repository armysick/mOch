using System;
using m0ch.FIPA;

namespace m0ch.Utils
{
    // Represents all performative given by FIPA
    public enum Perfomative
    {
        Acceptproposal,
        Agree,
        Cancel,
        Callforproposal,
        Confirm,
        Disconfirm,
        Failure,
        Inform,
        Informif,
        Informref,
        Notunderstood,
        Propagate,
        Propose,
        Proxy,
        Queryif,
        Queryref,
        Refuse,
        Rejectproposal,
        Request,
        Requestwhen,
        Requestwhenever,
        Subscribe
    };

    // Defining all Ontologies defined by this agent
    public enum Ontology
    {
      Default
    }

    // Defining all protocols definied by this agent
    public enum Protocol
    {
        Default
    }

    // Represents the Message exchanged between agents accordint to FIPA 
    // compliant
    public class Message
    {
        // FIPA standart format for messages
        private Perfomative _performative;
        private AID _sender, _receiver, _replyTo;
        private string _content;
        private string _language;
        private string _encoding;
        private Ontology _ontology;
        private Protocol _protocol;
        private string _conversationId;
        private string _replyWith;
        private string _inReplyTo;
        private string _replyBy;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.Utils.Message"/> class.
        /// </summary>
        /// <param name="perf">Perf.</param>
        public Message(Perfomative perf)
        {
            this._performative = perf;

        }

        /// <summary>
        /// Fills the envelope's message.
        /// Use in case of reply-to is equals to sender's AID. 
        /// </summary>
        /// <param name="senderAID">Sender's AID</param>
        /// <param name="receiverAID">Receiver's AID.</param>
        public void AddEnvelope(AID senderAID, AID receiverAID){
            this._sender = senderAID;
            this._receiver = receiverAID;
            this._replyTo = senderAID;
        }

        /// <summary>
        /// Fills the envelope's message.
        /// Use in case of reply-to is not equals to sender's AID.
        /// </summary>
        /// <param name="senderAID">Sender's AID</param>
        /// <param name="receiverAID">Receiver's AID</param>
        /// <param name="replyToAID">Reply to's AID</param>
        public void AddEnvelope(AID senderAID, AID receiverAID, AID replyToAID){
            this._sender = senderAID;
            this._receiver = receiverAID;
            this._replyTo = replyToAID;
        }

        /// <summary>
        /// Adds the content and its description to the message
        /// </summary>
        /// <param name="content">Content</param>
        /// <param name="language">Language</param>
        /// <param name="encoding">Encoding</param>
        /// <param name="ontology">Ontology</param>
        public void AddContent(string content, string language, string encoding,
                            Ontology ontology)
        {
            this._content = content;
            this._language = language;
            this._encoding = encoding;
            this._ontology = ontology;
        }

        /// <summary>
        /// Adds the conversation control to the message
        /// </summary>
        /// <param name="protocol">Protocol in use</param>
        /// <param name="conversationIdentifier">Conversation identifier</param>
        /// <param name="replyWith">Reply with</param>
        /// <param name="inReplyTo">In reply to</param>
        /// <param name="replyBy">Reply by</param>
        public void AddConversationControl(Protocol protocol,
                                           string conversationIdentifier,
                                          string replyWith, string inReplyTo, 
                                           string replyBy)
        {
            this._protocol = protocol;
            this._conversationId = conversationIdentifier;
            this._replyWith = replyWith;
            this._inReplyTo = inReplyTo;
            this._replyBy = replyBy;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:m0ch.Utils.Message"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:m0ch.Utils.Message"/>.</returns>
        public override string ToString()
        {
            return string.Format("[Message] {0} to {1}", this._sender.ToString(), 
                                 this._receiver.ToString());
        }
    }



}
