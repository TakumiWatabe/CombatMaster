using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HikariEvent : MonoBehaviour {

    //--------------------------------------
    //あたり判定設定
    //--------------------------------------

    //くらい判定
    [SerializeField]
    private List<GameObject> HitCollider;
    //攻撃判定
    [SerializeField]
    private List<GameObject> AtkCollider;
    //押し合い判定
    [SerializeField]
    private List<GameObject> PushCollider;

    //コライダー
    BoxCollider HitBox;
    BoxCollider AtkBox;
    BoxCollider PushBox;

    //あたり判定の数
    int HCnum;
    int ACnum;
    int PCnum;

    private const float CSizeZ = 0.25f;

    // Use this for initialization
    void Start()
    {
        //あたり判定の数
        HCnum = HitCollider.Count;
        ACnum = AtkCollider.Count;
        PCnum = PushCollider.Count;
    }

    //-------------------------------------------------------
    //基本あたり判定
    //
    //使用モーション:立ち、前進、後進、立ちガード、ダメージ
    //-------------------------------------------------------
    void BasicCollide()
    {
        //くらい判定初期化
        HitColliderActive();

        //基本くらい判定
        HitCollider[0].SetActive(true);

        //攻撃判定初期化
        AtkColliderActive();
    }

    //------------------------------------------------------
    //基本しゃがみあたり判定
    //
    //使用モーション:しゃがみ、しゃがみガード、しゃがみダメ
    //------------------------------------------------------
    void BasicSitCollide()
    {
        //くらい判定初期化
        HitColliderActive();

        //基本しゃがみ判定
        HitCollider[1].SetActive(true);

        //攻撃判定初期化
        AtkColliderActive();
    }

    //--------------------------------
    //ダッシュあたり判定
    //
    //使用モーション:ダッシュ
    //--------------------------------
    void BasicDashCollider1()
    {
        //くらい判定初期化
        HitColliderActive();

        HitCollider[2].SetActive(true);
        HitBox = HitCollider[2].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.78f, 0.1f),
            new Vector3(0.25f, 1.55f, 0.65f));

        //攻撃判定初期化
        AtkColliderActive();
    }
    void BasicDashCollider2()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 0.78f, -0.05f),
            new Vector3(0.25f, 1.55f, 0.8f));

        HitCollider[3].SetActive(true);
        HitBox = HitCollider[3].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.95f, 0.45f),
            new Vector3(0.25f, 0.35f, 0.5f));
    }
    void BasicDashCollider3()
    {
        HitCollider[2].SetActive(true);
        HitBox = HitCollider[2].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.25f, 0.1f),
            new Vector3(0.25f, 0.55f, 0.7f));

        HitCollider[3].SetActive(true);
        HitBox = HitCollider[3].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.55f, 0),
            new Vector3(0.25f, 0.85f, 1.4f));

    }
    void BasicDashCollider4()
    {
        HitCollider[2].SetActive(true);
        HitBox = HitCollider[2].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.1f, 0.1f),
            new Vector3(0.25f, 0.8f, 0.75f));

        HitCollider[3].SetActive(true);
        HitBox = HitCollider[3].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.45f, 0),
            new Vector3(0.25f, 0.6f, 1.6f));

    }
    void BasicDashCollider5()
    {
        HitCollider[2].SetActive(true);
        HitBox = HitCollider[2].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.1f, 0.1f),
            new Vector3(0.25f, 0.8f, 0.7f));

        HitCollider[3].SetActive(true);
        HitBox = HitCollider[3].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.4f, 0),
            new Vector3(0.25f, 0.75f, 1.35f));

    }
    void BasicDashCollider6()
    {
        HitCollider[2].SetActive(true);
        HitBox = HitCollider[2].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.05f, 0.2f),
            new Vector3(0.25f, 0.9f, 0.6f));

        HitCollider[3].SetActive(true);
        HitBox = HitCollider[3].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.35f, 0),
            new Vector3(0.25f, 0.75f, 0.9f));

    }
    void BasicDashCollider7()
    {
        HitCollider[2].SetActive(true);
        HitBox = HitCollider[2].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.05f, 0.15f),
            new Vector3(0.25f, 0.9f, 0.7f));

        HitCollider[3].SetActive(true);
        HitBox = HitCollider[3].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.35f, 0.05f),
            new Vector3(0.25f, 0.75f, 0.65f));

    }
    void BasicDashCollider8()
    {
        HitCollider[2].SetActive(true);
        HitBox = HitCollider[2].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.1f, 0.2f),
            new Vector3(0.25f, 0.85f, 0.8f));

        HitCollider[3].SetActive(true);
        HitBox = HitCollider[3].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.38f, 0f),
            new Vector3(0.25f, 0.75f, 0.9f));

    }
    void BasicDashCollider9()
    {
        HitCollider[2].SetActive(true);
        HitBox = HitCollider[2].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.15f, 0.2f),
            new Vector3(0.25f, 0.7f, 0.9f));

        HitCollider[3].SetActive(true);
        HitBox = HitCollider[3].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.45f, 0.05f),
            new Vector3(0.25f, 0.8f, 1.5f));

    }
    void BasicDashCollider10()
    {
        HitCollider[2].SetActive(true);
        HitBox = HitCollider[2].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.1f, 0.15f),
            new Vector3(0.25f, 0.8f, 0.65f));

        HitCollider[3].SetActive(true);
        HitBox = HitCollider[3].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.4f, 0.05f),
            new Vector3(0.25f, 0.8f, 0.9f));

    }
    void BasicDashCollider11()
    {
        HitCollider[2].SetActive(true);
        HitBox = HitCollider[2].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.1f, 0.15f),
            new Vector3(0.25f, 0.8f, 0.6f));

        HitCollider[3].SetActive(true);
        HitBox = HitCollider[3].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.4f, 0),
            new Vector3(0.25f, 0.8f, 0.6f));
    }

    //--------------------------------
    //波動コマンドあたり判定
    //
    //使用モーション:波動
    //--------------------------------
    void BasicHadouCollider1()
    {
        HitCollider[4].SetActive(true);
        HitBox = HitCollider[4].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.1f, 0.4f),
            new Vector3(0.25f, 0.3f, 0.5f));
    }
    void BasicHadouCollider2()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 1.2f, 0.4f),
            new Vector3(0.25f, 0.3f, 0.55f));

        AtkCollider[0].SetActive(true);
    }
    void BasicHadouCollider3()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 1f, 0.4f),
            new Vector3(0.25f, 0.3f, 0.3f));

        AtkColliderActive();
    }

    //-----------------------------------------
    //ジャンプあたり判定
    //
    //使用モーション:ジャンプ、ジャンプ中
    //-----------------------------------------
    void BasicJumpCollide1()
    {
        HitColliderActive();

        HitCollider[5].SetActive(true);
        HitBox = HitCollider[5].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.3f, 0),
            new Vector3(0.25f, 0.55f, 0.8f));

        HitCollider[6].SetActive(true);
        HitBox = HitCollider[6].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.6f, 0.05f),
            new Vector3(0.25f, 0.9f, 0.6f));

        AtkColliderActive();
    }
    void BasicJumpCollide2()
    {
        HitBox = HitCollider[5].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.25f, 0),
            new Vector3(0.25f, 0.65f, 0.8f));

        HitBox = HitCollider[6].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.45f, 0),
            new Vector3(0.25f, 1.1f, 0.45f));
    }

    //--------------------------------
    //ジャンプキックあたり判定
    //
    //使用モーション:ジャンプキック
    //--------------------------------
    void JumpKickCollider1()
    {
        HitColliderActive();

        HitCollider[7].SetActive(true);
        HitBox = HitCollider[7].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.25f, 0),
            new Vector3(0.25f, 0.65f, 0.8f));

        HitCollider[8].SetActive(true);
        HitBox = HitCollider[8].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.45f, 0),
            new Vector3(0.25f, 1.1f, 0.45f));

        AtkColliderActive();
    }
    void JumpKickCollider2()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 0.55f, 0.15f),
            new Vector3(0.25f, 0.8f, 0.75f));
    }
    void JumpKickCollider3()
    {
        HitBox = HitCollider[7].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.25f, 0.05f),
            new Vector3(0.25f, 0.65f, 0.85f));

        HitBox = HitCollider[8].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.7f, 0.15f),
            new Vector3(0.25f, 0.6f, 0.8f));
    }
    void JumpKickCollider4()
    {
        HitBox = HitCollider[7].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.25f, -0.05f),
            new Vector3(0.25f, 0.6f, 0.65f));

        HitBox = HitCollider[8].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.75f, 0.25f),
            new Vector3(0.25f, 0.55f, 1));
    }
    void JumpKickCollider5()
    {
        HitBox = HitCollider[7].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.22f, 0),
            new Vector3(0.25f, 0.65f, 0.7f));

        HitBox = HitCollider[8].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.7f, 0.3f),
            new Vector3(0.25f, 0.5f, 1.15f));

        AtkCollider[1].SetActive(true);
    }
    void JumpKickCollider6()
    {
        HitBox = HitCollider[7].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.25f, 0),
            new Vector3(0.25f, 0.65f, 0.65f));

        HitBox = HitCollider[8].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.6f, 0.15f),
            new Vector3(0.25f, 0.75f, 0.9f));

        AtkColliderActive();
    }
    void JumpKickCollider7()
    {
        HitBox = HitCollider[7].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.3f, -0.05f),
            new Vector3(0.25f, 0.55f, 0.6f));

        HitBox = HitCollider[8].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.6f, 0.1f),
            new Vector3(0.25f, 1, 0.8f));
    }
    void JumpKickCollider8()
    {
        HitBox = HitCollider[7].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.3f, -0.08f),
            new Vector3(0.25f, 0.55f, 0.65f));

        HitBox = HitCollider[8].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.55f, 0.1f),
            new Vector3(0.25f, 1.1f, 0.7f));
    }
    void JumpKickCollider9()
    {
        HitBox = HitCollider[7].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.25f, 0),
            new Vector3(0.25f, 0.65f, 0.85f));

        HitBox = HitCollider[8].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.48f, 0.05f),
            new Vector3(0.25f, 1.1f, 0.5f));
    }
    void JumpKickCollider10()
    {
        HitBox = HitCollider[7].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.25f, 0),
            new Vector3(0.25f, 0.65f, 0.8f));

        HitBox = HitCollider[8].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.48f, 0.05f),
            new Vector3(0.25f, 1.1f, 0.5f));
    }

    //--------------------------------
    //ジャンプパンチあたり判定
    //
    //使用モーション:ジャンプパンチ
    //--------------------------------
    void JumpPunchCollider1()
    {
        HitColliderActive();

        HitCollider[9].SetActive(true);
        HitBox = HitCollider[9].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.25f, 0),
            new Vector3(0.25f, 0.65f, 0.8f));

        HitCollider[10].SetActive(true);
        HitBox = HitCollider[10].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.45f, 0),
            new Vector3(0.25f, 1.1f, 0.45f));

        AtkColliderActive();
    }
    void JumpPunchCollider2()
    {
        HitBox = HitCollider[9].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.25f, 0.05f),
            new Vector3(0.25f, 0.65f, 0.7f));

        HitBox = HitCollider[10].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.6f, 0),
            new Vector3(0.25f, 0.8f, 0.55f));
    }
    void JumpPunchCollider3()
    {
        HitBox = HitCollider[10].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.65f, 0),
            new Vector3(0.25f, 0.7f, 0.55f));
    }
    void JumpPunchCollider4()
    {
        AtkCollider[2].SetActive(true);
    }
    void JumpPunchCollider5()
    {
        HitBox = HitCollider[9].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.25f, 0.05f),
            new Vector3(0.25f, 0.6f, 0.7f));

        HitBox = HitCollider[10].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.6f, 0),
            new Vector3(0.25f, 0.85f, 0.55f));

        AtkColliderActive();
    }

    //--------------------------------------
    //しゃがみ中あたり判定
    //
    //使用モーション:しゃがみ中
    //--------------------------------------
    void SitingCollider1()
    {
        HitColliderActive();

        HitCollider[11].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.78f, 0),
            new Vector3(0.25f, 1.65f, 0.65f));

        AtkColliderActive();
    }
    void SitingCollider2()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 1.18f, 0),
            new Vector3(0.25f, 1.2f, 0.65f));
    }

    //--------------------------------
    //しゃがみキックあたり判定
    //
    //使用モーション:しゃがみキック
    //--------------------------------
    void SitKickCollider1()
    {
        HitColliderActive();

        HitCollider[12].SetActive(true);
        HitBox = HitCollider[12].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1f, 0),
            new Vector3(0.25f, 1.1f, 0.6f));

        AtkColliderActive();
    }
    void SitKickCollider2()
    {
        HitBox = HitCollider[12].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1f, 0),
            new Vector3(0.25f, 1f, 0.6f));

    }
    void SitKickCollider3()
    {
        HitBox = HitCollider[12].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1f, 0),
            new Vector3(0.25f, 0.95f, 0.6f));

        HitCollider[13].SetActive(true);
        HitBox = HitCollider[13].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.7f, 0.3f),
            new Vector3(0.25f, 0.35f, 0.35f));

        AtkCollider[3].SetActive(true);
    }
    void SitKickCollider4()
    {
        HitBox = HitCollider[12].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.15f, -0.15f),
            new Vector3(0.25f, 0.7f, 0.5f));

        HitBox = HitCollider[13].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.7f, 0f),
            new Vector3(0.25f, 0.4f, 0.8f));

        AtkColliderActive();
    }

    //--------------------------------
    //しゃがみパンチあたり判定
    //
    //使用モーション:しゃがみパンチ
    //--------------------------------
    void SitPunchCollider1()
    {
        HitColliderActive();

        HitCollider[14].SetActive(true);
        HitBox = HitCollider[14].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1f, 0),
            new Vector3(0.25f, 1.1f, 0.6f));

        AtkColliderActive();
    }
    void SitPunchCollider2()
    {
        HitCollider[15].SetActive(true);
        HitBox = HitCollider[15].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.1f, 0.4f),
            new Vector3(0.25f, 0.45f, 0.6f));

        AtkCollider[4].SetActive(true);
    }

    //-----------------------------------------
    //立ち上がりあたり判定
    //
    //使用モーション:立ち上がり
    //-----------------------------------------
    void StandUpCollider1()
    {
        HitColliderActive();

        HitCollider[16].SetActive(true);
        HitBox = HitCollider[16].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.18f, 0),
            new Vector3(0.25f, 1.15f, 0.6f));

        AtkColliderActive();
    }
    void StandUpCollider2()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 1.1f, 0),
            new Vector3(0.25f, 1.3f, 0.65f));
    }
    void StandUpCollider3()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 0.95f, 0),
            new Vector3(0.25f, 1.65f, 0.65f));
    }

    //------------------
    //強攻撃あたり判定
    //
    //使用モーション:強攻撃
    //------------------
    void BaseKickCollider1()
    {
        HitColliderActive();

        HitCollider[17].SetActive(true);
        HitBox = HitCollider[17].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.85f, 0f),
            new Vector3(0.25f, 1.4f, 0.65f));

        AtkColliderActive();
    }
    void BaseKickCollider2()
    {
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.15f, 0.1f),
            new Vector3(0.25f, 0.7f, 0.55f));

        HitCollider[18].SetActive(true);
        HitBox = HitCollider[18].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.5f, 0f),
            new Vector3(0.25f, 0.65f, 0.85f));
    }

    void BaseKickCollider3()
    {
        HitBox = HitCollider[17].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.2f, 0.4f),
            new Vector3(0.25f, 0.5f, 0.9f));

        HitBox = HitCollider[18].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.58f, 0f),
            new Vector3(0.25f, 0.85f, 1.2f));

        AtkCollider[5].SetActive(true);
   
    }

    //--------------------------------
    //ダウンあたり判定
    //
    //使用モーション:ダウン
    //--------------------------------
    void DownCollider1()
    {
        HitColliderActive();

        HitCollider[19].SetActive(true);
        HitBox = HitCollider[19].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.78f, 0f),
            new Vector3(0.25f, 1.55f, 0.75f));

        AtkColliderActive();
    }
    void DownCollider2()
    {
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.75f, 0f),
            new Vector3(0.25f, 1.5f, 0.75f));
    }
    void DownCollider3()
    {
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.72f, -0.05f),
            new Vector3(0.25f, 1.45f, 0.65f));
    }
    void DownCollider4()
    {
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1f, -0.2f),
            new Vector3(0.25f, 0.5f, 0.75f));

        HitCollider[20].SetActive(true);
        HitBox = HitCollider[20].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.45f, 0.1f),
            new Vector3(0.25f, 0.85f, 0.65f));
    }
    void DownCollider5()
    {
        HitBox = HitCollider[19].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.85f, -0.25f),
            new Vector3(0.25f, 0.55f, 0.85f));

        HitBox = HitCollider[20].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.5f, 0.2f),
            new Vector3(0.25f, 0.75f, 0.6f));
    }
    void DownCollider6()
    {
        HitBox = HitCollider[19].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.78f, -0.25f),
            new Vector3(0.25f, 0.7f, 0.85f));

        HitBox = HitCollider[20].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.6f, 0.45f),
            new Vector3(0.25f, 0.6f, 0.6f));
    }
    void DownCollider7()
    {
        HitColliderActive();

        HitCollider[19].SetActive(true);
        HitBox = HitCollider[19].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.85f, 0.05f),
            new Vector3(0.25f, 0.5f, 1.65f));
    }

    //--------------------------------
    //昇竜コマンドあたり判定
    //
    //使用モーション:昇竜
    //--------------------------------
    void BasicShoruCollider1()
    {
        HitColliderActive();

        AtkColliderActive();

        AtkCollider[6].SetActive(true);
    }
    void BasicShoruCollider2()
    {
        HitCollider[21].SetActive(true);
        HitBox = HitCollider[21].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.35f, 0.15f),
            new Vector3(0.25f, 0.6f, 0.85f));

        HitCollider[22].SetActive(true);
        HitBox = HitCollider[22].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.6f, -0.05f),
            new Vector3(0.25f, 1.2f, 0.6f));

        AtkColliderActive();
    }
    void BasicShoruCollider3()
    {
        HitBox = HitCollider[21].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.35f, 0.08f),
            new Vector3(0.25f, 0.6f, 0.75f));
    }
    void BasicShoruCollider4()
    {
        HitBox = HitCollider[21].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.35f, 0.05f),
            new Vector3(0.25f, 0.6f, 0.7f));

        HitBox = HitCollider[22].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.6f, 0),
            new Vector3(0.25f, 1f, 0.5f));
    }

    void BasicShoruCollider5()
    {
        HitBox = HitCollider[21].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.4f, 0.05f),
            new Vector3(0.25f, 0.7f, 0.7f));
    }
    void BasicShoruCollider6()
    {
        HitBox = HitCollider[22].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.55f, 0f),
            new Vector3(0.25f, 1.15f, 0.5f));
    }
    void BasicShoruCollider7()
    {
        HitBox = HitCollider[21].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.35f, 0.02f),
            new Vector3(0.25f, 0.6f, 0.75f));

        HitBox = HitCollider[22].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.55f, 0f),
            new Vector3(0.25f, 1.1f, 0.5f));
    }
    void BasicShoruCollider8()
    {
        HitColliderActive();

        HitCollider[21].SetActive(true);
        HitBox = HitCollider[21].GetComponent<BoxCollider>();
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.9f, -0.02f),
            new Vector3(0.25f, 1.5f, 0.7f));
    }

    void BasicShoruCollider9()
    {
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 0.95f, -0.02f),
            new Vector3(0.25f, 1.35f, 0.7f));
    }

    //------------------
    //パンチあたり判定
    //
    //使用モーション:立ちパンチ　フレーム数:15
    //------------------
    void BasePunchCollider()
    {
        HitCollider[23].SetActive(true);
        AtkCollider[7].SetActive(true);
    }



    //くらい判定初期化関数
    private void HitColliderActive()
    {
        for (int i = 0; i < HCnum; i++)
        {
            //判定非動作
            HitCollider[i].SetActive(false);
        }
    }

    //攻撃判定初期化関数
    private void AtkColliderActive()
    {
        for (int i = 0; i < ACnum; i++)
        {
            //判定非動作
            AtkCollider[i].SetActive(false);
        }
    }

    //押し合い判定初期化関数
    private void PushColliderActive()
    {
        for (int i = 0; i < PCnum; i++)
        {
            //判定非動作
            PushCollider[i].SetActive(false);
        }
    }

    //あたり判定設定関数
    private void SetBoxState(BoxCollider box, Vector3 pos, Vector3 size)
    {
        box.center = pos;
        box.size = size;
    }

    //変数取得
    public List<GameObject> HClid { get { return HitCollider; } }
    public List<GameObject> AClid { get { return AtkCollider; } }
    public List<GameObject> PClid { get { return PushCollider; } }

}
