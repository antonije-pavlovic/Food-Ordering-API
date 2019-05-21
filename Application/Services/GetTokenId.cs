using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class GetTokenId
    {
        public static int getId(ClaimsIdentity claimsIdentity)
        {
            var id = claimsIdentity.Claims.Where(x => x.Type == "sid").FirstOrDefault().Value;
            return Int32.Parse(id);
        }
    }
}
