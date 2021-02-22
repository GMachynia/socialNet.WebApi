using System;
using System.Collections.Generic;
using System.Text;

namespace socialNet.Data.Models
{
    public class Message
    {
        public Message()
        {
            SendDateTime = new DateTime();
        }

        public int MessageId { get; set; }
        public string Content { get; set; }
        public DateTime SendDateTime { get; set; }
        public virtual User Sender { get; set; }
        public int  SenderId {get; set; }
        public virtual User Recipient { get; set; }
        public int RecipientId { get; set; }
        public bool MessageStatus { get; set; }

    }
}
