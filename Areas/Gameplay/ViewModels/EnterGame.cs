using System.ComponentModel.DataAnnotations;

namespace QuizNSwap.Areas.Gameplay.ViewModels
{
    public class EnterGame
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
