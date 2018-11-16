using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDirector : MonoBehaviour {

    //キャラクター用変数
    public enum FightChar
    {
        CHARA_1,
        CHARA_2,

        CHARA_NUM,
    };

    //アクション用変数
    public enum AtkVal
    {
        PUNCH,
        KICK,
        PUNCH_SIT,
        KICK_SIT,
        PUNCH_JUMP,
        KICK_JUMP,
        HADOUKEN,
        SYORYUKEN,

        ATK_NUM,
    };

    //アクションステータス
    private struct FS
    {
        //攻撃判定
        public List<GameObject> co;
        //攻撃力
        public int ac;

        //初期化関数
        public void Reset() { co = new List<GameObject>(); }
    };

    //操作キャラクター判別用
    private struct FightPlayer
    {
        //操作キャラクター
        public GameObject fightCharacter;
        //キャラクターID
        public int playNumber;
    };

    //キャラクターオブジェクト
    [SerializeField]
    private List<GameObject> character;
    private const int act = 10;

    //キャラクタースクリプト
    private ColliderEvent[] CEvent = new ColliderEvent[2];

    //アクションステータス
    private FS[,] f = new FS[(int)FightChar.CHARA_NUM, (int)AtkVal.ATK_NUM];
    //アクションステータス
    private int[,] atk = new int[(int)FightChar.CHARA_NUM, (int)AtkVal.ATK_NUM];
    //キャラクターステータス
    private FightPlayer[] fp = new FightPlayer[(int)FightChar.CHARA_NUM];

    // Use this for initialization
    void Start ()
    {
        RevolvingStake(atk);

        //スクリプト取得
        //Aoi
        CEvent[0] = character[(int)FightChar.CHARA_1].GetComponent<ColliderEvent>();
        //Hikari
        CEvent[1] = character[(int)FightChar.CHARA_2].GetComponent<ColliderEvent>();

        //配列を使うために初期化を行う
        for(int i=0;i<(int)FightChar.CHARA_NUM;i++)
        {
            for(int j=0;j<(int)AtkVal.ATK_NUM;j++)
            {
                f[i, j].Reset();
            }
        }

        //技ごとの攻撃判定設定
        Burger();
        for (int i=0;i<(int)FightChar.CHARA_NUM;i++)
        {
            for(int j=0;j<(int)AtkVal.ATK_NUM;j++)
            {
                //威力設定
                f[i, j].ac = atk[i, j];
            }
        }

        //キャラクターセレクトからキャラクターを取得
        fp[(int)FightChar.CHARA_1].fightCharacter = character[(int)FightChar.CHARA_1];
        fp[(int)FightChar.CHARA_1].playNumber = (int)FightChar.CHARA_1;
        fp[(int)FightChar.CHARA_2].fightCharacter = character[(int)FightChar.CHARA_2];
        fp[(int)FightChar.CHARA_2].playNumber = (int)FightChar.CHARA_2; 
    }

    //攻撃を設定する関数
    private void RevolvingStake(int[,] at)
    {
        for (int i = 0; i < (int)FightChar.CHARA_NUM; i++)
        {
            at[i, (int)AtkVal.PUNCH] = 500;
            at[i, (int)AtkVal.KICK] = 1000;
            at[i, (int)AtkVal.PUNCH_SIT] = 800;
            at[i, (int)AtkVal.KICK_SIT] = 1200;
            at[i, (int)AtkVal.PUNCH_JUMP] = 700;
            at[i, (int)AtkVal.KICK_JUMP] = 900;
            at[i, (int)AtkVal.HADOUKEN] = 1100;
            at[i, (int)AtkVal.SYORYUKEN] = 1500;
        }
    }

    //あたり判定の判別変数設定関数
    private void Burger()
    {
        //実験
        //キャラの数
        for (int i = 0; i < (int)FightChar.CHARA_NUM; i++)
        {
            //攻撃技の数
            for (int j = 0; j < (int)AtkVal.ATK_NUM; j++)
            {
                //全攻撃判定の数
                for (int k = 0; k < CEvent[i].AClid.Count; k++)
                {
                    //攻撃判定のレイヤーが一致しているなら
                    if (CEvent[i].AClid[k].layer == j + act)
                    {
                        f[i, j].co.Add(CEvent[i].AClid[k]);
                    }
                }
            }
        }
    }

    public GameObject Fcollider(int ft, int at,int num) { return f[ft, at].co[num]; }
    public int Fattack(int ft, int at) { return f[ft, at].ac; }
    public int CCount(int ft, int at) { return f[ft, at].co.Count; }
    public GameObject Fighter(int ft) { return fp[ft].fightCharacter; }
    public int FNumber(int ft) { return fp[ft].playNumber; }
}
