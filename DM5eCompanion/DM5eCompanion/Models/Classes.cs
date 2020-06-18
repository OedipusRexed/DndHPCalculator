using System;
using System.Collections.Generic;
using System.Text;

namespace DM5eCompanion.Models
{
    public enum ClassType
    {
        Artificer,
        Barbarian,
        Bard,
        Bloodhunter,
        Cleric,
        Druid,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Rogue,
        Sorcerer,
        Warlock,
        Witch,
        Wizard,
    }
    class Classes
    {
        public ClassType Id { get; set; }
        public String Title { get; set; }
        public int HitDie { get; set; }
        public int Average { get; set; }
    }
}
