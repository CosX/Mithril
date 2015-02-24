using Assets.Scripts.Characters.PlayerSpecific;
using Assets.Scripts.Characters.PlayerSpecific.Weapon;
using UnityEngine;

namespace Assets.Scripts.Characters.EnemySpecific
{
    public class EnemyHealth : MonoBehaviour {

        public float Health = 100f;
        public bool IsDead;
        public bool IsLooted;
        void Update ()
        {
            if (Health <= 0f && !IsDead)
            {
               
                EnemyDead();
            }
        }

        void EnemyDead()
        {
            IsDead = true;
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

        public void DestroyAfterLoot()
        {
            var tempcolor = gameObject.GetComponent<SpriteRenderer>().color;
            tempcolor.a = Mathf.MoveTowards(1, 0.1f, Time.deltaTime);
            gameObject.GetComponent<SpriteRenderer>().color = tempcolor;
            IsLooted = true;
            Destroy(gameObject, 4);
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.tag == "Weapon" && !IsDead)
            {
                col.collider.isTrigger = false;
                var weapon = col.collider.gameObject.GetComponent<AttackActivator>();
                TakeDamage(weapon.Damage);
                rigidbody2D.AddForce(weapon.Knockback, ForceMode2D.Impulse);
            }
            else if (col.collider.tag == "Projectile" && !IsDead)
            {
                col.collider.isTrigger = false;
                var projectile = col.collider.gameObject.GetComponent<Projectile>();
                TakeDamage(projectile.Damage);
                rigidbody2D.AddForce(projectile.Knockback, ForceMode2D.Impulse);
                Destroy(col.collider.gameObject);

            }
            if (IsDead)
            {

                col.collider.isTrigger = true;
            }
        }
    }
}
