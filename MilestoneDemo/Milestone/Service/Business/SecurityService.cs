using Milestone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milestone.Service.Data;


namespace Milestone.Service.Business
{
    public class SecurityService
    {

        //Returns bool based on Security DAO
        public bool ProcessTheRegister(PlayerInfo player)
        {
            var DataAO = new SecurityDAO ();

            //If true then the email or username does not exist so it can be registered
            if (DataAO.checkUsernameEmail(player))
            {
                return DataAO.ProcessRegister(player);
            }
            else
                return false;
        }

        //Returns bool based on Player login
        public bool ProcessTheLogin(PlayerLogin player)
        {
            var DataAO = new SecurityDAO();
            return DataAO.ProcessLogin(player);
        }

    }
}
