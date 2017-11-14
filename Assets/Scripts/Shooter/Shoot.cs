using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    private GameObject bullet;
    public float bulletSpeed;
    private float timePassed;
    public float timeBTWShoots;
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;
        if ( timePassed>=timeBTWShoots) {
            ShootBullet();
        }
	}

    void ShootBullet() {
        timePassed = 0;
        bullet = BulletsPool.current.GetPulledObject();
        bullet.transform.position=this.transform.position;
        bullet.transform.rotation = this.transform.rotation;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed*Time.deltaTime;
        bullet.SetActive(true);
    }
}
