using Assets.Scripts.Characters.PlayerSpecific;
using Assets.Scripts.Inventory.ItemSpecific;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory.Equipment
{
    public class WeaponSlot : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        public Weapon CurrentlyEquippedWeapon = new Weapon();
        public Weapon.WeaponTypeDefines WeaponType;
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
            if (CurrentlyEquippedWeapon.ItemName != null)
            {
                _itemImage.enabled = true;
                _itemImage.sprite = CurrentlyEquippedWeapon.ItemIcon;
            }
            else
            {
                 _itemImage.sprite = new Sprite();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            var inventory = InventoryGameObject.GetComponent<Inventory>();

            var draggeditem = inventory.DraggedItem as Weapon;
            if (inventory.DraggingItem && draggeditem != null && CurrentlyEquippedWeapon.ItemName == null && draggeditem.WeaponType == WeaponType)
            {
                CurrentlyEquippedWeapon = draggeditem;
                inventory.CloseDraggedItem();
            }
            else if (inventory.DraggingItem && CurrentlyEquippedWeapon.ItemName != null)
            {
                inventory.Items[inventory.IndexOfDraggedItem] = CurrentlyEquippedWeapon;
                CurrentlyEquippedWeapon = draggeditem;
                inventory.CloseDraggedItem();
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            var inventory = InventoryGameObject.GetComponent<Inventory>();

            var clickedItem = CurrentlyEquippedWeapon;
            if (clickedItem.ItemName != null)
            {
                inventory.ShowDraggedItem(clickedItem);
                CurrentlyEquippedWeapon = new Weapon();
            }
        }

    }
}
