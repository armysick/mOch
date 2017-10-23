using System;
using m0ch.FIPA;

namespace m0ch.Utils
{
    // Represents all performative given by FIPA
    public enum Perfomative
    {
        ACCEPTPROPOSAL,
        AGREE,
        CANCEL,
        CALLFORPROPOSAL,
        CONFIRM,
        DISCONFIRM,
        FAILURE,
        INFORM,
        INFORMIF,
        INFORMREF,
        NOTUNDERSTOOD,
        PROPAGATE,
        PROPOSE,
        PROXY,
        QUERYIF,
        QUERYREF,
        REFUSE,
        REJECTPROPOSAL,
        REQUEST,
        REQUESTWHEN,
        REQUESTWHENEVER,
        SUBSCRIBE
    };

    // Defining all Ontologies defined by this agent
    public enum Ontology
    {
      DEFAULT
    }

    // Defining all protocols definied by this agent
    public enum Protocol
    {
        DEFAULT
    }

    // Represents the Message exchanged between agents accordint to FIPA 
    // compliant
    public class Message
    {
        // FIPA standart format for messages
        private Perfomative performative;
        private AID sender, receiver, replyTo;
        private string content;
        private string language;
        private string encoding;
        private Ontology ontology;
        private Protocol protocol;
        private string conversationID;
        private string replyWith;
        private string inReplyTo;
        private string replyBy;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.Utils.Message"/> class.
        /// </summary>
        /// <param name="perf">Perf.</param>
        public Message(Perfomative perf)
        {
            this.performative = perf;

        }

        /// <summary>
        /// Fills the envelope's message.
        /// Use in case of reply-to is equals to sender's AID. 
        /// </summary>
        /// <param name="senderAID">Sender's AID</param>
        /// <param name="receiverAID">Receiver's AID.</param>
        public void addEnvelope(AID senderAID, AID receiverAID){
            this.sender = senderAID;
            this.receiver = receiverAID;
            this.replyTo = senderAID;
        }

        /// <summary>
        /// Fills the envelope's message.
        /// Use in case of reply-to is not equals to sender's AID.
        /// </summary>
        /// <param name="senderAID">Sender's AID</param>
        /// <param name="receiverAID">Receiver's AID</param>
        /// <param name="replyToAID">Reply to's AID</param>
        public void addEnvelope(AID senderAID, AID receiverAID, AID replyToAID){
            this.sender = senderAID;
            this.receiver = receiverAID;
            this.replyTo = replyToAID;
        }

        /// <summary>
        /// Adds the content and its description to the message
        /// </summary>
        /// <param name="content">Content</param>
        /// <param name="language">Language</param>
        /// <param name="encoding">Encoding</param>
        /// <param name="ontology">Ontology</param>
        public void addContent(string content, string language, string encoding,
                            Ontology ontology)
        {
            this.content = content;
            this.language = language;
            this.encoding = encoding;
            this.ontology = ontology;
        }

        /// <summary>
        /// Adds the conversation control to the message
        /// </summary>
        /// <param name="protocol">Protocol in use</param>
        /// <param name="conversationIdentifier">Conversation identifier</param>
        /// <param name="replyWith">Reply with</param>
        /// <param name="inReplyTo">In reply to</param>
        /// <param name="replyBy">Reply by</param>
        public void addConversationControl(Protocol protocol,
                                           string conversationIdentifier,
                                          string replyWith, string inReplyTo, 
                                           string replyBy)
        {
            this.protocol = protocol;
            this.conversationID = conversationIdentifier;
            this.replyWith = replyWith;
            this.inReplyTo = inReplyTo;
            this.replyBy = replyBy;
        }
    }



}
