using P02_FootballBetting.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }


        [MaxLength(ValidationConstants.UserNameMaxLegth)]
        public string Username { get; set; } = null!;


        [MaxLength(ValidationConstants.UsersNameMaxLegth)]
        public string Name { get; set; } = null!;


        [MaxLength(ValidationConstants.PasswordMaxLegth)]
        public string Password { get; set; } = null!;

        [MaxLength(ValidationConstants.EmailMaxLegth)]
        public string Email { get; set; } = null!;

        public decimal Balance { get; set; }
    }
}
