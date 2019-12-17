using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuizNSwap.Data.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Game Game { get; set; }
    }
}
