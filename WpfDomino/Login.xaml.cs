using System;
using System.Collections.Generic;
using System.Linq;
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
using WcfDomino;

namespace WpfDomino
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public bool AcceptUser { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            AcceptUser = false;
            PlayerService playerService = new PlayerService();
            if (tbUser != null && pbPassword != null)
            {
                if(playerService.Login(tbUser.Text, pbPassword.Password.ToString()))
                {
                    Menu menu = new Menu(tbUser.Text);
                    menu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("User and password incorrect");
                }
            }
            else
            {
                MessageBox.Show("Enter missing data");
            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btRecordPlayer_Click(object sender, RoutedEventArgs e)
        {
            RecordPlayer recordPlayer = new RecordPlayer();
            recordPlayer.Show();
            this.Close();
        }
    }
}