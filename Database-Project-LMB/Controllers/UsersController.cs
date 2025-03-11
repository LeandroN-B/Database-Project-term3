﻿using Database_Project_LMB.Models;
using Database_Project_LMB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Database_Project_LMB.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _usersRepository;

        public UsersController(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IActionResult Index()
        {
            List<User> users = _usersRepository.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                //add users via repository
                _usersRepository.AddUser(user);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(user);
            }
        }

        //Get user
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            else
            {
                //get user via repository
                User? user = _usersRepository.GetUserByID((int)id);
                return View(user);
            }
        }

        public IActionResult Delete(User user)
        {
            try
            {
                //delete user via repository
                _usersRepository.DeleteUser(user);

                //go back to user list(via Index)
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //something went wrong, go back to view with user
                return View(user);
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (id is null)
            {
                return NotFound();
            }
            else
            {
                //get user via repository
                User? user = _usersRepository.GetUserByID((int)id);
                return View(user);
            }
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            try
            {
                //add users via repository
                _usersRepository.UpdateUser(user);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(user);
            }
        }
    }
}



