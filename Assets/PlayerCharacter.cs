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


    private TextMeshProUGUI expObject;
    private TextMeshProUGUI levelObject;
    void Start()
    {
        Debug.Log("Player spawned with " + health + " HP.");
        skillList.Add(new Skill(1, "woodcutting", "wc"));

        expObject = UISkillBox.transform.Find("Experience").gameObject.GetComponent<TextMeshProUGUI>();
        levelObject = UISkillBox.transform.Find("Level").gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void GainExp(int value)
    {
        skillList[0].Experience += value;
        expObject.text = skillList[0].Experience.ToString();
        levelObject.text = skillList[0].Level.ToString();
    }
}
