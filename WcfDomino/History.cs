using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WcfDomino
{
    [DataContract]
    public class History
    {
        private string idJugador;
        private List<Game> listGames;
        private int gameWin;
        private int gameLose;
        private int totalGames;

        [DataMember]
        public string IdJugador
        {
            get { return idJugador; }
            set { idJugador = value; }
        }

        [DataMember]
        internal List<Game> ListGames
        {
            get { return listGames; }
            set { listGames = value; }
        }

        [DataMember]
        public int TotalGames
        {
            get { return totalGames; }
            set { totalGames = value; }
        }

        [DataMember]
        public int GameWin
        {
            get { return gameWin; }
            set { gameWin = value; }
        }

        [DataMember]
        public int GameLose
        {
            get { return gameLose; }
            set { gameLose = value; }
        }
    }
}
