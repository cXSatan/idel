using Assets.Classes;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool woodcutting;

    public float interval = 1f; // Time between actions


    private float timer = 0f;

    private PlayerCharacter stats;
    private PlayerInventory inventory;
    private Animator m_animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_animator = gameObject.GetComponentInParent<Animator>();
        stats = gameObject.GetComponent<PlayerCharacter>();
        inventory = gameObject.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            DoAction();
            timer = 0f; // Reset timer
        }
    }

    void DoAction()
    {
        if (woodcutting)
        {
            m_animator.SetBool("Woodcutting", true);
            stats.skillList[0].Action(this);
        }
        else
        {
            m_animator.SetBool("Woodcutting", false);
        }
    }

    public void AddToIventory(int itemId, int quantity)
    {
        inventory.AddQuantity(itemId, quantity);
    }

    public void GainExp(Skill skill, int experience)
    {
        stats.GainExp(skill, experience);

    }

    public void Click(int logId)
    {
        ((Woodcutting)stats.skillList[0]).ChangeLog(logId);
    }
}
