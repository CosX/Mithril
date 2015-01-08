using UnityEngine;

namespace Assets.Scripts.Characters.PlayerSpecific
{
    public class CameraFollowPlayer : MonoBehaviour {

        public float DampTime = 0.15f;
        private Vector3 _velocity = Vector3.zero;
        public Transform Target;

        void FixedUpdate()
        {
            if (Target)
            {
                var point = camera.WorldToViewportPoint(Target.position);
                var delta = Target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                var destination = transform.position + delta;
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref _velocity, DampTime);
            }

        }
    }
}
