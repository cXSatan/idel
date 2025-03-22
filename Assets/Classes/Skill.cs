using System;

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

        private int minLevel = 1;
        private int maxLevel = 99;
        private long startExp = 1;
        private long maxExp = 200000000;

        public Skill(int id, string name, string description, int level = 1)
        {
            this.Id = id;
            Name = name;
            Description = description;
            this.Level = level;
        }

        private int GetLevelFromExperience()
        {
            if (Experience <= startExp)
                return minLevel;
            if (Experience >= maxExp)
                return maxLevel;

            double growthRate = Math.Pow((double)maxExp / startExp, 1.0 / (maxLevel - minLevel));
            double level = Math.Log((double)Experience / startExp, growthRate) + minLevel;

            return Math.Max(minLevel, Math.Min((int)Math.Floor(level), maxLevel));
        }

        public long GetExperienceForLevel(int level)
        {
            if (level <= minLevel)
                return startExp;
            if (level >= maxLevel)
                return maxExp;

            double growthRate = Math.Pow((double)maxExp / startExp, 1.0 / (maxLevel - minLevel));
            double xp = startExp * Math.Pow(growthRate, level - minLevel);
            return (int)Math.Round(xp); // Always return integer XP
        }
    }
}
