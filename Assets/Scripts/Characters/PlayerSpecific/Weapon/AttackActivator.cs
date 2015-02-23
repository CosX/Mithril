using Assets.Scripts.Inventory.Equipment;
using UnityEngine;

namespace Assets.Scripts.Characters.PlayerSpecific.Weapon
{
	public class AttackActivator : MonoBehaviour
	{
		public float Damage = 25f;
		public Vector3 Knockback = new Vector3(30, 30);
	    public Inventory.ItemSpecific.Weapon.WeaponTypeDefines WeaponType;
        public Transform Projectile;
		private bool _attacking;
	    public GameObject WeaponSlot;
	    private WeaponSlot _weapon;
        public float ShootingRate = 0.25f;
        private float _shootCooldown;
	    private MovementPlayer _movement;
		void Start ()
		{
			renderer.enabled = false;
		    _weapon = WeaponSlot.GetComponent<WeaponSlot>();
            _shootCooldown = 0f;
		    _movement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlayer>();
		}
	
		// Update is called once per frame
		void Update () {
            if (Input.GetKeyDown(KeyCode.Comma) && _attacking == false && _weapon.CurrentlyEquippedWeapon.ItemName != null && WeaponType == Inventory.ItemSpecific.Weapon.WeaponTypeDefines.Melee)
		    {
		        DoMeleeAttack();
		    }
            if (Input.GetKey(KeyCode.Period) && WeaponType == Inventory.ItemSpecific.Weapon.WeaponTypeDefines.Ranged && _weapon.CurrentlyEquippedWeapon.ItemName != null)
		    {
		        FireProjectile(false);
		    }
			
		}


		void FixedUpdate()
		{
			if (_attacking && transform.localRotation.z > 0.6f)
			{
				transform.Rotate(new Vector3(0, 0, 1), Time.timeScale * 15f, Space.World);
			}
			else
			{
				renderer.enabled = false;
				transform.localRotation = new Quaternion(0, 0, 90, 90);
				_attacking = false;
				collider2D.isTrigger = true;
			}

            if (_shootCooldown > 0)
            {
                _shootCooldown -= Time.deltaTime;
            }
		}

		private void DoMeleeAttack()
		{
			renderer.enabled = true;
			_attacking = true;
			collider2D.isTrigger = false;

		}
        public void FireProjectile(bool isEnemy)
        {
            if (!CanAttack) return;
            _shootCooldown = ShootingRate;

            var shotTransform = Instantiate(Projectile) as Transform;

            shotTransform.position = transform.position;

            var shot = shotTransform.gameObject.GetComponent<Projectile>();
            
            if (shot != null)
            {
                shot.IsEnemyShot = isEnemy;
                shot.Knockback = _weapon.CurrentlyEquippedWeapon.Knockback;
                shot.Damage = _weapon.CurrentlyEquippedWeapon.WeaponStrength;
            }

            var move = shotTransform.gameObject.GetComponent<FixedMovement>();
            if (move != null)
            {
                if (_movement.FacingLeft)
                {
                    move.Direction = transform.up;
                }
                else
                {
                    move.Direction = -transform.up;
                }
                    
            }
        }

        /// <summary>
        /// Is the weapon ready to create a new projectile?
        /// </summary>
        public bool CanAttack
        {
            get
            {
                return _shootCooldown <= 0f;
            }
        }
	}
}
