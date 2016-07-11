using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    private float speed = 10f;
    public Transform target;

    private int damage = -5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        if(target == null)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.GetComponent<Unit>() != null && other.transform.GetInstanceID() == target.GetInstanceID())
        {
            other.transform.GetComponent<Unit>().ChangeHitpoints(damage);
            Destroy(gameObject);
        }
    }
}
