using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    
    public GameObject particle_shoot;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public bool isGrounded;
    public float jumpForce;
    public float speed;
    Rigidbody2D rb;

    private GameObject child;

    private bool jump = false;

    private Animator animator;

    public float offsetShoot=0;

    private float oldX=0;

    private float x = 0;
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        isGrounded = true;

    }
	
	// Update is called once per frame zas
	void Update () {

        if (Input.GetButtonDown("Jump") && isGrounded ) { // isGrounded
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            
        }

        if (Input.GetButtonDown("Fire1") ) { 

            GameObject shoot= Instantiate(particle_shoot);

            Vector2 position = new Vector3(transform.position.x + offsetShoot, transform.position.y + 0, 3f);

            shoot.GetComponent<Transform>().position = position;

            if (animator.GetInteger("Direction")==1)
                shoot.GetComponent<Rigidbody2D>().AddForce(Vector2.right * jumpForce*-1, ForceMode2D.Impulse);
            if (animator.GetInteger("Direction") == 2)
                shoot.GetComponent<Rigidbody2D>().AddForce(Vector2.right * jumpForce, ForceMode2D.Impulse);


            Physics2D.IgnoreCollision(shoot.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }

    void FixedUpdate() {
         x = Input.GetAxis("Horizontal");

     
            
            if (x < 0f) {
                animator.SetInteger("Direction", 1);
            } else if (x > 0f) {
                animator.SetInteger("Direction", 2);
        } 
        


        Vector3 move = new Vector3(x * speed, rb.velocity.y, 0f);
        rb.velocity = move;

    }

    void OnCollisionEnter2D(Collision2D coll) {
        //  if(coll.gameObject.tag == "Enemy")
        // isDead = true; //coll.gameObject.SendMessage("ApplyDamage", 10);
        if (coll.gameObject.layer == 8 ) {
            isGrounded = true;
        }

        if (coll.gameObject.tag == "ignore") {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }

   

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "plataform") {
            Physics2D.IgnoreCollision(coll.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag == "plataform") {
            Physics2D.IgnoreCollision(coll.GetComponent<Collider2D>(), GetComponent<Collider2D>(),false);
        }
    }
}
