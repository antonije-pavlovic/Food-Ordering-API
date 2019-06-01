using Application.DTO;
using Application.Responsens;
using Application.Searches;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Interfaces
{
    public interface IUserService: IService<AuthDTO>,ICommand<TransactionSearch, PageResponse<TransactionDTO>>
    {
        PageResponse<TransactionDTO> GetTRansactions(TransactionSearch search, int id);
        string Login(AuthDTO dto,IConfiguration config);
        void SendMail(MailDTO dto, int id);
    }
}
