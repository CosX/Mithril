using UnityEngine;

namespace Assets.Scripts.Inventory.ItemSpecific
{
	public class Armor : Item
	{
	    public ArmorTypeDefines ArmorType;
	    public int ArmorProtection;
	    public Sprite ArmorSprite;

        public enum ArmorTypeDefines
        {
            Head,
            Shoes,
            Chest,
            Pants,
            Hands
        }
        public Armor(string name, int id, string desc, int value, ArmorTypeDefines type, int armorProtection, string iconpath, string spritepath)
		{
			ItemName = name;
			ItemId = id;
			ItemDesc = desc;
			ItemValue = value;
            ArmorType = type;
            ArmorProtection = armorProtection;
            ItemIcon = Resources.Load<Sprite>(iconpath);
            ArmorSprite = Resources.Load<Sprite>(spritepath);
		}

        public Armor()
		{
			
		}
	}
}
