using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory.ItemSpecific;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory
{
    public class Inventory : MonoBehaviour
    {
        public List<Item> Items = new List<Item>();
        public List<GameObject> Slots = new List<GameObject>();
        public GameObject Slot;
        private ItemDatabase _database;
        private int _x = -480;
        private int _y = 220;
        // Use this for initialization

        public GameObject Tooltip;
        public GameObject DraggedItemGameObject;
        public bool DraggingItem;
        public Item DraggedItem;
        public int IndexOfDraggedItem;

        void Update()
        {
            if (DraggingItem)
            {
                var post = (Input.mousePosition -
                            GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>().localPosition);
                DraggedItemGameObject.GetComponent<RectTransform>().localPosition = new Vector3(post.x + 15, post.y -15, post.z);
            }
        }


        public void ShowTooltip(Vector3 toolposition, Item item)
        {
            Tooltip.SetActive(true);
            Tooltip.GetComponent<RectTransform>().localPosition = new Vector3(Input.mousePosition.x -550, Input.mousePosition.y -290, toolposition.z);
            Tooltip.transform.GetChild(0).GetComponent<Text>().text = item.ItemName;
            Tooltip.transform.GetChild(1).GetComponent<Text>().text = item.ItemDesc;
        }

        public void CloseTooltip()
        {
            Tooltip.SetActive(false);
        }

        public void ShowDraggedItem(Item item, int slotNumber)
        {
            IndexOfDraggedItem = slotNumber;
            CloseTooltip();
            DraggedItemGameObject.SetActive(true);
            DraggedItem = item;
            DraggingItem = true;
            DraggedItemGameObject.GetComponent<Image>().sprite = item.ItemIcon;
        }

        public void ShowDraggedItem(Item item)
        {
            CloseTooltip();
            DraggedItemGameObject.SetActive(true);
            DraggedItem = item;
            DraggingItem = true;
            DraggedItemGameObject.GetComponent<Image>().sprite = item.ItemIcon;
        }

        public void CloseDraggedItem()
        {
            DraggingItem = false;
            DraggedItemGameObject.SetActive(false);
        }

        private void Start()
        {
            var slotAmount = 0;
            _database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
            for (var i = 0; i < 5; i++)
            {
                for (var k = 0; k < 8; k++)
                {
                    var slot = (GameObject)Instantiate(Slot);
                    slot.GetComponent<SlotScript>().SlotNumber = slotAmount;
                    Slots.Add(slot);
                    Items.Add(new Item());
                    slot.transform.SetParent(gameObject.transform);
                    slot.name = String.Format("Slot {0}.{1}", k, i);
                    slot.GetComponent<RectTransform>().localPosition = new Vector3(_x, _y, 0);
                    slot.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    _x += 110;
                    if (k == 7)
                    {
                        _x = -480;
                        _y -= 110;
                    }
                    slotAmount++;
                }
            }
            AddItem(0);
            AddItem(1);
            AddItem(2);
            AddItem(2);
            AddItem(3);
        }
        public void AddItem(int id)
        {
            foreach (var t in _database.Items)
            {
                if (t.ItemId == id)
                {
                    var item = t;
                    var a = t as Consumable;
                    if (a != null)
                    {
                        CheckIfItemExsists(id, item);
                        break;
                    }
                    AddItemAtEmptySlot(item);
                    break;
                }
            }
        }

        private void CheckIfItemExsists(int itemId, Item item)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].ItemId == itemId)
                {
                    Items[i].ItemValue = Items[i].ItemValue + 1;
                    break;
                }
                if (i == Items.Count - 1)
                {
                    AddItemAtEmptySlot(item);
                }
            }
        }

        void AddItemAtEmptySlot(Item item)
        {
            for (var i = 0; i < Items.Count -1; i++)
            {
                if (Items[i].ItemName == null)
                {
                    Items[i] = item;
                    break;
                }
            }
        }
    }
}
