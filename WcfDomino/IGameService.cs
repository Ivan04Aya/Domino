using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfDomino
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IGameService
    {
        [OperationContract]
        void startGame(Game game);

        [OperationContract]
        Boolean playerConnectGame(Game game, Player playerOne, Player playerTwo);

        [OperationContract]
        List<string> displayGames();

        [OperationContract]
        string endGame();
    }
}
