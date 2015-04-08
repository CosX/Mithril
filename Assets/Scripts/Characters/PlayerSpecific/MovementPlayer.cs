using Assets.Scripts.Characters.EnemySpecific;
using UnityEngine;

namespace Assets.Scripts.Characters.PlayerSpecific
{
    public class MovementPlayer : MonoBehaviour
    {
        
        public float MaxSpeed = 2f;
        public Transform GroundCheck;
        public LayerMask WhatIsGround;
        public float JumpForce = 700f;
        public bool FacingLeft = true;

        private Stamina _staminaObject;
        private GUIText _actionText;
        private const float GroundRadius = 0.5f;
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
            GetComponent<Rigidbody2D>().velocity = new Vector3(move * MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (move < 0 && !FacingLeft) {
                Flip ();
            } else if (move > 0 && FacingLeft) {
                Flip ();
            }
            GetComponent<Collider2D>().isTrigger = !_grounded;
        }

        void Update()
        {
            if (_grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                _grounded = false;
                _staminaObject.DrainStamina(25);
            }
            if (!_grounded && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && _time < 24f)
            {
                _time += 1f;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 25f), ForceMode2D.Impulse);
            }

            if (_grounded)
            {
                _time = 0f;
            }
        }

        void Flip(){
            FacingLeft = !FacingLeft;
            var theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.tag == "Enemy")
            {
                var kb = col.gameObject.GetComponent<EnemyBase>().Knockback;
                GetComponent<Rigidbody2D>().AddForce(kb, ForceMode2D.Impulse);
            }

        }
    }
}
