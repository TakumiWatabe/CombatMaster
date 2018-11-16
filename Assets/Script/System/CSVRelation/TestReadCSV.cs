using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestReadCSV : MonoBehaviour {

    private ReadCSV rc;
    private Dictionary<string, ReadCSV.CharaData> aoiData;

	// Use this for initialization
	void Start () {
        rc = GetComponent<ReadCSV>();

        aoiData = rc.readCSVData("AOI");

        Debug.Log(aoiData.Count);
        rc.WriteCharaDatas(aoiData, aoiData.Count);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
