
using System.Collections.Generic;

namespace Assets.Classes
{
    public static class Items
    {
        public static List<Item> List = new List<Item>
        {
            new Item(1, "logs", "These are logs from trees", 10),
            new Item(2, "other logs", "These are logs from other trees", 25),
        };
    }
}
