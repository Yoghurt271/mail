using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace mail
{
    internal class Register
    {
        
        public void Reg()
        { 
            string email;
            string password;
            Random random = new Random();
            int code;
            try
            {
                MailAddress from = new MailAddress("odojy.m@yandex.ru", "XxxxxX");
                Console.WriteLine("Введите почту: ");
                email = Console.ReadLine();
                Console.WriteLine("Введите пароль: ");
                password = Console.ReadLine();
                MailAddress to = new MailAddress(email);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Код для регистрации";
                code = random.Next(100, 999);
                m.Body = Convert.ToString(code);
                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);
                smtp.Credentials = new NetworkCredential("odojy.m@yandex.ru", "aisbjqyvenypfbbp");
                smtp.EnableSsl = true;
                smtp.Send(m);
                Console.WriteLine("Код с подтверждением отправлен на почту");
                Console.WriteLine("Введите код:");
                int newCode = Convert.ToInt32(Console.ReadLine());
                if (newCode == code)
                {
                    Console.WriteLine("Регистрация прошла успешно");
                }
                else
                {
                    Console.WriteLine("Повторите попытку");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.Read();
        }
    }
}
