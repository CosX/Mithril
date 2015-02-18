using UnityEngine;

namespace Assets.Scripts.Inventory.ItemSpecific
{
	public class MeleeWeapon : Item
	{
		public MeleeWeaponTypeDefines MeleeWeaponType;
		public int WeaponStrength;

		public enum MeleeWeaponTypeDefines
		{
			Sword,
			Axe
		}
		public MeleeWeapon(string name, int id, string desc, int value, MeleeWeaponTypeDefines type, int weaponstr, string iconpath)
		{
			ItemName = name;
			ItemId = id;
			ItemDesc = desc;
			ItemValue = value;
			MeleeWeaponType = type;
			WeaponStrength = weaponstr;
			ItemIcon = Resources.Load<Sprite>(iconpath);
		}

		public MeleeWeapon()
		{
			
		}
	}
}
