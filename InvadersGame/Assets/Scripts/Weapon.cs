using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Weapon Class 
*/

public class Weapon : MonoBehaviour {
    [SerializeField]
    private GameObject bullet;
    Transform spawnPoint;
	// Use this for initialization
	void Start () {
		
	}


    public void Fire()
    {
        GameObject projectile = Instantiate(bullet, spawnPoint.position, Quaternion.identity) as GameObject;
        //projectile.get
    }
}
