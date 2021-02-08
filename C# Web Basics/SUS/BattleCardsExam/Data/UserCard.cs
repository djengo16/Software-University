
namespace BattleCardsExam.Data
{
    public class UserCard
    {
        //        •	Has UserId – a string
        public string UserId { get; set; }
        //•	Has User – a User object
        public User User { get; set; }
        //•	Has CardId – an int
        public int CardId { get; set; }
        //•	Has Card – a Card object
        public Card Card { get; set; }

    }
}
