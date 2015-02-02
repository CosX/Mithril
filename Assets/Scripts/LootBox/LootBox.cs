using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Characters.EnemySpecific;
using Assets.Scripts.Inventory;
using UnityEngine;

namespace Assets.Scripts.LootBox
{
	public class LootBox : MonoBehaviour
	{
		public List<Item> Items; 
		public GameObject Slot;
        public GameObject InventoryGameObject;
		public Collider2D RayCastCollider2D;
        
		const float Startconstant = 103;
		private float _y = Startconstant;

		public void AddSlots(Collider2D coll2D)
		{
			var slotAmount = 0;
		    RayCastCollider2D = coll2D;
            InventoryGameObject.SetActive(true);
            Items = coll2D.GetComponent<EnemyDrop>().ItemsDropped;
			foreach (var t in Items)
			{
                if (t.ItemName != null)
			    {
                    var slot = (GameObject)Instantiate(Slot);
                    slot.GetComponent<DropSlotScript>().SlotNumber = slotAmount;
                    slot.transform.SetParent(gameObject.transform);
                    slot.name = t.ItemName;
                    slot.GetComponent<RectTransform>().localPosition = new Vector3(0, _y, 0);
                    slot.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    _y -= 65;
                    slotAmount++; 
			    }
			    
			}
			
		}

        public void RemoveSlots()
	    {
            var children = (from Transform child in transform select child.gameObject).ToList();
            children.ForEach(Destroy);
            _y = Startconstant;
	    }
	}
}
