using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WcfDomino;

namespace WpfDomino
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private ChannelFactory<IChatService> remoteFactory;
        private IChatService remoteProxy;
        private Player player;
        private bool isConnect = false;
        private string user;
        public Menu()
        {
            InitializeComponent();
        }

        public Menu(string user)
        {
            this.user = user;
            InitializeComponent();
            login();
            Console.WriteLine(user);
            lbUser.Content = user;
        }

        private void login()
        {
            if (!string.IsNullOrEmpty(user))
            {
                remoteFactory = new ChannelFactory<IChatService>("ChatConfig");
                remoteProxy = remoteFactory.CreateChannel();
                player = remoteProxy.playerConnect(user);
                if (player != null)
                {
                    isConnect = true;
                }
            }
        }

        private void btSignOff_Click(object sender, RoutedEventArgs e)
        {
            if (isConnect)
            {
                remoteProxy.removeUser(player);
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private void btStartGame_Click(object sender, RoutedEventArgs e)
        {
            StartGame startGame = new StartGame(lbUser.ToString());
            startGame.Show();
        }

        private void btLeaveGame_Click(object sender, RoutedEventArgs e)
        {
            if (isConnect)
            {
                remoteProxy.removeUser(player);
                this.Close();
            }
        }

        private void btDisplayHistory_Click(object sender, RoutedEventArgs e)
        {
            ConsultHistory consultHistory = new ConsultHistory(lbUser.ToString());
            consultHistory.Show();
        }
    }
}
