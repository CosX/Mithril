using System.Linq;
using Assets.Scripts.Characters.EnemySpecific;
using UnityEngine;

namespace Assets.Scripts.Characters.PlayerSpecific
{
    public class PlayerControls : MonoBehaviour {

        public GameObject InventoryGameObject;
        public GameObject LootBoxGameObject;

        public Transform PlayerTransform;
        public LayerMask Baddies;
        public Collider2D RayCastCollider2D;
        public bool DeadEnemyHit;

        private GUIText _actionText;
        private bool _looting;
        void Start()
        {
            _actionText = GameObject.FindGameObjectWithTag("ActionText").GetComponent<GUIText>();
        }

        void Update () {
            //InventoryToggle
            if (Input.GetKeyDown(KeyCode.I))
            {
                InventoryGameObject.SetActive(!InventoryGameObject.activeSelf);
            }

            RayCastCollider2D = Physics2D.OverlapCircle(PlayerTransform.position, 200f, Baddies);

            if (RayCastCollider2D != null && RayCastCollider2D.transform.tag == "Enemy" && RayCastCollider2D.GetComponent<EnemyHealth>().IsDead && RayCastCollider2D.GetComponent<EnemyDrop>().ItemsDropped.Any(item => item.ItemName != null))
            {
                _actionText.text = "Press [E] to loot";
                _actionText.enabled = true;
                DeadEnemyHit = true;
            }
            else
            {
                LootBoxGameObject.SetActive(false);
                DeadEnemyHit = false;
                _actionText.enabled = false;
                LootBoxGameObject.GetComponent<LootBox.LootBox>().RemoveSlots();
                _looting = false;
            }

            if (DeadEnemyHit && Input.GetKeyDown(KeyCode.E) && !_looting)
            {
                if (RayCastCollider2D != null)
                {
                    LootBoxGameObject.SetActive(true);
                    LootBoxGameObject.GetComponent<LootBox.LootBox>().AddSlots(RayCastCollider2D);
                    _looting = true;
                }
                    
            }
        }
    }
}
