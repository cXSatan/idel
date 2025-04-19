using Assets.Classes;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public GameObject UIIventoryTab;

    private List<ItemIventory> items = new List<ItemIventory>();
    private TextMeshProUGUI Text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddItem(Items.List[0], 1); // test value
        AddItem(Items.List[1], 1); // test value

        Text = UIIventoryTab.transform.Find("Woodcutting").transform.Find("TextItem").GetComponent<TextMeshProUGUI>();
    }

    public void AddItem(Item item, int quantity)
    {
        items.Add(new ItemIventory(item, quantity));
    }

    public void UpdateItem(int id, int quantity)
    {
        if (items.Any(i => i.Item.Id == id))
        {
            var itemInv = items.First(i => i.Item.Id == id);
            itemInv.Quantity = quantity;
            Text.text = itemInv.Quantity.ToString();
        }
    }

    public void AddQuantity(int id, int quantity)
    {
        if (items.Any(i => i.Item.Id == id))
        {
            var itemInv = items.First(i => i.Item.Id == id);
            itemInv.Quantity += quantity;
            Text.text = itemInv.Quantity.ToString();
        }
    }
}
