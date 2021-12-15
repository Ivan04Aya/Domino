using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace WcfDomino
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class GameService : IGameService
    {
        private List<Game> waitingGame = new List<Game>();
        private List<string> gameList = new List<string>();

        public List<string> displayGames()
        {
            return gameList;
        }

        public string endGame(string resultGame)
        {
            String result = null;
            try
            {
                using (var context = new KuruminoEntities())
                {
                    Game game = new Game()
                    {
                        result = resultGame
                    };
                    context.Game.Add(game);
                    context.SaveChanges();
                    result = resultGame;
                }
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }

        public Boolean playerConnectGame(Game game, Player playerOne, Player playerTwo)
        {
            Boolean answer = false;
            if (!game.playerOne.Equals(playerTwo.userName))
            {
                answer = true;
            }
            return answer;
        }

        public void startGame(Game game)
        {
            var exist = from Game e in this.waitingGame where e.playerOne == game.playerOne select e;
            if (exist.Count() == 0)
            {
                this.waitingGame.Add(game);
                gameList.Add(game.playerOne);
            }
            else
            {
                game = null;
            }
        }
    }
}
