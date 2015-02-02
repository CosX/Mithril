using System;

namespace Assets.Scripts.Characters.EnemySpecific
{
    [Serializable]
    public class ItemDropChance
    {
        public int ItemId;
        public float Chance;

        public ItemDropChance(int itemid, float chance)
        {
            ItemId = itemid;
            Chance = chance;
        }

        public ItemDropChance()
        {
            
        }
    }
}
