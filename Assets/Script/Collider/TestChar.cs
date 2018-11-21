using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChar : MonoBehaviour {

    //攻撃ヒット時処理スクリプト

    //バトルディレクター
    //[SerializeField]
    GameObject dir;
    BattleDirector BtDir;
    //コライダーイベント
    ColliderEvent CEvent;
    //HPディレクター
    HPDirectorScript HPDir;

    //各種エフェクト
    [SerializeField]
    GameObject effectStr;
    [SerializeField]
    GameObject effectMid;
    [SerializeField]
    GameObject effectWeak;


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

    void Awake()
    {
        dir = GameObject.Find("BattleDirecter");
        BtDir = dir.GetComponent<BattleDirector>();
    }

    // Use this for initialization
    void Start()
    {
        //ディレクタースクリプト取得
        CEvent = this.GetComponent<ColliderEvent>();
        HPDir = this.GetComponent<HPDirectorScript>();

        //コライダーのスクリプトを取得
        for (int i = 0; i < CEvent.HClid.Count; i++)
        {
            col.Add(CEvent.HClid[i]);
            react.Add(col[i].GetComponent<ColliderReact>());
        }

        charcterJudg(this.gameObject.tag);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(this.transform.root.tag + " HP:" + HPDir.NowHPState);

        //キャラクター番号から相手キャラクターを判別
        switch (numID)
        {
            case (int)ValueScript.FightChar.CHARA_1:
                hitJudg(1);
                break;
            case (int)ValueScript.FightChar.CHARA_2:
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
                //技の数
                for (int j = 0; j < (int)ValueScript.AtkVal.ATK_NUM; j++)
                {
                    //技の攻撃判定の数
                    for (int k = 0; k < BtDir.CCount(0, j); k++)
                    {
                        //攻撃の種類を判定
                        if (react[i].CObj.name == BtDir.Fcollider(charNum, j, k).name)
                        {
                            Debug.Log("ダメージを与えた！！！");
                            //判定した攻撃の威力分ダメージを受ける
                            HPDir.hitDmage(BtDir.Fattack(0, j));
                            react[i].hiting = false;

                            Vector3 position = new Vector3(this.transform.parent.transform.position.x, this.transform.parent.transform.position.y, this.transform.parent.transform.position.z);

                            Vector3 body = GetComponent<ColliderEvent>().GetHitBoxs[i].center + this.transform.parent.transform.position;
                            Vector3 attack = new Vector3(0, 0, 0);
                            for (int l = 0; l < GetComponent<ColliderEvent>().AClid.Count; l++)
                            {
                                if (react[i].CObj.name == GetComponent<ColliderEvent>().GetAtkBoxs[l].name)
                                {
                                    Debug.Log(GetComponent<ColliderEvent>().GetAtkBoxs[l].name);
                                    attack = GetComponent<ColliderEvent>().GetAtkBoxs[l].center + this.transform.parent.transform.position;
                                }

                            }
                            //攻撃判定の場所
                            Vector3 pos1 = BtDir.Fcollider(charNum, j, k).GetComponent<Collider>().ClosestPointOnBounds(position);

                            //エフェクト発生場所
                            Vector3 effectPos = (body + attack) / 2;

                            //エフェクト発生
                            if (BtDir.Fattack(0, j) > 1000) Instantiate(effectStr, effectPos, Quaternion.identity);
                            else if (BtDir.Fattack(0, j) > 700) Instantiate(effectMid, effectPos, Quaternion.identity);
                            else if (BtDir.Fattack(0, j) <= 700) Instantiate(effectWeak, effectPos, Quaternion.identity);

                            GetComponent<PlayerController>().HitDamage(BtDir.Fattack(0, j));
                        }
                    }
                }
            }

            if (react[i].CObj != null)
            {
                //のけぞり時間中ならあたり判定しない
                if (time >= timecCnt)
                {
                    timecCnt++;
                }
                else if (time < timecCnt)
                {
                    //のけぞり時間外になったらあたり判定する
                    timecCnt = 0;
                    react[i].CObj = null;
                }
            }
        }
    }

    private void charcterJudg(string tagname)
    {
        if (tagname == "P1")
        {
            //操作番号決定
            numID = (int)ValueScript.FightChar.CHARA_1;
        }
        else if (tagname == "P2")
        {
            //操作番号決定
            numID = (int)ValueScript.FightChar.CHARA_2;
        }
    }
}
