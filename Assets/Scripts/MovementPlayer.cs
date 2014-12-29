using UnityEngine;
using System.Collections;

public class MovementPlayer : MonoBehaviour
{
	public float maxSpeed = 2f;
	bool facingLeft = true;
	bool grounded = false;
	float distToGround = 0;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	void Start () {
	}
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector3(move * maxSpeed, rigidbody2D.velocity.y);
		if (move < 0 && !facingLeft) {
			Flip ();
		} else if (move > 0 && facingLeft) {
			Flip ();
		}
	}

	void Update(){
        //Må håndtere longpress hvis man vil hoppe lenger
		if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			grounded = false;
		}
		
		
	}
	//Må mer logikk inn i denne. Noe basert på hva Collision er.
	void OnCollisionEnter2D(Collision2D col)
	{
		grounded = true;
	}
	//flip if needed
	void Flip(){
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
