using System;
using System.Diagnostics;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

namespace Assets.Classes
{
    public class Woodcutting : Skill
    {
        private int minChanceNormalLog = 20;
        private int maxChanceNormalLog = 90;
        public Item currentLog = Items.List[0];

        public Woodcutting(int level = 1)
            : base(1, "woodcutting", "wc", level)
        {
            this.Level = level;
        }
        public override void Action(Player player)
        {
            if (IsHitSuccessful(CalculateChanceLog(Level, minLevel, maxLevel, minChanceNormalLog, maxChanceNormalLog)))
            {
                // Add logic for success or not
                player.AddToIventory(currentLog.Id, 1);
                player.GainExp(this, currentLog.Experience);
            }
        }

        public void ChangeLog(int logItemId)
        {
            currentLog = Items.List.FirstOrDefault(i => i.Id == logItemId);
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
    }
}
