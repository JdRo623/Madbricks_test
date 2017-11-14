using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private float timeToDeactivate;
    private float timePassed;
	// Use this for initialization
	void OnEnable () {
        timePassed = 0;
        timeToDeactivate = 3.5f;
	}
	
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;
        if (timePassed>=timeToDeactivate) {
            this.gameObject.SetActive(false);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Walls") {
            this.gameObject.SetActive(false);
        }
    }
}
