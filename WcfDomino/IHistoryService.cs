using System.ServiceModel;

namespace WcfDomino
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IHistoryService
    {
        [OperationContract]
        History ConsultHistory(string name);
    }
}
