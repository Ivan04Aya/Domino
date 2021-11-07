using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfDomino
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class GameService : IGameService
    {
        private List<Game> waitingGame= new List<Game>();
        private List<string> gameList = new List<string>();

        public List<string> displayGames()
        {
            return gameList;
        }

        public string endGame()
        {
            throw new NotImplementedException();
        }

        public Boolean playerConnectGame(Game game, Player playerOne, Player playerTwo)
        {
            throw new NotImplementedException();
        }

        public void startGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
