using Microsoft.AspNetCore.Mvc;
using Milestone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone.Controllers
{

    

    public class MinesweeperController : Controller
    {
        Field board = new Field();
        private int rows, cols;
        bool win = false;
        public string user;

        //static Space[,] buttons;
        static List<Space> buttons = new List<Space>();

        public IActionResult Index()
        {


            for (int X = 0; X < 10; X++)
            {
                for (int Y = 0; Y < 10; Y++)
                {
                    buttons.Add(new Space(X, Y));
                }
            }
            
            board.MakeMines(buttons);
            board.mineCheck(buttons);

            return View("Index", buttons);
        }



        public IActionResult HandleOnClick(string squareNumber)
        {
            int bttnInt = int.Parse(squareNumber);

            if(buttons.ElementAt(bttnInt).CurrentlyOccupied == true)
            {
                buttons.ElementAt(bttnInt).visited = true;
                for (int i = 0; i < 100; i++)
                {
                    buttons.ElementAt(i).visited = true;
                }
                ViewBag.theResult = "You lose";
                return View("Index", buttons);
            }
            else
            {
                //board.floodFill(buttons.ElementAt(bttnInt).row, buttons.ElementAt(bttnInt).col, buttons);
                buttons.ElementAt(bttnInt).visited = true;
            }





            ViewBag.theResult = "Start";
            return View("Index", buttons);
        }

    }
}
