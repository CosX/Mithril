using Assets.Scripts.Characters.PlayerSpecific;
using Assets.Scripts.Characters.PlayerSpecific.Weapon;
using Assets.Scripts.Inventory.ItemSpecific;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory.Equipment
{
    public class WeaponSlot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler
    {
        public Weapon CurrentlyEquippedWeapon = new Weapon();
        public Weapon.WeaponTypeDefines WeaponType;
        public GameObject InventoryGameObject;
        public GameObject PlayerGameObject;

        private Image _itemImage;
        private AttackActivator _damageControl;

        void Start()
        {
            _itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
            _damageControl = GameObject.FindGameObjectWithTag("Weapon").GetComponent<AttackActivator>();
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
                _damageControl.Damage = CurrentlyEquippedWeapon.WeaponStrength;
                _damageControl.Knockback = CurrentlyEquippedWeapon.Knockback;
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
                _damageControl.Damage = 25f;
                _damageControl.Knockback = new Vector3(30f, 30f);
                CurrentlyEquippedWeapon = new Weapon();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            var inventory = InventoryGameObject.GetComponent<Inventory>();
            var clickedItem = CurrentlyEquippedWeapon;
            if (clickedItem.ItemName != null && !inventory.DraggingItem)
            {
                inventory.ShowTooltip(gameObject.GetComponent<RectTransform>().localPosition, clickedItem);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            var inventory = InventoryGameObject.GetComponent<Inventory>();
            if (CurrentlyEquippedWeapon.ItemName != null)
            {
                inventory.CloseTooltip();
            }

        }
    }
}
