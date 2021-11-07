using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

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
            Player player = new Player () { UserName = user };
            var exist = from Player e in this.conectedUsers where e.UserName == player.UserName select e;
            if (exist.Count() == 0)
            {
                this.conectedUsers.Add(player);
                incomingMessages.Add(player.UserName, new List<Message>(){
                    new Message() {user = player,MessageChat= "Welcome to Kurumino chat ",Date=DateTime.Now}
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
            List<Message> messages = incomingMessages[player.UserName];
            incomingMessages[player.UserName] = new List<Message>();
            if (messages.Count <= 0)
            {
                messages=null;
            }
            return messages;
        }

        public void removeUser(Player player)
        {
            players.Remove(player.UserName);
        }


        public void sendMessage(Message message)
        {
            Console.WriteLine(message.user.UserName + "   says : " + message.MessageChat + " at " + message.Date);
            foreach (var user in this.conectedUsers)
            {
                if (!message.user.UserName.Equals(user.UserName))
                {
                    incomingMessages[user.UserName].Add(message);
                }
            }
        }

        public void sendMessagePrivate(Message message, string user)
        {
            if (!message.user.UserName.Equals(user))
            {
                incomingMessages[user].Add(message);
            }
        }
    }
}
