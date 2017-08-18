using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

    private float ExplosionTime = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ExplosionTime -= Time.deltaTime;
        if (ExplosionTime < 0) {
            Destroy(this.gameObject);
        }
    }
}
