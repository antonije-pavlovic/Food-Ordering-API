using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IToken<ClaimsIdentity>
    {
        private IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("Transaction")]
        public IActionResult Transaction()
        {
            var id = GetTokenId.getId(this.getClaim());
            var wallet = _unitOfWork.Wallet.Find(w => w.UserId == id).FirstOrDefault();
            var transations = _unitOfWork.Transaction.Find(t => t.WalletID == wallet.Id).Select(t => new TransactionDTO {
                Amount = t.Amount,
                Type = t.Type
            });
            return Ok(transations);
        }

        // PUT: api/User/5
        [HttpPut]
        public IActionResult Put([FromBody] AuthDTO dto)
        {
            var id = GetTokenId.getId(this.getClaim());
            _unitOfWork.User.UpdateUser(dto, id);
            _unitOfWork.Save();
            return Ok("succesufully updated");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete()
        {
           var id = GetTokenId.getId(this.getClaim());
           _unitOfWork.User.SoftDelete(id);
           _unitOfWork.Save();
            return Ok("Account deleted");
        }

        public ClaimsIdentity getClaim()
        {
           return User.Identity as ClaimsIdentity;
        }
    }
}
