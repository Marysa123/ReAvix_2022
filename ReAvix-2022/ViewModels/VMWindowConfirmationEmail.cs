using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowConfirmationEmail
    {
        public void ConfirmationEmail(string Email, out bool PassEmail, out int CodeEmail)
        {
            Random random = new Random();
            int KodIntRan = random.Next(0, 1000000);
            try
            {
                string from = @"m4rysa123@yandex.ru"; // адреса отправителя
                string pass = "Marysa123!"; // пароль отправителя
                MailMessage mess = new MailMessage();
                mess.To.Add(Email); // адрес получателя
                mess.From = new MailAddress(from);
                mess.Subject = "Код для регистрации"; // тема
                mess.Body = "Код для регистрации в приложении ReAvix:" + KodIntRan; // текст сообщения
                SmtpClient client = new SmtpClient
                {
                    UseDefaultCredentials = false
                };
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential
                {
                    UserName = "m4rysa123@yandex.ru",
                    Password = "Marysa123!"
                };
                client.Credentials = NetworkCred;
                client.Host = "smtp.yandex.com"; //smtp-сервер отправителя
                client.Port = 25;
                client.EnableSsl = true;

                client.Send(mess); // отправка пользователю

                CodeEmail = KodIntRan;
                PassEmail = true;
            }
            catch (Exception)
            {
                CodeEmail = 0;
                PassEmail = false;
            }
        } 
    }
}
