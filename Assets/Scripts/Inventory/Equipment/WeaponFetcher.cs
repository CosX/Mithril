using UnityEngine;

namespace Assets.Scripts.Inventory.Equipment
{
    public class WeaponFetcher : MonoBehaviour
    {
        public WeaponSlot WeaponSlot;
        
        private SpriteRenderer _sprite = new SpriteRenderer();
        

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            
        }

        private void Update()
        {
            if (WeaponSlot.CurrentlyEquippedWeapon.ItemName != null)
            {
                _sprite.sprite = WeaponSlot.CurrentlyEquippedWeapon.WeaponSprite;
            }
            else
            {
                _sprite.sprite = new Sprite();
            }
        }
    }
}
