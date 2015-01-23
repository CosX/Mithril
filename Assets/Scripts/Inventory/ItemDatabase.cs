using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
	public class ItemDatabase : MonoBehaviour {

        public List<Item> Items = new List<Item>(); 

		// Use this for initialization
		void Start () {
	        Items.Add(new Item("Aromr", 0, "Good shit", 13, 14, Item.ItemTypeDefines.Chest));
            Items.Add(new Item("DRANK", 1, "Gowefod shit", 13, 1, Item.ItemTypeDefines.Consumable));
            Items.Add(new Item("Awefefromr", 2, "Gfefood shit", 13, 14, Item.ItemTypeDefines.Pants));
            Items.Add(new Item("Arfefomr", 3, "Goowdesfd shit", 13, 14, Item.ItemTypeDefines.Hands));
		}
	
	}
}
