using Assets.Scripts.Characters.PlayerSpecific.Weapon;
using UnityEngine;

namespace Assets.Scripts.Characters.EnemySpecific
{
    public class EnemyHealth : MonoBehaviour {

        public float Health = 100f;
        private bool _dead;

        void Update ()
        {
            if (Health <= 0f) {
               
                EnemyDead();
                
            }
        }

        void EnemyDead()
        {
            _dead = true;
            Debug.Log("Enemy died!");
            //Animate death and drop loot
        }

        public void TakeDamage (float amount)
        {
            if (Health - amount <= 0)
            {
                Health = 0;
            }
            else
            {
                Health -= amount;
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.tag == "Weapon" && !_dead)
            {
                var weapon = col.collider.gameObject.GetComponent<AttackActivator>();
                TakeDamage(weapon.Damage);
                rigidbody2D.AddForce(weapon.Knockback, ForceMode2D.Impulse);
            }

        }
    }
}
