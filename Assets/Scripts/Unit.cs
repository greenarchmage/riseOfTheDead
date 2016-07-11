using UnityEngine;
using System.Collections;
using System;

public class Unit : MonoBehaviour {
    private float speed = 5f;
    public Transform target;

    private int maxHitpoints = 10;
    private int hitpoints = 10;

	// Use this for initialization
	void Start () {

	}
    
    // Update is called once per frame
    void Update () {
        float step = speed * Time.deltaTime;
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    public void ChangeHitpoints(int amount)
    {
        hitpoints += amount;
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
        if (hitpoints > maxHitpoints)
        {
            hitpoints = maxHitpoints;
        }
    }
}
