using Portafolio.Models;
using System.Net.Mail;

namespace Portafolio.Servicios
{ 
    public interface IServicioEmailGmail
    {
        Task Enviar(ContactoDTO contacto);
    }
    public class ServicioEmailGmail:IServicioEmailGmail
    {
        private readonly IConfiguration _configuration;
        public ServicioEmailGmail(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task Enviar(ContactoDTO contacto)
        {
            var email = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
            var password = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
            var smtpServer = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
            var smtpPort = _configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PUERTO");

            using (var client = new SmtpClient(smtpServer, smtpPort))
            { 
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;

                client.Credentials = new System.Net.NetworkCredential(email, password);
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(email),
                    Subject = "Nuevo contacto desde el portafolio",
                    Body = $"El cliente: {contacto.Nombre}\nEmail: {contacto.Email} quiere contactarte.\nMensaje: {contacto.Mensaje}",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(email);

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
