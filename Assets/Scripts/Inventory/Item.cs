using System;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
	public class Item : MonoBehaviour
	{

	    public string ItemName;
	    public int ItemId;
	    public string ItemDesc;
	    public Sprite ItemIcon;
	    public GameObject ItemModel;
	    public int ItemPower;
	    public int ItemValue;
        public ItemTypeDefines ItemType;

        public enum ItemTypeDefines
        {
            Weapon,
            Consumable,
            Quest,
            Head,
            Shoes,
            Chest,
            Pants,
            Hands
        }

	    public Item(string name, int id, string desc, int power, int value, ItemTypeDefines type)
	    {
	        ItemName = name;
	        ItemId = id;
	        ItemDesc = desc;
	        ItemPower = power;
	        ItemValue = value;
	        ItemType = type;
	        ItemIcon = Resources.Load<Sprite>("" + name);
	    }

	    public Item()
	    {
	        
	    }
	}
}
