using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChar : MonoBehaviour {

    //キャラクターHP
    private int hp = 10000;

    [SerializeField]
    GameObject ogj;

    //バトルディレクター
    [SerializeField]
    GameObject dir;
    BattleDirector BtDir;
    //コライダーイベント
    ColliderEvent CEvent;

    //あたり判定群
    List<GameObject> col = new List<GameObject>();
    List<ColliderReact> react = new List<ColliderReact>();

    //操作キャラクター番号
    private int numID = 0;

    //のけぞり判定時間
    [SerializeField,Range(1,60)]
    private int time = 30;
    //経過時間
    private float timecCnt = 0;

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

        for (int i = 0; i < (int)BattleDirector.FightChar.CHARA_NUM; i++)
        {
            if (this.gameObject == BtDir.Fighter(i))
            {
                //操作番号決定
                numID = BtDir.FNumber(i);
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(ogj.name + " HP:" + hp);

        //キャラクター番号から相手キャラクターを判別
        switch(numID)
        {
            case (int)BattleDirector.FightChar.CHARA_1:
                hitJudg(1);
                break;
            case (int)BattleDirector.FightChar.CHARA_2:
                hitJudg(0);
                break;
            default:
                break;
        }

	}

    //攻撃ヒット判定
    private void hitJudg(int charNum)
    {
        //くらい判定の数
        for (int i = 0; i < CEvent.HClid.Count; i++)
        {
            //攻撃が当たっているなら
            if (react[i].hiting)
            {
                Debug.Log("あたり判定はしている！！！");
                Debug.Log(react[i].CObj.name);
                //技の数
                for (int j = 0; j < (int)BattleDirector.AtkVal.ATK_NUM; j++)
                {
                    //技の攻撃判定の数
                    for (int k = 0; k < BtDir.CCount(0, j); k++)
                    {
                        //攻撃の種類を判定
                        if (react[i].CObj.name == BtDir.Fcollider(charNum, j, k).name)
                        {
                            Debug.Log("ダメージを与えた！！！");
                            //判定した攻撃の威力分ダメージを受ける
                            hp -= BtDir.Fattack(0, j);
                            react[i].hiting = false;
                        }
                    }
                }
            }
            //のけぞり時間中ならあたり判定しない
            if (time >= timecCnt)
            {
                timecCnt += Time.deltaTime;
            }
            else if (time < timecCnt)
            {
                //のけぞり時間外になったらあたり判定する
                time = 0;
                react[i].CObj = null;
            }
        }
    }

    public GameObject obj(int colNum) { return react[colNum].CObj; }
}
