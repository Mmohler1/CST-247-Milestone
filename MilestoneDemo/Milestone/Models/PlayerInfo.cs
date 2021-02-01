using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// The Class that contains the information needed for each user or 'player'.
/// </summary>
namespace Milestone.Models
{
    public class PlayerInfo
    {


        public int PlayerID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Sex { get; set; }
        [Required]
        public int Age { get; set; }

        [Required]
        public string State { get; set; }
    }

}
