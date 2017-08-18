using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldier : MonoBehaviour {

    private float curTime  ;
    private int currentWaypoint   = 0;
    private CharacterController character  ;
    private int direction;
    private Rigidbody2D rb;
    private float x= 0;
    private Animator animator;
    private bool turn = true;
    private int iterator = 0;
    
    public float speed=0.1f;

    public List<Transform> waypoint;       

    void Start () {
        //waypoint = new List<Transform>();
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

       // character = GetComponent<CharacterController>();
         
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.MoveTowards(transform.position, waypoint[iterator].transform.position, Time.deltaTime * speed);
     
    }

    void OnCollisionEnter2D(Collision2D coll) {
        //  if(coll.gameObject.tag == "Enemy")
        // isDead = true; //coll.gameObject.SendMessage("ApplyDamage", 10);

        if (coll.gameObject.tag == "energyball") {
            Destroy(this.gameObject);

        }
        if (coll.gameObject.tag == "Enemy") {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "wayPoint") {
            iterator++;
        }
        if (iterator==waypoint.Capacity) {
            iterator = 0;
        }
    }

  }
