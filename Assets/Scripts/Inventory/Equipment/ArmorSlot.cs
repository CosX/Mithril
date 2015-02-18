using Assets.Scripts.Inventory.ItemSpecific;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory.Equipment
{
    public class ArmorSlot : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        public Armor CurrentlyEquippedArmor = new Armor();
        public Armor.ArmorTypeDefines ArmorType;
        private Image _itemImage;
        public GameObject InventoryGameObject;

        void Start()
        {
            _itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        }

        void Update()
        {
            if (CurrentlyEquippedArmor.ItemName != null)
            {
                _itemImage.enabled = true;
                _itemImage.sprite = CurrentlyEquippedArmor.ItemIcon;
            }
            else
            {
                 _itemImage.sprite = new Sprite();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            var inventory = InventoryGameObject.GetComponent<Inventory>();

            var draggeditem = inventory.DraggedItem as Armor;
            if (inventory.DraggingItem && draggeditem != null && CurrentlyEquippedArmor.ItemName == null && draggeditem.ArmorType == ArmorType)
            {
                CurrentlyEquippedArmor = draggeditem;
                inventory.CloseDraggedItem();
            }
            else if (inventory.DraggingItem && CurrentlyEquippedArmor.ItemName != null)
            {
                inventory.Items[inventory.IndexOfDraggedItem] = CurrentlyEquippedArmor;
                CurrentlyEquippedArmor = draggeditem;
                inventory.CloseDraggedItem();
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            var inventory = InventoryGameObject.GetComponent<Inventory>();

            var clickedItem = CurrentlyEquippedArmor;
            if (clickedItem.ItemName != null)
            {
                inventory.ShowDraggedItem(clickedItem);
                CurrentlyEquippedArmor = new Armor();
            }
        }

    }
}
