using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class WallHitHandler : MonoBehaviour {

        private Rigidbody _mBody;

        void Awake()
        {
            _mBody = rigidbody;
        }

        void FixedUpdate()
        {
            // Get the velocity
            var horizontalMove = _mBody.velocity;
            // Don't use the vertical velocity
            horizontalMove.y = 0;
            // Calculate the approximate distance that will be traversed
            var distance = horizontalMove.magnitude * Time.fixedDeltaTime;
            // Normalize horizontalMove since it should be used to indicate direction
            horizontalMove.Normalize();
            RaycastHit hit;

            // Check if the body's current velocity will result in a collision
            if (_mBody.SweepTest(horizontalMove, out hit, distance))
            {
                _mBody.velocity = new Vector3(0, _mBody.velocity.y, 0);
            }
        }
    }
}
