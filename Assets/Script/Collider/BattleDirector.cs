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
    private struct FightState
    {
        GameObject collider;
        int attack;
    };

    //キャラクターオブジェクト
    [SerializeField]
    private List<GameObject> character;

    private ColliderEvent CEvent;
    //private HikariEvent HEvent;

    //アクションステータス
    private FightState[,] fight = new FightState[(int)FightChar.CHARA_NUM, (int)AtkVal.ATK_NUM];

    // Use this for initialization
    void Start ()
    {
        CEvent = character[(int)FightChar.CHARA_1].GetComponent<ColliderEvent>();
        //HEvent = character[(int)FightChar.CHARA_2].GetComponent<HikariEvent>();

        for (int i = 0; i < CEvent.AClid.Count; i++)
        {
            //fight[(int)FightChar.CHARA_1][]
            //switch(i)
            //{
            //    case:
            //}
        }
	}
	
}
