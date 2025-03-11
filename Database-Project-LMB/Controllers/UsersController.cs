using Database_Project_LMB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Database_Project_LMB.Controllers
{
    private readonly IUserRepository _userRepository;

    public UsersController()
    {
        _userRepository = new DummyUsersRepository();
    }

    public IActionResult Index()
    {
        List<User> users = _userRepository.GetAllUsers();
        return View(users);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(User user)
    {
        try
        {
            _userRepository.Add(user);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return View(user);
        }
    }
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
            User? user = _userRepository.GetUserByID((int)id);
            return View(user);
        }
    }
    [HttpPost]
    public IActionResult Delete(User user)
    {
        try
        {
            //delete user via repository
            _userRepository.Delete(user);

            //go back to user list(via Index)
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            //something went wrong, go back to view with user
            return View(user);
        }
    }

    //GET : USersController/Edit/5
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
            User? user = _userRepository.GetUserByID((int)id);
            return View(user);
        }
    }

    //POST : UsersController/Edit
    [HttpPost]
    public IActionResult Edit(User user)
    {
        try
        {
            //add users via repository
            _userRepository.Update(user);

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return View(user);
        }
    }
