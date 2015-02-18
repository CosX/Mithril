using UnityEngine;

namespace Assets.Scripts.Inventory.ItemSpecific
{
	public class RangedWeapon : Item
	{
		public RangedWeaponTypeDefines RangedWeaponType;
		public int WeaponStrength;

		public enum RangedWeaponTypeDefines
		{
			Bow,
			Staff
		}

		public RangedWeapon(string name, int id, string desc, int value, RangedWeaponTypeDefines type, int weaponstr, string iconpath)
		{
			ItemName = name;
			ItemId = id;
			ItemDesc = desc;
			ItemValue = value;
			RangedWeaponType = type;
			WeaponStrength = weaponstr;
			ItemIcon = Resources.Load<Sprite>(iconpath);
		}

		public RangedWeapon()
		{
			
		}
	}
}
