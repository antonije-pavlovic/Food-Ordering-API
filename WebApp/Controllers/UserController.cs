using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: User
        public ActionResult Index()
        {
            var users = _unitOfWork.User.GetAll().Select(u => new UserDTO {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    isDeleted = u.IsDeleted
            });
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = _unitOfWork.User.Find(u => u.Id == id).Select(u => new UserDTO
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                isDeleted = u.IsDeleted
            }).FirstOrDefault();
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var user = new AuthDTO
                {
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    Email = collection["Email"],
                    Password = Compute256Hash.ComputeSha256Hash(collection["Password"])
                };
                _unitOfWork.User.RegisterUser(user);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _unitOfWork.User.Find(u => u.Id == id).Select(u => new UserDTO
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                isDeleted = u.IsDeleted
            }).FirstOrDefault();
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                _unitOfWork.User.UpdateUser(new AuthDTO
                {
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    Email = collection["Email"],
                    IsDeleted = Int32.Parse(collection["IsDeleted"])
                }, id);
                _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            _unitOfWork.User.SoftDelete(id);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}