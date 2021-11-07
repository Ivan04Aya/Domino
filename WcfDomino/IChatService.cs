using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfDomino
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IChatService
    {
        [OperationContract]
        Player playerConnect(string player);

        [OperationContract]
        void removeUser(Player player);

        [OperationContract]
        List<Message> receiveMessage(Player player);
        [OperationContract]
        void sendMessage(Message message);
        [OperationContract]
        void sendMessagePrivate(Message message,string user);
        [OperationContract]
        List<string> displayPlayers();
    }
}
