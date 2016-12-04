using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float JumpPower;

	private bool isGrounded = false;

	private Rigidbody2D RB;

	// Use this for initialization
	void Start () {
		RB = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true) {
			RB.AddForce (new Vector2(0,JumpPower));
			isGrounded = false;
		}
	}

	//void FixedUpdate(){
	//}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("Ground")) {
			isGrounded = true;
		}
	}
}
