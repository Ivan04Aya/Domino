using System;
using System.Collections.Generic;
using System.ServiceModel;

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
        string endGame(string resultGame);
    }
}
