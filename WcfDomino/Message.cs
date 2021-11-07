using System;
using System.Runtime.Serialization;

namespace WcfDomino
{
    [DataContract]
    public class Message
    {
        private string message;
        private Player player;
        private DateTime date;

        [DataMember]
        public Player user
        {
            get { return player; }
            set { player = value; }
        }
        [DataMember]
        public string MessageChat
        {
            get { return message; }
            set { message = value; }
        }
        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}