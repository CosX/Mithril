using UnityEngine;

namespace Assets.Scripts.Characters.PlayerSpecific
{
    public class MovementPlayer : MonoBehaviour
    {
        private Stamina _staminaObject;
        public float MaxSpeed = 2f;
        bool _facingLeft = true;
        bool _grounded;
        private const float GroundRadius = 0.1f;
        public Transform GroundCheck;
        public LayerMask WhatIsGround;
        public float JumpForce = 700f;

        void Start () {
            _staminaObject = GameObject.Find("Player").GetComponent<Stamina>();
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
            //Må håndtere longpress hvis man vil hoppe lenger
            if (_grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
            {
                rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                _grounded = false;
                _staminaObject.DrainStamina(25);
            }
        }

        //}
        //flip if needed
        void Flip(){
            _facingLeft = !_facingLeft;
            var theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
