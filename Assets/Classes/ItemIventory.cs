namespace Assets.Classes
{
    public class ItemIventory
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }

        public ItemIventory(Item item, int quantity = 0)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}
