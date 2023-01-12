﻿using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;

namespace SocialMediaApp.Controllers
{
    public class RequestController : Controller
    {
        RequestManager rm = new RequestManager(new EfRequestRepository());
        UserManager um = new UserManager(new EfUserRepository());
        public IActionResult Index()
        {
            var requests = rm.RequestList();
            return View(requests);
        }
        [HttpGet]
        public IActionResult Add()
        {
            RequestUserModel rum = new RequestUserModel();
            rum.RequestModel = new Request();
            rum.UserModel = um.UserList();

            return View(rum);
        }
        [HttpPost]
        public IActionResult Add(Request request)
        {
            RequestValidator requestValidator = new RequestValidator();
            var result = requestValidator.Validate(request);
            if (result.IsValid)
            {
                rm.RequestInsert(request);
                return RedirectToAction("Index");
            }
            else
            {
                RequestUserModel rum = new RequestUserModel();
                rum.RequestModel = new Request();
                rum.UserModel = um.UserList();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(rum);
            }
            
        }

    }
}
