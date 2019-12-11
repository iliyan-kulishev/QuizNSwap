using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace QuizNSwap.Areas.Dashboard.ViewModels
{
    public class Profile
    {
        //If I get to this - there will be current pass
        // new pass, confrim new pass or re-type new
        //save and cancel buttons
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
