using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Interfaces
{
    public interface IWalletService: IService<WalletDTO>
    {
        double InsertTransaction(WalletDTO dto, int id);
    }
}
