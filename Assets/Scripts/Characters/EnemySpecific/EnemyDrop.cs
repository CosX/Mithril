using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Inventory;
using UnityEngine;

namespace Assets.Scripts.Characters.EnemySpecific
{
    [Serializable]
    public class EnemyDrop : MonoBehaviour
    {
        public List<ItemDropChance> PossibleItemsOnEnemy;
        public List<Item> ItemsDropped = new List<Item>(); 

        private ItemDatabase _database;
        private EnemyHealth _enemy;
        private int _triggerdrop;

        // Use this for initialization
        void Start () {
            _database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
            _enemy = gameObject.GetComponent<EnemyHealth>();
        }

        void Update()
        {
            if (_enemy.IsDead && _triggerdrop == 0)
            {
                RandomGenerateDrop();
                _triggerdrop = 1;
            }
        }

        void RandomGenerateDrop()
        {
            foreach (var possibleitem in PossibleItemsOnEnemy)
            {
                var dicenumber = UnityEngine.Random.Range(0F, 100F);

                if (dicenumber >= possibleitem.Chance)
                {
                    var droppeditem = _database.Items.FirstOrDefault(x => x.ItemId == possibleitem.ItemId);
                    ItemsDropped.Add(droppeditem);
                }
            }
        }
    }
}
