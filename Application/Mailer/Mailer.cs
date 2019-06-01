using MailKit.Net.Smtp;
using MimeKit;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mailer
{
    public class Mailer : IMailer
    {
        private readonly string _hostMail = "mr.antonije@gmail.com";
        private readonly string _mailServer = "smtp.gmail.com";
        private readonly int _mailPort = 587;
        private readonly string _password = "klarasuman";
        private readonly bool _secure = false;
        private MimeMessage _msg;
        private readonly IUnitOfWork _unitOfWork;
        public Mailer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _msg = new MimeMessage();
            _msg.To.Add(new MailboxAddress(_hostMail));
        }
        public void SendMail(string subject, string body, int id)
        {
            var user = _unitOfWork.User.Get(id);
            _msg.From.Add(new MailboxAddress(user.Email));
            _msg.Subject = subject;
            _msg.Body = new TextPart("plain")
            {
                Text = body
            };           
            using(var client = new SmtpClient())
            {
                client.Connect(_mailServer, _mailPort, _secure);
                client.Authenticate(_hostMail, _password);
                client.Send(_msg);
                client.Disconnect(true);
            }
        }
    }
}
