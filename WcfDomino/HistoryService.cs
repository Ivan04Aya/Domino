using System;
using System.ServiceModel;

namespace WcfDomino
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class HistoryService : IHistoryService
    {
        public History ConsultHistory(string name)
        {
            History history = new History();
            int userName = int.Parse(name);
            try
            {
                using (var context = new KuruminoEntities())
                {
                    var histories = context.History.Find(userName);
                    if (histories != null)
                    {
                        history = histories;
                    }
                }
            }
            catch (Exception)
            {
                history = null;
            }
            return history;
        }
    }
}
