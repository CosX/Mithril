using UnityEngine;

namespace Assets.Scripts.Inventory.ItemSpecific
{
	public class Weapon : Item
	{
		public WeaponTypeDefines WeaponType;
		public int WeaponStrength;
	    public Sprite WeaponSprite;
	    public Vector3 Knockback;
	    public GameObject Projectile;
		public enum WeaponTypeDefines
		{
			Melee,
			Ranged
		}
		public Weapon(string name, int id, string desc, int value, WeaponTypeDefines type, int weaponstr, string iconpath, string spritepath, Vector3 knockback)
		{
			ItemName = name;
			ItemId = id;
			ItemDesc = desc;
			ItemValue = value;
			WeaponType = type;
			WeaponStrength = weaponstr;
			ItemIcon = Resources.Load<Sprite>(iconpath);
            WeaponSprite = Resources.Load<Sprite>(spritepath);
		    Knockback = knockback;
		}

        public Weapon(string name, int id, string desc, int value, WeaponTypeDefines type, int weaponstr, string iconpath, string spritepath, Vector3 knockback, GameObject projectile)
        {
            ItemName = name;
            ItemId = id;
            ItemDesc = desc;
            ItemValue = value;
            WeaponType = type;
            WeaponStrength = weaponstr;
            ItemIcon = Resources.Load<Sprite>(iconpath);
            WeaponSprite = Resources.Load<Sprite>(spritepath);
            Knockback = knockback;
            Projectile = projectile;
        }

	    public Weapon()
		{
			
		}
	}
}
