using UnityEngine;

namespace Assets.Scripts.HUD
{
    [RequireComponent(typeof(GUIText))]
    public class PositionActionTextAboveHead : MonoBehaviour
    {

        public Transform Target;  // Object that this label should follow
        public Vector3 Offset = Vector3.up;    // Units in world space to offset; 1 unit above object by default
        public bool ClampToScreen = false;  // If true, label will be visible even if object is off screen
        public float ClampBorderSize = 0.05f;  // How much viewport space to leave at the borders when a label is being clamped
        public bool UseMainCamera = true;   // Use the camera tagged MainCamera
        public Camera CameraToUse;   // Only use this if useMainCamera is false
        Camera _cam;
        Transform _thisTransform;
        Transform _camTransform;

        void Start()
        {
            _thisTransform = transform;
            _cam = UseMainCamera ? Camera.main : CameraToUse;
            _camTransform = _cam.transform;
        }


        void Update()
        {

            if (ClampToScreen)
            {
                Vector3 relativePosition = _camTransform.InverseTransformPoint(Target.position + Offset);
                relativePosition.z = Mathf.Max(relativePosition.z, 1.0f);
                _thisTransform.position = _cam.WorldToViewportPoint(_camTransform.TransformPoint(relativePosition));
                _thisTransform.position = new Vector3(Mathf.Clamp(_thisTransform.position.x, ClampBorderSize, 1.0f - ClampBorderSize),
                    Mathf.Clamp(_thisTransform.position.y, ClampBorderSize, 1.0f - ClampBorderSize),
                    _thisTransform.position.z);

            }
            else
            {
                _thisTransform.position = _cam.WorldToViewportPoint(Target.position + Offset);
            }
        }
    }
}
