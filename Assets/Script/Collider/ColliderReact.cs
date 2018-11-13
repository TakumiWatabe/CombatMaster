using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderReact : MonoBehaviour {

    //あたり判定のタグ名
    private string colliderTag;

    //攻撃接触判定
    private bool hitAtk = false;
    //攻撃判定オブジェクト
    private GameObject collid;

    //あたり判定に当たったら
    void OnTriggerEnter(Collider other)
    {
        //くらい判定なら
        if (colliderTag == "Hit")
        {
            //攻撃未接触＆判定が攻撃なら
            if (!hitAtk && other.gameObject.tag == "Attack")
            {
                //攻撃がヒット
                hitAtk = true;
                //攻撃判定を記憶
                collid = other.gameObject;
            }
        }
        //それ以外なら
        else
        {
            //処理を終了
            return;
        }
    }

    void Awake()
    {
        colliderTag = this.gameObject.tag;
    }

    //衝突判定取得
    public bool hiting
    {
        set { hitAtk = value; }
        get { return hitAtk; }
    }
    public GameObject CObj
    {
        set { collid = value; }
        get { return collid; }
    }
}
