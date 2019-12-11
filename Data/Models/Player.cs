namespace QuizNSwap.Data.Models
{
    public class Player
    {
        public int Id {get; set;}
        public string Name { get; set;}
        public object Data { get; set; }
        public string GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}