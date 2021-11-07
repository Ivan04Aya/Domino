using System;
using System.Runtime.Serialization;

namespace WcfDomino
{
    [DataContract]
    public class Game
    {
        private string userOne;
        private string userTwo;
        private string idGame;
        private string result;
        private string status;
        private DateTime dateGame;

        [DataMember]
        public string UserOne
        { 
            get { return userOne; }
            set {userOne = value; }
        }
        [DataMember]
        public string UserTwo
        {
            get { return userTwo; }
            set { userTwo = value; }
        }
        [DataMember]
        public string IdGame
        {
            get { return idGame; }
            set { idGame = value; }
        }
        [DataMember]
        public string Result
        {
            get { return result; }
            set { result = value; }
        }
        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public DateTime DateGame
        {
            get { return dateGame; }
            set { dateGame = value; }
        }
    }
}
