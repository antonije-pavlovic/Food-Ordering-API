using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Interfaces
{
    public interface IRegisterService
    {
        int Register(RegisterDTO dto);
    }
}
