using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class GetTokenId
    {
        public static int getId(ClaimsPrincipal User)
        {
            var claimsIdentity = GetClaim(User);
            var userId = claimsIdentity.Claims.Where(x => x.Type == "sid").FirstOrDefault().Value;
            return Int32.Parse(userId);
        }

        public static ClaimsIdentity GetClaim(ClaimsPrincipal User)
        {
            return User.Identity as ClaimsIdentity;
        }

    }
}
