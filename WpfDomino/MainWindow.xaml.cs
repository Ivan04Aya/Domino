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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WcfDomino;

namespace WpfDomino
{
    public partial class MainWindow : Window
    {

        private ChannelFactory<IChatService> remoteFactory;
        private IChatService remoteProxy;
        private Player player;
        private bool isConnect = false;
        private string user;

        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(string user)
        {
            this.user = user;
            InitializeComponent();
            login();
            updateInformation();
            Console.WriteLine(user);
            lbUser.Content= user;
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
                    btSend.IsEnabled = true;
                    tbMessage.IsEnabled = true;
                    isConnect = true;
                    tbMessages.IsEnabled = true;
                    lbPlayers.IsEnabled = true;
                }
            }
        }
        private void players()
        {
            List<string> players = remoteProxy.displayPlayers();
            players.Remove(user);
            lbPlayers.ItemsSource = players;
        }

        private void insertMessage(Message message)
        {
            tbMessages.AppendText("\n" + message.user.UserName + ": says (" + message.Date + "):\n" + message.MessageChat + "\n");
        }

        private void messages()
        {
            List<Message> messages = remoteProxy.receiveMessage(player);
            if (messages != null)
            {
                foreach (var message in messages) insertMessage(message);
            }
        }

        private void btSend_Click(object sender, RoutedEventArgs e)
        {
            Message message = new Message()
            {
                Date = DateTime.Now,
                MessageChat = tbMessage.Text,
                user = player
            };

            if (lbPlayers.SelectedItem != null)
            {
                string userChatPrivate = lbPlayers.SelectedItem.ToString();
                remoteProxy.sendMessagePrivate(message, userChatPrivate);
                insertMessage(message);
                tbMessage.Text = string.Empty;
            }
            else if (!string.IsNullOrEmpty(tbMessage.Text))
            {
                remoteProxy.sendMessage(message);
                insertMessage(message);
                tbMessage.Text = string.Empty;
            }
        }

        private void updateInformation()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            messages();
            players();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            if (isConnect)
            {
                remoteProxy.sendMessage(new Message()
                {
                    Date = DateTime.Now,
                    MessageChat = "i'm logged out",
                    user = player
                });
                remoteProxy.removeUser(player);
                this.Close();
            }
        }

        private void btChatPublic_Click(object sender, RoutedEventArgs e)
        {
            lbPlayers.SelectedIndex = -1;
        }

        private void lbPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}