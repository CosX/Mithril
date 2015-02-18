using System;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
	[Serializable]
	public class Item
	{

		public string ItemName;
		public int ItemId;
		public string ItemDesc;
		public Sprite ItemIcon;
		public int ItemValue;

		public Item(string name, int id, string desc, int value)
		{
			ItemName = name;
			ItemId = id;
			ItemDesc = desc;
			ItemValue = value;
			ItemIcon = Resources.Load<Sprite>("tileground");
		}

		public Item()
		{
			
		}
	}
}
