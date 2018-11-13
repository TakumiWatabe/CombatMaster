using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChar : MonoBehaviour {

    //キャラクターHP
    private int hp = 10000;

    //バトルディレクター
    [SerializeField]
    GameObject dir;
    BattleDirector BtDir;
    //コライダーイベント
    ColliderEvent CEvent;

    //あたり判定群
    List<GameObject> col = new List<GameObject>();
    List<ColliderReact> react = new List<ColliderReact>();

    // Use this for initialization
    void Start ()
    {
        //ディレクタースクリプト取得
        BtDir = dir.GetComponent<BattleDirector>();
        CEvent = this.GetComponent<ColliderEvent>();

        //コライダーのスクリプトを取得
        for (int i = 0; i < CEvent.HClid.Count; i++)
        {
            col.Add(CEvent.HClid[i]);
            react.Add(col[i].GetComponent<ColliderReact>());
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        //くらい判定の数
        for (int i = 0; i < CEvent.HClid.Count; i++)
        {
            //攻撃が当たっているなら
            if (react[i].hiting)
            {
                //技の数
                for (int j = 0; j < (int)BattleDirector.AtkVal.ATK_NUM; j++)
                {
                    //技の攻撃判定の数
                    for (int k = 0; k < BtDir.CCount(0, j); k++)
                    {
                        //攻撃の種類を判定
                        if (react[i].CObj.name == BtDir.Fcollider(0, j, k).name)
                        {
                            //判定した攻撃の威力分ダメージを受ける
                            hp -= BtDir.Fattack(0, j);
                            Debug.Log("ダメージを与えた！！！");
                        }
                    }
                }
                Debug.Log("オーバーソウル！！");
            }
        }
        Debug.Log(this.gameObject.name + " HP:" + hp);
	}
}
