using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChar : MonoBehaviour {

    //攻撃ヒット時処理スクリプト

    [SerializeField]
    GameObject ogj;

    [SerializeField]
    GameObject effectStr;
    [SerializeField]
    GameObject effectMid;
    [SerializeField]
    GameObject effectWeak;

    //バトルディレクター
    [SerializeField]
    GameObject dir;
    BattleDirector BtDir;
    //コライダーイベント
    ColliderEvent CEvent;
    //HPディレクター
    HPDirectorScript HPDir;

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
    void Start()
    {
        //ディレクタースクリプト取得
        BtDir = dir.GetComponent<BattleDirector>();
        CEvent = this.GetComponent<ColliderEvent>();
        HPDir = this.GetComponent<HPDirectorScript>();

        //コライダーのスクリプトを取得
        for (int i = 0; i < CEvent.HClid.Count; i++)
        {
            col.Add(CEvent.HClid[i]);
            react.Add(col[i].GetComponent<ColliderReact>());
        }

        charcterJudg(this.gameObject.tag);

        //effect.Stop();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(ogj.name + " HP:" + HPDir.NowHPState);
        //Debug.Log(numID);

        //キャラクター番号から相手キャラクターを判別
        switch (numID)
        {
            case (int)BattleDirector.FightChar.CHARA_1:
                hitJudg((int)BattleDirector.FightChar.CHARA_2);
                break;
            case (int)BattleDirector.FightChar.CHARA_2:
                hitJudg((int)BattleDirector.FightChar.CHARA_1);
                break;
            default:
                break;
        }

	}

    //攻撃ヒット判定
    private void hitJudg(int charNum)
    {
        //デバック用(できれば消せない)
        ////技の攻撃判定の数
        //for (int k = 0; k < BtDir.CCount(0, 0); k++)
        //{
        //    Debug.Log(BtDir.Fcollider(charNum, 0, k).name);
        //}
        //for (int k = 0; k < BtDir.CCount(0, 1); k++)
        //{
        //    Debug.Log(BtDir.Fcollider(charNum, 1, k).name);
        //}
        //for (int k = 0; k < BtDir.CCount(0, 2); k++)
        //{
        //    Debug.Log(BtDir.Fcollider(charNum, 2, k).name);
        //}
        //for (int k = 0; k < BtDir.CCount(0, 3); k++)
        //{
        //    Debug.Log(BtDir.Fcollider(charNum, 3, k).name);
        //}
        //for (int k = 0; k < BtDir.CCount(0, 4); k++)
        //{
        //    Debug.Log(BtDir.Fcollider(charNum, 4, k).name);
        //}
        //for (int k = 0; k < BtDir.CCount(0, 5); k++)
        //{
        //    Debug.Log(BtDir.Fcollider(charNum, 5, k).name);
        //}
        //for (int k = 0; k < BtDir.CCount(0, 6); k++)
        //{
        //    Debug.Log(BtDir.Fcollider(charNum, 6, k).name);
        //}
        //for (int k = 0; k < BtDir.CCount(0, 7); k++)
        //{
        //    Debug.Log(BtDir.Fcollider(charNum, 7, k).name);
        //}

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
                            HPDir.hitDmage(BtDir.Fattack(0, j));
                            react[i].hiting = false;

                            //Vector3 p = new Vector3(this.transform.parent.transform.position.x , Mathf.Abs(transform.position.y), transform.position.z);
                            Vector3 p = new Vector3(this.transform.parent.transform.position.x, this.transform.parent.transform.position.y, this.transform.parent.transform.position.z);

                            
                            Vector3 fi = GetComponent<ColliderEvent>().GetHitBoxs[i].center + this.transform.parent.transform.position;
                            Vector3 oo = new Vector3(0,0,0);
                            for (int l = 0; l < GetComponent<ColliderEvent>().AClid.Count; l++)
                            {
                                if (react[i].CObj.name == GetComponent<ColliderEvent>().GetAtkBoxs[l].name)
                                {
                                    Debug.Log(GetComponent<ColliderEvent>().GetAtkBoxs[l].name);
                                    oo = GetComponent<ColliderEvent>().GetAtkBoxs[l].center + this.transform.parent.transform.position;
                                }
                                //if (react[i].CObj == BtDir.Fcollider(charNum, j, k).GetComponent<ColliderEvent>().GetAtkBoxs[l])
                                //{
                                //    oo = BtDir.Fcollider(charNum, j, k).GetComponent<ColliderEvent>().GetAtkBoxs[l].center;
                                //}

                            }

                            Debug.DrawLine(fi, oo, Color.cyan,10);
                            //攻撃判定の場所
                            Vector3 pos1 = BtDir.Fcollider(charNum, j, k).GetComponent<Collider>().ClosestPointOnBounds(p);
                            //Debug.DrawLine(BtDir.Fcollider(charNum, j, k).GetComponent<Collider>()., BtDir.Fcollider(charNum, j, k).GetComponent<Collider>().ClosestPointOnBounds(p), Color.cyan, Vector3.Distance(BtDir.Fcollider(charNum, j, k).GetComponent<Collider>().transform.position, BtDir.Fcollider(charNum, j, k).GetComponent<Collider>().ClosestPointOnBounds(p)));
                            //エフェクト発生場所
                            Vector3 effectPos = (fi + oo) / 2;

                            //Debug.Log("今のは" + effectPos);
                            //Debug.Log("今のcharNumは" + charNum);
                            //Debug.Log("今の攻撃コライダーは" + BtDir.Fcollider(charNum, j, k).GetComponent<Collider>());
                            //Debug.Log("今当たったコライダーは" + this.transform.position);
                            //Debug.Log("positionしてるボケは" + this.transform.name + "、そのクソ親は" + this.transform.parent.name);
                            //Debug.Log("くそう" + this.transform.parent.transform.position);

                            //エフェクト発生
                            //Instantiate(effect, effectPos, Quaternion.identity);

                            if (BtDir.Fattack(0, j) > 1000)  Instantiate(effectStr, effectPos, Quaternion.identity);
                            else if (BtDir.Fattack(0, j) > 700) Instantiate(effectMid, effectPos, Quaternion.identity);
                            else if (BtDir.Fattack(0, j) <= 700) Instantiate(effectWeak, effectPos, Quaternion.identity);


                            //GameObject eff = Instantiate(effect, effectPos, Quaternion.identity) as GameObject;


                                //effect = this.GetComponent<ParticleSystem>();

                                //effect.Play();

                                //effect.Stop();

                                //Destroy(effect.gameObject);


                            GetComponent<PlayerController>().HitDamage(BtDir.Fattack(0, j));

                            //Destroy(eff);

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

    private void charcterJudg(string tagname)
    {
        if (tagname == "P1")
        {
            //操作番号決定
            numID = (int)BattleDirector.FightChar.CHARA_1;
        }
        else if (tagname == "P2")
        {
            //操作番号決定
            numID = (int)BattleDirector.FightChar.CHARA_2;
        }
    }
}
