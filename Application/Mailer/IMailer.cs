using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mailer
{
    public interface IMailer
    {
        void SendMail(string subject,string body,int id);
    }
}
