using Assets.Scripts.Characters.EnemySpecific;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Characters.PlayerSpecific
{
    public class MovementPlayer : MonoBehaviour
    {
        
        public float MaxSpeed = 2f;
        public Transform GroundCheck;
        public LayerMask WhatIsGround;
        public float JumpForce = 700f;

        private Stamina _staminaObject;
        private GUIText _actionText;
        private const float GroundRadius = 0.5f;
        private bool _facingLeft = true;
        private bool _grounded;
        private float _time;

        void Start () {
            _staminaObject = GameObject.Find("Player").GetComponent<Stamina>();
            _actionText = GameObject.FindGameObjectWithTag("ActionText").GetComponent<GUIText>();
        }
        void FixedUpdate ()
        {
            _grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, WhatIsGround);
            var move = Input.GetAxis ("Horizontal");
            rigidbody2D.velocity = new Vector3(move * MaxSpeed, rigidbody2D.velocity.y);
            if (move < 0 && !_facingLeft) {
                Flip ();
            } else if (move > 0 && _facingLeft) {
                Flip ();
            }
            collider2D.isTrigger = !_grounded;
        }

        void Update()
        {
            if (_grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
            {
                rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                _grounded = false;
                _staminaObject.DrainStamina(25);
            }
            if (!_grounded && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && _time < 24f)
            {
                _time += 1f;
                rigidbody2D.AddForce(new Vector2(0, 25f), ForceMode2D.Impulse);
            }

            if (_grounded)
            {
                _time = 0f;
            }
        }

        void Flip(){
            _facingLeft = !_facingLeft;
            var theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.tag == "Enemy")
            {
                var vec2 = new Vector2(-1500f, 1000f);
                rigidbody2D.AddForce(vec2, ForceMode2D.Impulse);
            }

        }
    }
}
