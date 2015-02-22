using Assets.Scripts.Characters.PlayerSpecific;
using Assets.Scripts.Inventory.ItemSpecific;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory.Equipment
{
    public class ArmorSlot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler
    {
        public Armor CurrentlyEquippedArmor = new Armor();
        public Armor.ArmorTypeDefines ArmorType;
        public GameObject InventoryGameObject;
        public GameObject PlayerGameObject;

        private Image _itemImage;
        private Health _health;
        private Stamina _stamina;

        void Start()
        {
            _itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
            _health = PlayerGameObject.GetComponent<Health>();
            _stamina = PlayerGameObject.GetComponent<Stamina>();
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
                _health.health += CurrentlyEquippedArmor.ArmorProtection;
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
                _health.health -= clickedItem.ArmorProtection;
                CurrentlyEquippedArmor = new Armor();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            var inventory = InventoryGameObject.GetComponent<Inventory>();
            var clickedItem = CurrentlyEquippedArmor;
            if (clickedItem.ItemName != null && !inventory.DraggingItem)
            {
                inventory.ShowTooltip(gameObject.GetComponent<RectTransform>().localPosition, clickedItem);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            var inventory = InventoryGameObject.GetComponent<Inventory>();
            if (CurrentlyEquippedArmor.ItemName != null)
            {
                inventory.CloseTooltip();
            }

        }
    }
}
