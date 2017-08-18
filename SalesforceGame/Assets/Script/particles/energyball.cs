using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyball : MonoBehaviour {

    public float liveTime;

    private float explosionTime=0.2f;
    private Animator animator;

    private bool explosion = false;

    public GameObject explosionParticle;
    private GameObject expl;

    public float ExplosionTime = 1.7f;
    private bool finishing = false;
    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();
        expl = Instantiate(explosionParticle);
    }

    // Update is called once per frame
    void Update() {

        if (!explosion) {
            liveTime -= Time.deltaTime;

            animator.SetInteger("next", 2);

            if (liveTime < 0) {
                Destroy(expl);
                Destroy(this.gameObject);
            }
        } else {
            explosionTime -= Time.deltaTime;
            if (explosionTime < 0 && !finishing) {
                this.GetComponent<SpriteRenderer>().enabled = false;
                expl.gameObject.SetActive(true);
                finishing = true;

            } else { 
                ExplosionTime -= Time.deltaTime;
                if (ExplosionTime < 0) {
                    Destroy(expl);
                    Destroy(this.gameObject);
                }
            }

        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        //  if(coll.gameObject.tag == "Enemy")
        // isDead = true; //coll.gameObject.SendMessage("ApplyDamage", 10);
        if (coll.gameObject.tag == "Enemy") {
            GetComponent<Transform>().position = coll.transform.position;

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

            expl.transform.position = this.transform.position;
            explosion = true;

        }

        if(coll.gameObject.tag == "energyball" ) {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        }

    }
}
