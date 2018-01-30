namespace Domain.Entities
{
    public class PlayerAction
    {
        public string Name { private set; get; }

        public PlayerAction(string name)
        {
            Name = name;
        }
    }
}