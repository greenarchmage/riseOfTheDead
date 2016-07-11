using UnityEngine;
using System.Collections;
using Assets.Scripts.Utility;

public class Tower : MonoBehaviour {
    private GameObject projectile;

    public Player Owner { get; set; }

    // Attack speed in seconds
    private float attackSpeed = 0.5f;
    private float attackRange = 5;

    private float lastAttackTime = 0;

    private GameObject target;
	// Use this for initialization
	void Start () {
        //Test load
        projectile = Resources.Load("Prefabs/ProjectileTest") as GameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
        // If there is no target, get all units in and select the one which is closest to its target
        if(Time.time - lastAttackTime >= attackSpeed)
        {
            lastAttackTime = Time.time;
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);

            GameObject curTar = null;
            float curDist = float.MaxValue;
            for(int i = 0; i<hitColliders.Length; i++)
            {
                Collider2D col = hitColliders[i];
                if(col.gameObject.GetComponent<Unit>() != null)
                {
                    float tempdist = Vector3.Distance(col.transform.position, col.gameObject.GetComponent<Unit>().target.position);
                    if (tempdist < curDist)
                    {
                        curTar = col.gameObject;
                        curDist = tempdist;
                    }
                }
            }
            target = curTar;
            if (target != null)
            {
                GameObject obj = Instantiate(projectile, transform.position,Quaternion.identity) as GameObject;
                obj.GetComponent<Projectile>().target = target.transform;
                //target.GetComponent<Unit>().ChangeHitpoints(-damage);
            }
        }
	}
}
