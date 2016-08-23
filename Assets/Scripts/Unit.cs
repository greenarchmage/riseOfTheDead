using UnityEngine;
using System.Collections;
using System;

public class Unit : MonoBehaviour {
    private float speed = 5f;
    public GameObject Target;

    private int maxHitpoints = 10;
    private int hitpoints = 10;

	// Use this for initialization
	void Start () {

	}
    
    // Update is called once per frame
    void Update () {
        float step = speed * Time.deltaTime;
        if (Target != null)
        {
            transform.position =  Vector3.MoveTowards(transform.position, Target.transform.position, step);
            transform.position.Set(transform.position.x, transform.position.y, 0);
        }
        if(Vector2.Distance( transform.position,Target.transform.position) < 0.1)
        {
            this.Target = Target.GetComponent<WayPoint>().Target;
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
