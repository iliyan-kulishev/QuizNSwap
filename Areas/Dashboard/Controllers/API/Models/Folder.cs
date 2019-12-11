using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.Areas.Dashboard.Controllers.API.Models
{
    public class Folder
    {
        [Required]
        public string Name { get; set; }
        //public int TopicCount { get; set; }
    }
}
