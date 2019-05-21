using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public interface IToken<ClaimsIdentity>
    {
        ClaimsIdentity getClaim();
    }
}
