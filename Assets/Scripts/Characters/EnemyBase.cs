using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class EnemyBase : MonoBehaviour {

        public float DamagePerHit = 10f;
        public float KnockbackX = -100f;
        public float KnockbackY = 30f;

        private GameObject _playerObject;
        private Health _playerHealth;
	
        void Start(){
            _playerObject = GameObject.Find("Player");
            _playerHealth = _playerObject.GetComponent<Health>();
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Player") {
                _playerHealth.TakeDamage(DamagePerHit);
                col.gameObject.rigidbody2D.AddForce(Vector3.left * 10, ForceMode2D.Force);
                col.gameObject.rigidbody2D.isKinematic = false;
            }

        }
    }
}
