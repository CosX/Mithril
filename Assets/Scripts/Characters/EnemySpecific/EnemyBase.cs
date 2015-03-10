using Assets.Scripts.Characters.PlayerSpecific;
using UnityEngine;

namespace Assets.Scripts.Characters.EnemySpecific
{
    public class EnemyBase : MonoBehaviour {

        public float DamagePerHit = 10f;
        public Vector3 Knockback = new Vector3(30f, 30f);
        public float Force = 30f;

        private GameObject _playerObject;
        private Health _playerHealth;
        

        void Start(){
            _playerObject = GameObject.Find("Player");
            _playerHealth = _playerObject.GetComponent<Health>();
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.gameObject.tag == "Player") {
                _playerHealth.TakeDamage(DamagePerHit);
            }

        }
    }
}
