using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfDomino
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    interface IPlayerService
    {
        [OperationContract]
        Boolean recordPlayer(Player player);

        [OperationContract]
        Boolean sendMail(string email);

        [OperationContract]
        History consultHistory(string name);
    }
}
