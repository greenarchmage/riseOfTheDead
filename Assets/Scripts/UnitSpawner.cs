using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UnitSpawner : MonoBehaviour {

    private List<GameObject> units;

	// Use this for initialization
	void Start () {
        units = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	    for(int i= 0; i < units.Count; i++)
        {
            GameObject unit = Instantiate(units[i], transform.position, Quaternion.identity) as GameObject;
            //Should be changed to be the spawners target
            unit.GetComponent<Unit>().target = GameController.Instance.EndTarget.transform;
        }
        units.Clear();
	}

    public void AddUnit()
    {
        units.Add(Resources.Load("Prefabs/UnitMarker") as GameObject);
    }
}
