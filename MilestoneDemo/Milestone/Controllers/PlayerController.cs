using Microsoft.AspNetCore.Mvc;
using Milestone.Models;
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
        //For connecting to the database
        public string dbPlayerConn { get; set; }

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

            if (ProcessRegister(player) == true)
            {
                //Sends user back to index page
                return View("SuccessReg", player);
            }
            //If false keep user on register page
            return View("FailureReg", player);


        }

        public bool ProcessRegister(PlayerInfo player)
        {
            this.dbPlayerConn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbPlayer;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False";

            //Stays false until connection goes through and is closed
            bool isSuccessful = false;
            //Adds Player to database, should be easy to move this to a database layer later
            using (SqlConnection conn = new SqlConnection(dbPlayerConn))
            {
                //Calling stored procedure to add player to database
                using (SqlCommand cmd = new SqlCommand("usp_InsertPlayer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Using the stored procedure
                    cmd.Parameters.AddWithValue("@Username", player.Username);
                    cmd.Parameters.AddWithValue("@Password", player.Password);
                    cmd.Parameters.AddWithValue("@Email", player.Email);
                    cmd.Parameters.AddWithValue("@FirstName", player.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", player.LastName);
                    cmd.Parameters.AddWithValue("@Sex", player.Sex);
                    cmd.Parameters.AddWithValue("@Age", player.Age);
                    cmd.Parameters.AddWithValue("@State", player.State);

                    conn.Open();

                    //Executing the query
                    cmd.ExecuteNonQuery();
                    //since Query went through set bool to true. 
                    isSuccessful = true;
                }
                conn.Close();


            }
            return isSuccessful;
        }
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(PlayerLogin player)
        {

            if (ProcessLogin(player) == true);
            {
                //Sends user back to index page
                return View("Test");
            }

            //If false keep user on register page
            return View("Failure");


        }

        

        public bool ProcessLogin(PlayerLogin player)
        {
            this.dbPlayerConn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbPlayer;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
                "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            bool isSuccessful = false;
            //Adds Player to database, should be easy to move this to a database layer later
            using (SqlConnection conn = new SqlConnection(dbPlayerConn))
            {
                //Calling stored procedure
                using (SqlCommand cmd = new SqlCommand("usp_GetPlayerLogin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    try
                    { 

                        cmd.Parameters.AddWithValue("@Username", player.Username);
                        cmd.Parameters.AddWithValue("@Password", player.Password);
                        conn.Open();
                        using SqlDataReader reader = cmd.ExecuteReader();
                        if(reader.HasRows == true)
                        {
                            isSuccessful = true;
                        }
                    
                        


                    }
                    
                    catch(Exception e)
                    { Console.WriteLine(e); }

                }
                conn.Close();


            }
            return isSuccessful;
        }
    }
}
