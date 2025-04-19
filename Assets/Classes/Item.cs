namespace Assets.Classes
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Experience { get; set; }

        public Item(int id, string name, string description, int experience)
        {
            this.Id = id;
            Name = name;
            Description = description;
            Experience = experience;
        }
    }
}
