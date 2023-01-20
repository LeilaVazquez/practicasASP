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
            server.Credentials = new NetworkCredential("programationiii@gmail.com", "programacion3"); //mail y contraseña
            server.Port = 587; //ver
            server.Host = "smtp.gmail.com"; //ver
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@ecommprogra.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = "<h1>Hola</h1>"; //se puede levantar una plantilla
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
