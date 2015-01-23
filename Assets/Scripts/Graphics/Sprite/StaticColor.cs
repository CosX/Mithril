using UnityEngine;

namespace Assets.Scripts.Graphics.Sprite
{
    public class StaticColor : MonoBehaviour {
        public Color Color = new Color(0f, 0f, 0f, 1f);
        void Start () {
            var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color; // Set to opaque black
        }
	
    }
}
