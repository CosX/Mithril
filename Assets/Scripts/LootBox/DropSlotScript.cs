using System.Linq;
using Assets.Scripts.Characters.EnemySpecific;
using Assets.Scripts.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.LootBox
{
	public class DropSlotScript : MonoBehaviour, IPointerDownHandler
	{

		public Item CurrentItem;
		private Image _itemImage;
		public int SlotNumber;

		private LootBox _lootbox;
		private Text _itemTitle;
		private Collider2D _deadEnemy;
		// Use this for initialization
		void Start ()
		{
			_itemTitle = gameObject.transform.GetChild(1).GetComponent<Text>();
			_lootbox = GameObject.FindGameObjectWithTag("DropBox").GetComponent<LootBox>();
			_itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
			
		}
	
		// Update is called once per frame
		void Update ()
		{
			_deadEnemy = _lootbox.RayCastCollider2D;

			if (_lootbox.Items.Count > 0 && _lootbox.Items[SlotNumber].ItemId != -1)
			{
				CurrentItem = _lootbox.Items[SlotNumber];
				_itemImage.enabled = true;
				_itemImage.sprite = _lootbox.Items[SlotNumber].ItemIcon;
				_itemTitle.text = _lootbox.Items[SlotNumber].ItemName;
			}
			else
			{
				_itemImage.enabled = false;
			}
		}


		public void OnPointerDown(PointerEventData eventData)
		{
			var clickedItem = _lootbox.Items[SlotNumber];
			var items = _deadEnemy.GetComponent<EnemyDrop>().ItemsDropped;
			_lootbox.InventoryGameObject.GetComponent<Inventory.Inventory>().AddItem(clickedItem.ItemId);
			var firstOrDefault = items.FirstOrDefault(x => x == clickedItem);
			if (firstOrDefault != null) firstOrDefault.ItemId = -1;
			_lootbox.Items[SlotNumber] = new Item();
			Destroy(gameObject);
		}
	}
}
