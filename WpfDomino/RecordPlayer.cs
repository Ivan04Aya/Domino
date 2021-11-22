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
    /// Lógica de interacción para RecordPlayer.xaml
    /// </summary>
    public partial class RecordPlayer : Window
    {
        public RecordPlayer()
        {
            InitializeComponent();
            tbAuthentication.IsReadOnly = true;
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            PlayerService playerService = new PlayerService();
            if (playerService.RecordPlayer(tbName.Text, tbUserName.Text, tbEmail.Text, pbPassword.Password.ToString()))
            {
                MessageBox.Show("Player save");
            }
            else
            {
                MessageBox.Show("Player save not");
            }
        }

        private void BtSendEmail_Click(object sender, RoutedEventArgs e)
        {
            PlayerService playerService = new PlayerService();
            int codeAuthentication = playerService.SendMail(tbEmail.Text);
            if (codeAuthentication != 0)
            {
                MessageBox.Show("Messeage sent"+codeAuthentication);
                tbAuthentication.IsReadOnly = false;
            }
            else
            {
                MessageBox.Show("Error sending");
            }
        }
    }
}
