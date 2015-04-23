using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Inventory.ItemSpecific;
using LitJson;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
	public class ItemDatabase : MonoBehaviour {

        public List<Item> Items = new List<Item>(); 

		void Start ()
		{
		    var armorlist = FillFromJson<ArmorConstructed>("Assets\\Scripts\\Inventory\\ItemStorage\\armordatabase.json");
            var weaponlist = FillFromJson<WeaponConstructed>("Assets\\Scripts\\Inventory\\ItemStorage\\weapondatabase.json");
		    var consumableList = FillFromJson<ConsumableConstructed>("Assets\\Scripts\\Inventory\\ItemStorage\\consumabledatabase.json");

		    foreach (var armor in armorlist)
		    {
		        Items.Add(new Armor(armor.ItemName, armor.ItemId, armor.ItemDesc, armor.ItemValue, armor.ArmorType, armor.ArmorProtection, armor.ItemIcon, armor.ArmorSprite));
		    }

		    foreach (var weapon in weaponlist)
		    {
		        if (weapon.WeaponType == Weapon.WeaponTypeDefines.Melee)
		        {
		            Items.Add(new Weapon(weapon.ItemName, weapon.ItemId, weapon.ItemDesc, weapon.ItemValue, weapon.WeaponType,
		                weapon.WeaponStrength, weapon.ItemIcon, weapon.WeaponSprite, weapon.KnockbackX, weapon.KnockbackY));
		        }
		        else
		        {
                    Items.Add(new Weapon(weapon.ItemName, weapon.ItemId, weapon.ItemDesc, weapon.ItemValue, weapon.WeaponType,
                       weapon.WeaponStrength, weapon.ItemIcon, weapon.WeaponSprite, weapon.KnockbackX, weapon.KnockbackY, weapon.ProjectilePath));
		        }
		    }

		    foreach (var consumable in consumableList)
		    {
                Items.Add(new Consumable(consumable.ItemName, consumable.ItemId, consumable.ItemDesc, consumable.ItemValue, consumable.ConsumableType, consumable.AppendValue, consumable.ItemIcon));
		    }
		}

	    public List<T> FillFromJson<T>(string path)
	    {
            var fullpath = Path.GetFullPath(path);
            var json = File.ReadAllText(fullpath);
            return JsonMapper.ToObject<List<T>>(json);
	    }
	}
}
