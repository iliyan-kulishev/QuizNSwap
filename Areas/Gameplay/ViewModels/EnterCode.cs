using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.Areas.Gameplay.ViewModels
{
    public class EnterCode
    {
        [Required]
        public string GameCode { get; set; }
    }
}
