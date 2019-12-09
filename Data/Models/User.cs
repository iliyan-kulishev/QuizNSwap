using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace QuizNSwap.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<Topic> Topics { get; set; }
    }
}
