using Interfaces;
using Models;

namespace DefaultNamespace
{
    public class Hero : Card, IArmored, ICombatant, IDestructable
    {
        // IArmored
        public int armor { get; set; }
        
        // ICombatant
        public int attack { get; set; }
        public int remainingAttacks { get; set; }
        public int allowedAttacks { get; set; }
        
        // IDestructable
        public int hitPoints { get; set; }
        public int maxHitPoints { get; set; }
    }
}