using UnityEngine;

namespace Assets.Scripts.Inventory.ItemSpecific
{
	public class Armor : Item
	{
	    public ArmorTypeDefines ArmorType;
	    public int ArmorProtection;

        public enum ArmorTypeDefines
        {
            Head,
            Shoes,
            Chest,
            Pants,
            Hands
        }
        public Armor(string name, int id, string desc, int value, ArmorTypeDefines type, int armorProtection, string iconpath)
		{
			ItemName = name;
			ItemId = id;
			ItemDesc = desc;
			ItemValue = value;
            ArmorType = type;
            ArmorProtection = armorProtection;
            ItemIcon = Resources.Load<Sprite>(iconpath);
		}

        public Armor()
		{
			
		}
	}
}
