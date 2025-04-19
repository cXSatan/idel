using System;
using UnityEngine;

namespace Assets.Classes
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { 
            get 
            {
                return GetLevelFromExperience();
            }
            set
            {
                Experience = GetExperienceForLevel(value);
            }
        }
        public long Experience { get; set; }


        protected int minLevel = 1;
        protected int maxLevel = 200;
        protected long startExp = 1;
        protected long maxExp = 2000000000;

        public Skill(int id, string name, string description, int level = 1)
        {
            this.Id = id;
            Name = name;
            Description = description;
            this.Level = level;
        }

        private int GetLevelFromExperience()
        {
            if (Experience <= 0)
                return minLevel;

            // Precompute total weight using quadratic growth
            double totalWeight = 0;
            for (int i = minLevel + 1; i <= maxLevel; i++)
            {
                totalWeight += Math.Pow(i - minLevel, 2);
            }

            double cumulativeExp = 0;
            for (int level = minLevel + 1; level <= maxLevel; level++)
            {
                double weight = Math.Pow(level - minLevel, 2);
                double expForLevel = (weight / totalWeight) * maxExp;
                cumulativeExp += expForLevel;

                if (Experience < cumulativeExp)
                    return level - 1; // Return the last level the player fully completed
            }

            return maxLevel;
        }

        public long GetExperienceForLevel(int level)
        {
            if (level <= minLevel)
                return 0;

            double totalWeight = 0;
            for (int i = minLevel + 1; i <= maxLevel; i++)
            {
                totalWeight += Math.Pow(i - minLevel, 2);
            }

            double experience = 0;
            for (int lvl = minLevel + 1; lvl <= level; lvl++)
            {
                double weight = Math.Pow(lvl - minLevel, 2);
                double expForLevel = (weight / totalWeight) * maxExp;
                experience += expForLevel;
            }

            return (int)Math.Floor(experience);
        }

        public virtual void Action(Player player)
        {

        }
    }
}
