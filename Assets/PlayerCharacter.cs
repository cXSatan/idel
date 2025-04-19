using Assets.Classes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    // Future stat references
    public int health = 100;
    public int maxHealth = 100;

    public List<Skill> skillList = new List<Skill>();

    public GameObject UISkillBox;

    public GameObject ExpSection;
    public GameObject ExpPrefab;


    private TextMeshProUGUI expObject;
    private TextMeshProUGUI levelObject;

    void Start()
    {
        Debug.Log("Player spawned with " + health + " HP.");
        skillList.Add(new Woodcutting());

        expObject = UISkillBox.transform.Find("Experience").gameObject.GetComponent<TextMeshProUGUI>();
        levelObject = UISkillBox.transform.Find("Level").gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void GainExp(Skill skill, int value)
    {
        GameObject next = Instantiate(ExpPrefab, ExpSection.transform);
        next.GetComponentInChildren<TextMeshProUGUI>().text = "+" + value; 
        skill.Experience += value;
        expObject.text = skill.Experience.ToString();
        levelObject.text = skill.Level.ToString();
    }
}
