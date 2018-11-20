using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceScript : MonoBehaviour {

    [SerializeField]
    private string player1, player2;

    [SerializeField]
    private List<GameObject> charcter;

    private GameObject[] fighter = new GameObject[2];
    private List<string> ID = new List<string>()
    {
        {"Aoi" },
        {"Hikari" }
    };

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
