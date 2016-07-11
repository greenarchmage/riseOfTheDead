using UnityEngine;
using System.Collections;

public class EndTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //The unit enters the Endtarget
        Destroy(other.gameObject);
        GameController.Instance.ChangeScore(1);
    }
}
