using UnityEngine;

namespace Assets.Scripts.Characters.PlayerSpecific
{
    public class MovementPlayer : MonoBehaviour
    {
        private Stamina _staminaObject;
        public float MaxSpeed = 2f;
        bool _facingLeft = true;
        bool _grounded;
        public Transform GroundCheck;
        public LayerMask WhatIsGround;
        public float JumpForce = 700f;

        void Start () {
            _staminaObject = GameObject.Find("Player").GetComponent<Stamina>();
        }
        void FixedUpdate () {
            var move = Input.GetAxis ("Horizontal");
            rigidbody2D.velocity = new Vector3(move * MaxSpeed, rigidbody2D.velocity.y);
            if (move < 0 && !_facingLeft) {
                Flip ();
            } else if (move > 0 && _facingLeft) {
                Flip ();
            }
        }

        void Update(){
            //Må håndtere longpress hvis man vil hoppe lenger
            if (_grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
            {
                rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                _grounded = false;
                _staminaObject.DrainStamina(25);
            }
		
		
        }
        //Må mer logikk inn i denne. Noe basert på hva Collision er.
        void OnCollisionEnter2D(Collision2D col)
        {
            _grounded = true;
        }
        //flip if needed
        void Flip(){
            _facingLeft = !_facingLeft;
            var theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
