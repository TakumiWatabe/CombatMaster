using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChar : MonoBehaviour {

    //キャラクターHP
    private int hp = 10000;

    //攻撃接触判定
    private bool hit = false;
    //攻撃判定オブジェクト
    private GameObject collid;

    //バトルディレクター
    [SerializeField]
    private GameObject dir;
    private GameDirector GameDir;

    //あたり判定に当たったら
    void OnTriggerEnter(Collider other)
    {
        //攻撃未接触＆判定が攻撃なら
        if (!hit && other.gameObject.tag == "Attack")
        {
            //攻撃がヒット
            hit = true;
            //攻撃判定を記憶
            collid = other.gameObject;
        }
    }

    // Use this for initialization
    void Start ()
    {
        GameDir = dir.GetComponent<GameDirector>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(hit)
        {

        }
	}
}
