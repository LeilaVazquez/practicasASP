using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace metodos
{
    public class EmailServices
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailServices() ///constructor ver segun el server que utilicemos
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("0f45295bb622ed", "3021f0625d7ce4"); //mail y contraseña
            server.Port = 2525;
            server.Host = "smtp.mailtrap.io";
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@programacion.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            //email.Body = "<h1>Hola</h1>"; //se puede levantar una plantilla
            email.Body = cuerpo;
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
