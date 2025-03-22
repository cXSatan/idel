using UnityEngine;

public class UITabManager : MonoBehaviour
{
    public GameObject skillsPanel;
    public GameObject inventoryPanel;

    public void ShowSkills()
    {
        skillsPanel.SetActive(true);
        inventoryPanel.SetActive(false);
    }

    public void ShowInventory()
    {
        skillsPanel.SetActive(false);
        inventoryPanel.SetActive(true);
    }
}
