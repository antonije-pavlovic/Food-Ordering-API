using Application.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Interfaces
{
    public interface ILoginService
    {
        string Login(LoginDTO dto, IConfiguration config);        
    }
}
