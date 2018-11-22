using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {
    SceneManagement scene;
    FadeScript fade;
	// Use this for initialization
	void Start () {
        scene = this.GetComponent<SceneManagement>();
        fade = GameObject.Find("FadePanel").GetComponent<FadeScript>();
    }

    // Update is called once per frame
    void Update () {
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if(Input.anyKeyDown)
            {
                fade.FadeOutFlag();
                //scene.SceneChange("play");
            }
        }

    }
}
