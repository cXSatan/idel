using System;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public bool woodcutting;

    public GameObject ExpSection;
    public GameObject ExpPrefab;

    public float interval = 1f; // Time between actions
    private float timer = 0f;

    private PlayerCharacter stats;
    private PlayerInventory inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            if (IsHitSuccessful(CalculateChanceLog(stats.skillList[0].Level, 1, 200, 85, 90))) 
            {
                // Add logic for success or not
                GainLog();
                GainExp();
            }
        }
    }

    double CalculateChanceLog(int level, int minLevel, int maxLevel, double startPct, double maxPct, double curveStrength = 2.5)
    {
        if (level < minLevel)
        {
            return startPct;
        }
        else if (level > maxLevel)
        {
            return maxPct;
        }
        else
        {
            // Normalize progress
            double progress = (double)(level - minLevel) / (maxLevel - minLevel);
            // Apply ease-out curve
            progress = Math.Pow(progress, 1.0 / curveStrength);
            return startPct + progress * (maxPct - startPct);
        }
    }

    bool IsHitSuccessful(double chancePercentage)
    {
        System.Random rng = new System.Random();
        double roll = rng.NextDouble() * 100.0; // Roll between 0 and 100
        return roll < chancePercentage;
    }

    void GainLog()
    {
        inventory.AddQuantity(1, 1);
    }

    void GainExp()
    {
        GameObject next = Instantiate(ExpPrefab, ExpSection.transform);
        //RectTransform nextRect = next.GetComponent<RectTransform>();
        stats.GainExp(10);
    }
}
