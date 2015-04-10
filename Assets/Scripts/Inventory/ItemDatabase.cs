﻿using System.Collections.Generic;
using Assets.Scripts.Inventory.ItemSpecific;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
	public class ItemDatabase : MonoBehaviour {

        public List<Item> Items = new List<Item>(); 

		void Start () {
            Items.Add(new Armor(
                "A Nice Hat", 
                0, 
                "This hat is the hat of a scholar!", 
                10, 
                Armor.ArmorTypeDefines.Head, 
                20, 
                "tileground", 
                "tileground"
                ));

            Items.Add(new Armor(
                "Good ol' Hat",
                4,
                "This hat is the oldest hat you've ever seen!",
                10, 
                Armor.ArmorTypeDefines.Head,
                20,
                "Textures/Raw/hats/old-hat",
                "Textures/Raw/hats/old-hat"
                ));

            Items.Add(new Armor(
                "Greasy Jeans",
                5,
                "These pants were cleaned with dirt.",
                10,
                Armor.ArmorTypeDefines.Pants,
                20,
                "Textures/Raw/pants/old-jeans",
                "Textures/Raw/pants/old-jeans"
                ));
            Items.Add(new Armor(
                "Ol' Rag",
                6,
                "Drenched in sweat and ripped!",
                10,
                Armor.ArmorTypeDefines.Chest,
                20,
                "Textures/Raw/chests/old-rag",
                "Textures/Raw/chests/old-rag"
                ));

            Items.Add(new Weapon(
                "Finest Sword of Infinity", 
                1, 
                "This sword will bring your enemies to oblivion!", 
                100, 
                Weapon.WeaponTypeDefines.Melee, 
                40, 
                "tileground", 
                "8_bit_sword_by_xxx515xxx-d4lyhdi", 
                new Vector3(30, 30)));

            Items.Add(new Consumable(
                "Large Health Potion", 
                2, 
                "This flazk wil meak splelling gardulaly wsroe!", 
                1, 
                Consumable.ConsumableTypeDefines.Health, 
                50, 
                "tileground"));

            Items.Add(new Weapon(
                "Bow of Bowling", 
                3, 
                "This bow was made by an alcoholic blacksmith. Not a good bow.", 
                1, 
                Weapon.WeaponTypeDefines.Ranged, 
                12, 
                "tileground", 
                "8_bit_sword_by_xxx515xxx-d4lyhdi", 
                new Vector3(30, 30), 
                (GameObject)Resources.Load("Prefabs/Projectiles/Projectile")));
		}
	
	}
}
