using System;
using System.ServiceModel;

namespace WcfDomino
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IPlayerService
    {
        [OperationContract]
        Boolean RecordPlayer(string name, string userName, string email, string password);

        [OperationContract]
        int SendMail(string email);
    }
}
