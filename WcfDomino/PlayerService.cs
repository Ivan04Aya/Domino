using System;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;

namespace WcfDomino
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class PlayerService : IPlayerService
    {
        public Boolean RecordPlayer(string name, string userName, string email, string password)
        {
            Boolean result = false;
            try
            {
                using (var context = new KuruminoEntities())
                {
                    Player player = new Player
                    {
                        name = name,
                        userName = userName,
                        email = email,
                        password = Compute5HA256Hash(password)
                    };
                    context.Players.Add(player);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public int SendMail(string email)
        {
            int result;
            int randomNumber = new Random().Next(1000, 9999);

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

            mailMessage.To.Add(email);
            mailMessage.Subject = "Code of authentication";
            mailMessage.SubjectEncoding = Encoding.UTF8;
            mailMessage.Body = "The code is : " + randomNumber;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.From = new System.Net.Mail.MailAddress("gmail");

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient
            {
                Credentials = new System.Net.NetworkCredential("gmail", "password"),

                Port = 587,
                EnableSsl = true,

                Host = "smtp.gmail.com"
            };

            try
            {
                client.Send(mailMessage);
                result = randomNumber;
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        public Boolean Login(string userName, string password)
        {
            Boolean acceptUser = false;

            string passwordHashed = Compute5HA256Hash(password);
            try
            {
                using (var context = new KuruminoEntities())
                {
                    var Players = (from player in context.Players
                                   where player.userName == userName && player.password == passwordHashed
                                   select player).Count();
                    if (Players > 0)
                    {
                        acceptUser = true;
                    }
                }
            }
            catch (Exception)
            {
                acceptUser = false;
            }

            return acceptUser;
        }

        public string Compute5HA256Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
