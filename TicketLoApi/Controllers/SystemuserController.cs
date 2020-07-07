using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using TicketLoApi.Controllers;
using TicketLoApi.DataAccess;
using TicketLoApi.Models;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using Microsoft.Extensions.Configuration;

namespace TicketLoApi.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class SystemuserController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public SystemuserController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        //[Route("api/[controller]/register")]
        [HttpPost("register")]
        public RegisterResult Register([FromBody] SystemuserParam pr) 
        {
            RegisterResult res = new RegisterResult();
            try 
            {
                pr.password = LoginController.MD5Hash(pr.password);
                if (_dataAccessProvider.RegisterUser(pr.fullname, pr.email, pr.password)) 
                {
                    var message = new MimeMessage();
                    message.To.Add(new MailboxAddress(pr.fullname, pr.email));
                    message.From.Add(new MailboxAddress("TicketLonoreply@gmail.com", "T.Lo.noreply"));

                    message.Subject = "Register Ticket Lo";

                    message.Body = new TextPart(TextFormat.Html)
                    {
                        Text = "Hai lu berhasil register... silahkan login lagi cuy"
                    };

                    using (var emailClient = new SmtpClient())
                    {
                        emailClient.Connect("smtp.gmail.com", 465);

                        emailClient.Authenticate("TicketLonoreply@gmail.com", "BL4CKC412D");
                                
                        emailClient.Send(message);

                        emailClient.Disconnect(true);
                    }
                    res.Status = "OK";
                    res.Message = "Register Success";
                }
                else 
                {
                    res.Status = "NG";
                    res.Message = "Email sudah ada";
                }

            }
            catch (Exception ex) 
            {
                res.Status = "NG";
                res.Message = ex.ToString();
            }

            return res;
        }

        //[Route("api/[controller]/forgot")]
        [HttpPost("forgot")]
        public ForgotResult ForgotPassword([FromBody] ForgotParam pr) 
        {
            ForgotResult res = new ForgotResult();
            try 
            {
                var data = _dataAccessProvider.ForgotPassword(pr.email);
                if (data != null)
                {
                    var message = new MimeMessage();
                    message.To.Add(new MailboxAddress(data.fullname, pr.email));
                    message.From.Add(new MailboxAddress("TicketLonoreply@gmail.com", "T.Lo.noreply"));

                    message.Subject = "Register Ticket Lo";

                    message.Body = new TextPart(TextFormat.Html)
                    {
                        Text = "Hai klik link berikut untuk ganti passwordmu"
                    };

                    using (var emailClient = new SmtpClient())
                    {
                        emailClient.Connect("smtp.gmail.com", 465);

                        emailClient.Authenticate("TicketLonoreply@gmail.com", "BL4CKC412D");

                        emailClient.Send(message);

                        emailClient.Disconnect(true);
                    }
                    res.Status = "OK";
                    res.Message = "Check email slur";
                }
                else
                {
                    res.Status = "NG";
                    res.Message = "Email tidak ditemukan";
                }
            }
            catch (Exception ex) 
            {
                res.Status = "NG";
                res.Message = ex.ToString();
            }
            return res;
        }

    }
}
