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
        public void ConfirmationEmail(string Email,out int Code)
        {
            Random random = new Random();
            int KodIntRan = random.Next(0, 1000000);
            try
            {
                string from = @"m4rysa123@yandex.ru"; // адреса отправителя
#pragma warning disable CS0219 // Переменной "pass" присвоено значение, но оно ни разу не использовано.
                string pass = "Marysa123!"; // пароль отправителя
#pragma warning restore CS0219 // Переменной "pass" присвоено значение, но оно ни разу не использовано.
                MailMessage mess = new MailMessage();
                mess.To.Add(Email); // адрес получателя
                mess.From = new MailAddress(from);
                mess.Subject = "Ваш пароль для регистрации в приложении:" + KodIntRan; // тема
                mess.Body = "asd"; // текст сообщения
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "m4rysa123@yandex.ru";
                NetworkCred.Password = "Marysa123!";
                client.Credentials = NetworkCred;
                client.Host = "smtp.yandex.com"; //smtp-сервер отправителя
                client.Port = 25;
                client.EnableSsl = true;

                client.Send(mess); // отправка пользователю

                Code = KodIntRan;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
                throw;
            }
        }
    }
}
