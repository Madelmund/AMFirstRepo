using UnityEngine;
using System.Collections;

public class PlatformerMovementWithFeet : MonoBehaviour {

	// Use this for initialization
	public float moveSpeed = 1.0f;
	public float jumpSpeed = 1.0f;
	private bool grounded = false;
    public AudioClip jumpSound;
    void Start () {

	}

	// Update is called once per frame
	void Update () {
		var moveX = Input.GetAxis ("Horizontal");
		var velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
		velocity.x = moveX * moveSpeed;
		gameObject.GetComponent<Rigidbody2D> ().velocity = velocity;
		if (Input.GetButtonDown ("Jump") && grounded) {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(jumpSound);
            gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 100 * jumpSpeed));
		}
		GetComponent<Animator>().SetBool("grounded", grounded);
	}

	void OnTriggerExit2D(Collider2D collision){
		if (collision.gameObject.layer == 8) {
			grounded = false;
		}
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            grounded = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            grounded = true;
        }
    }
}
