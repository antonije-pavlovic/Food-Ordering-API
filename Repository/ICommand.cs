using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface ICommand<TRequest, TResponse>
    {
        TResponse Execute(TRequest request);
    }
}
