using System.Collections.Generic;
using Assets.Scripts.Inventory.ItemSpecific;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
	public class ItemDatabase : MonoBehaviour {

        public List<Item> Items = new List<Item>(); 

		void Start () {
            Items.Add(new Armor("A Nice Hat", 0, "This hat is the hat of a scholar!", 10, Armor.ArmorTypeDefines.Head, 20, "tileground"));
            Items.Add(new MeleeWeapon("Finest Sword of Infinity", 1, "This sword will bring your enemies to oblivion!", 100, MeleeWeapon.MeleeWeaponTypeDefines.Sword, 40, "tileground"));
            Items.Add(new Consumable("Large Health Potion", 2, "This flazk wil meak splelling gardulaly wsroe!", 1, Consumable.ConsumableTypeDefines.Health, 50, "tileground"));
            Items.Add(new RangedWeapon("Bow of Bowling", 3, "This bow was made by an alcoholic blacksmith. Not a good bow.", 1, RangedWeapon.RangedWeaponTypeDefines.Bow, 12, "tileground"));
		}
	
	}
}
