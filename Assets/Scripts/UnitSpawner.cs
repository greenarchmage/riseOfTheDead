using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Assets.Scripts.Units;

public class UnitSpawner : MonoBehaviour {
    public GameObject Target;

    private float spawnInitialTime;
    private List<UnitDelayPair> spawnerUnits;

	// Use this for initialization
	void Start () {
        spawnerUnits = new List<UnitDelayPair>();
	}
	
	// Update is called once per frame
	void Update () {
        List<int> unitsToRemove = new List<int>();
        for(int i = 0; i<spawnerUnits.Count; i++)
        {
            if(Time.time > spawnInitialTime + spawnerUnits[i].Delay)
            {
                GameObject unit = Instantiate(Resources.Load("Prefabs/UnitTemplate") as GameObject, transform.position, Quaternion.identity) as GameObject;
                unit.GetComponent<Unit>().SetStats(spawnerUnits[i].Unit);
                unit.GetComponent<Unit>().Target = Target;
                unitsToRemove.Add(i);
            }
        }
        for(int i = 0; i<unitsToRemove.Count;i++)
        {
            spawnerUnits.RemoveAt(unitsToRemove[i]);
        }
	}

    public void AddUnit(List<UnitDelayPair> unitsStats)
    {
        spawnerUnits = unitsStats;
        spawnInitialTime = Time.time;
    }
}
