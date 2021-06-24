using MovieService.Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MovieService.Service.Email
{
	public class GMail:IDisposable
	{
		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		//public void SendMail(string email, string message,string header= "TMDB")
		public void SendMail(EmailModel emailModel)
		{
			//MailMessage mymail = new MailMessage();
			//mymail.To.Add(email);
			//mymail.From = new MailAddress("tradingwebsite.estore@gmail.com");
			//mymail.Subject = header;
			//mymail.Body = message;
			//mymail.IsBodyHtml = true;
			//SmtpClient smtp = new SmtpClient();
			//smtp.UseDefaultCredentials = true;
			//smtp.Credentials = new NetworkCredential("tradingwebsite.estore@gmail.com", "parola123_E");
			//smtp.Port = 587;
			//smtp.Host = "smtp.gmail.com";
			//smtp.EnableSsl = true;

			try
			{
				//smtp.Send(mymail);
				using (MailMessage mail = new MailMessage())
				{
					mail.From = new MailAddress("tradingwebsite.estore@gmail.com");
					mail.To.Add(emailModel.Email);
					mail.Subject = emailModel.Header;
					mail.Body = $"{emailModel.Message}";
					mail.IsBodyHtml = true;

					using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
					{
						smtp.Credentials = new NetworkCredential("tradingwebsite.estore@gmail.com", "TestParola123");
						smtp.EnableSsl = true;
						smtp.Send(mail);
					}
				}
			}
			catch (Exception ex)
			{
				
			}
		}
	}
}
