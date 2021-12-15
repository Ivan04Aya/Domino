using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;

namespace WcfDomino
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        private List<Player> conectedUsers = new List<Player>();
        private List<string> players = new List<string>();
        private Dictionary<string, List<Message>> incomingMessages = new Dictionary<string, List<Message>>();
        public List<string> displayPlayers()
        {
            return players;
        }

        public Player playerConnect(string user)
        {
            Player player = new Player() { userName = user };
            var exist = from Player e in this.conectedUsers where e.userName == player.userName select e;
            if (exist.Count() == 0)
            {
                this.conectedUsers.Add(player);
                incomingMessages.Add(player.userName, new List<Message>(){
                    new Message() {User = player,MessageChat= "Welcome to Kurumino chat ",Date=DateTime.Now}
                });
                players.Add(user);
            }
            else
            {
                player = null;
            }
            return player;
        }


        public List<Message> receiveMessage(Player player)
        {
            List<Message> messages = incomingMessages[player.userName];
            incomingMessages[player.userName] = new List<Message>();
            if (messages.Count <= 0)
            {
                messages = null;
            }
            return messages;
        }

        public void removeUser(Player player)
        {
            players.Remove(player.userName);
        }


        public void sendMessage(Message message)
        {
            Console.WriteLine(message.User.userName + "   says : " + message.MessageChat + " at " + message.Date);
            foreach (var user in this.conectedUsers)
            {
                if (!message.User.userName.Equals(user.userName))
                {
                    incomingMessages[user.userName].Add(message);
                }
            }
        }

        public void sendMessagePrivate(Message message, string user)
        {
            if (!message.User.userName.Equals(user))
            {
                incomingMessages[user].Add(message);
            }
        }

        public Boolean RecordPlayer(string name, string userName, string email, string password)
        {
            Boolean result = false;
            try
            {
                using (var context = new KuruminoEntities())
                {
                    Player player = new Player
                    {
                        name = name,
                        userName = userName,
                        email = email,
                        password = Compute5HA256Hash(password)
                    };
                    context.Player.Add(player);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public string Compute5HA256Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
