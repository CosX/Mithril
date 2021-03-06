﻿using UnityEngine;

namespace Assets.Scripts.Inventory.Equipment
{
    public class ArmorFetcher : MonoBehaviour
    {
        public ArmorSlot ArmorSlot;
        private SpriteRenderer _sprite = new SpriteRenderer();
        

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            
        }

        private void Update()
        {
            if (ArmorSlot.CurrentlyEquippedArmor.ItemName != null)
            {
                _sprite.sprite = ArmorSlot.CurrentlyEquippedArmor.ArmorSprite;
            }
            else
            {
                _sprite.sprite = new Sprite();
            }
        }
    }
}
