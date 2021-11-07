using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfDomino
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class PlayerService : IPlayerService
    {
        public Boolean recordPlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public Boolean sendMail(string email)
        {
            throw new NotImplementedException();
        }

        public History consultHistory(string name)
        {
            throw new NotImplementedException();
        }

    }
}
