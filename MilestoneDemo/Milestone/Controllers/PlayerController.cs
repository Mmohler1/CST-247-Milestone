using Microsoft.AspNetCore.Mvc;
using Milestone.Models;
using Milestone.Service.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone.Controllers
{
    public class PlayerController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult Register(PlayerInfo player)
        {
            var securityS = new SecurityService();

            if (securityS.ProcessTheRegister(player) == true)
            {
                //Sends user back to index page
                return View("Login");
            }
            //If false keep user on register page
            return View("Register");


        }


        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(PlayerLogin player)
        {
            var securityS = new SecurityService();

            if (securityS.ProcessTheLogin(player) == true)
            {
                //Sends user to Minesweeper page
                return View("~/Views/Minesweeper/Index.cshtml");
            }

            //If false keep user on register page
            return View("Login");


        }



    }  
}
