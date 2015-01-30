using UnityEngine;

namespace Assets.Scripts.Characters.PlayerSpecific.Weapon
{
	public class AttackActivator : MonoBehaviour
	{
		public float Damage = 25f;
		public Vector3 Knockback = new Vector3(30, 30);
		private bool _attacking;

		void Start ()
		{
			renderer.enabled = false;
		}
	
		// Update is called once per frame
		void Update () {

			if (Input.GetKeyDown(KeyCode.Comma) && _attacking == false)
			{
				DoAttack();
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
		}

		private void DoAttack()
		{
			renderer.enabled = true;
			_attacking = true;
			collider2D.isTrigger = false;

		}
	}
}
