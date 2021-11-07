using System.Runtime.Serialization;

namespace WcfDomino
{
    [DataContract]
    public class Player
    {
        private string userName;
        private string idPlayer;
        private string name;
        private string password;
        private string email;

        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        [DataMember]
        public string IdPlayer
        {
            get { return idPlayer; }
            set { idPlayer = value; }
        }
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}