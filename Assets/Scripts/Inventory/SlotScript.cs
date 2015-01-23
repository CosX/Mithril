﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace Assets.Scripts.Inventory
{
	public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler
	{

		public Item CurrentItem;
		private Image _itemImage;
		public int SlotNumber;
		private Inventory _inventory;

		private Text _itemAmount;
		// Use this for initialization
		void Start ()
		{
			_itemAmount = gameObject.transform.GetChild(1).GetComponent<Text>();
			_inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
			_itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
		}
	
		// Update is called once per frame
		void Update () {

			if (_inventory.Items[SlotNumber].ItemName != null)
			{
                _itemAmount.enabled = false;

				CurrentItem = _inventory.Items[SlotNumber];
				_itemImage.enabled = true;
				_itemImage.sprite = _inventory.Items[SlotNumber].ItemIcon;

				if (_inventory.Items[SlotNumber].ItemType == Item.ItemTypeDefines.Consumable)
				{
					_itemAmount.enabled = true;
					_itemAmount.text = "" + _inventory.Items[SlotNumber].ItemValue;
				}
			}
			else
			{
				_itemImage.enabled = false;
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		    if (_inventory.Items[SlotNumber].ItemType == Item.ItemTypeDefines.Consumable)
		    {
		        _inventory.Items[SlotNumber].ItemValue--;
		        if (_inventory.Items[SlotNumber].ItemValue == 0)
		        {
		            _inventory.Items[SlotNumber] = new Item();
		            _itemAmount.enabled = false;
                    _inventory.CloseTooltip();
		        }
		    }

			if (_inventory.Items[SlotNumber].ItemName == null && _inventory.DraggingItem)
			{
				_inventory.Items[SlotNumber] = _inventory.DraggedItem;
				_inventory.CloseDraggedItem();
			}
			else if (_inventory.DraggingItem && _inventory.Items[SlotNumber].ItemName != null)
			{
				_inventory.Items[_inventory.IndexOfDraggedItem] = _inventory.Items[SlotNumber];
				_inventory.Items[SlotNumber] = _inventory.DraggedItem;
				_inventory.CloseDraggedItem();
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (_inventory.Items[SlotNumber].ItemName != null && !_inventory.DraggingItem)
			{
				_inventory.ShowTooltip(_inventory.Slots[SlotNumber].GetComponent<RectTransform>().localPosition, _inventory.Items[SlotNumber]);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (_inventory.Items[SlotNumber].ItemName != null)
			{
				_inventory.CloseTooltip();
			}
			
		}

		public void OnDrag(PointerEventData eventData)
		{
		    if (_inventory.Items[SlotNumber].ItemType == Item.ItemTypeDefines.Consumable)
		    {
		        _inventory.Items[SlotNumber].ItemValue++;
		    }

			if (_inventory.Items[SlotNumber].ItemName != null)
			{
				_inventory.ShowDraggedItem(_inventory.Items[SlotNumber], SlotNumber);
				_inventory.Items[SlotNumber] = new Item();

			    _itemAmount.enabled = false;
			}
			
		}
	}
}
