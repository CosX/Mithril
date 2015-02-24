using UnityEngine;

namespace Assets.Scripts.Characters.PlayerSpecific.Weapon
{
    public class Projectile : MonoBehaviour {

        public int Damage;
        public Vector3 Knockback;
        public bool IsEnemyShot = false;

        void Start()
        {
            Destroy(gameObject, 1);
        }
    }
}
