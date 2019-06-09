using Application.DTO;
using Application.Responsens;
using Application.Searches;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Interfaces
{
    public interface IUserService: IService<UpdateUserDTO, UserDTO>,ICommand<TransactionSearch, PageResponse<TransactionDTO>>, ILoginService, IRegisterService
    {
        PageResponse<TransactionDTO> GetTRansactions(TransactionSearch search, int id);
        void SendMail(MailDTO dto, int id);
    }
}
