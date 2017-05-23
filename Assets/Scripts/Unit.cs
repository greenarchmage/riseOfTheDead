using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts.Units;

public class Unit : MonoBehaviour {
    public GameObject Target;
    public string UnitName {get;set;}

    private int maxHitpoints;
    private float speed;
    private int currentHitpoints = 10;

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
        currentHitpoints += amount;
        if (currentHitpoints <= 0)
        {
            Destroy(gameObject);
        }
        if (currentHitpoints > maxHitpoints)
        {
            currentHitpoints = maxHitpoints;
        }
    }

    public void SetStats(UnitStats unitStats)
    {
        maxHitpoints = unitStats.Hitpoints;
        currentHitpoints = unitStats.Hitpoints;
        speed = unitStats.Speed;
        UnitName = unitStats.UnitName;
    }
}
