using UnityEngine;

public class UITabManager : MonoBehaviour
{
    public GameObject skillsPanel;
    public GameObject inventoryPanel;
    public GameObject actionsPanel;

    public void ShowSkills()
    {
        skillsPanel.SetActive(true);
        inventoryPanel.SetActive(false);
        actionsPanel.SetActive(false);
    }

    public void ShowInventory()
    {
        skillsPanel.SetActive(false);
        inventoryPanel.SetActive(true);
        actionsPanel.SetActive(false);
    }

    public void ShowActions()
    {
        skillsPanel.SetActive(false);
        inventoryPanel.SetActive(true);
        actionsPanel.SetActive(false);
    }
}
