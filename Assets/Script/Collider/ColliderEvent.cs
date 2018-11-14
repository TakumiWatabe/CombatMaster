using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEvent : MonoBehaviour {

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
    void Start ()
    {
        //あたり判定の数
        HCnum = HitCollider.Count;
        ACnum = AtkCollider.Count;
        PCnum = PushCollider.Count;
	}

    void Update()
    {

    }
    //-------------------------------------------------------
    //基本あたり判定
    //
    //使用モーション:立ち、前進、後進、ジャンプ、立ちガード、ダメージ
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

    //-----------------------------------------
    //基本しゃがみあたり判定
    //
    //使用モーション:しゃがみ、しゃがみガード
    //-----------------------------------------
    void BasicSitCollide()
    {
        //くらい判定初期化
        HitColliderActive();

        //基本しゃがみ判定
        HitCollider[1].SetActive(true);

        //攻撃判定初期化
        AtkColliderActive();
    }

    //------------------
    //パンチあたり判定
    //
    //使用モーション:立ちパンチ　フレーム数:15
    //------------------
    void BasePunchCollider()
    {

        HitCollider[2].SetActive(true);
        AtkCollider[0].SetActive(true);

        HitBox = HitCollider[2].GetComponent<BoxCollider>();

        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1.2f, 0.25f),
            new Vector3(0.25f, 0.3f, 0.35f));
    }
    void SetPunchCollider_1()
    {
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1, 0.38f),
            new Vector3(0.25f, 0.35f, 0.55f));
    }
    void SetPunchCollider_2()
    {
        //コライダー設定
        SetBoxState(
            HitBox,
            new Vector3(0, 1, 0.25f),
            new Vector3(0.25f, 0.5f, 0.25f));
    }

    //------------------
    //キックあたり判定
    //
    //使用モーション:立ちキック フレーム数:5
    //------------------
    void BaseKickColliderAtk()
    {

        HitCollider[3].SetActive(true);
        AtkCollider[1].SetActive(true);

        HitBox = HitCollider[3].GetComponent<BoxCollider>();
        AtkBox = AtkCollider[1].GetComponent<BoxCollider>();

        SetBoxState(
            HitBox,
            new Vector3(0, 0.78f, 0.4f),
            new Vector3(0.25f, 0.3f, 0.55f));
        SetBoxState(
            AtkBox,
            new Vector3(0, 0.78f, 0.38f),
            new Vector3(0.25f, 0.25f, 0.55f));
    }
    void SetKickCollider_1()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 0.78f, 0.4f),
            new Vector3(0.25f, 0.3f, 0.55f));
        SetBoxState(
            AtkBox,
            new Vector3(0, 0.78f, 0.38f),
            new Vector3(0.25f, 0.25f, 0.55f));
    }
    void SetKickCollider_2()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 0.85f, 0.5f),
            new Vector3(0.25f, 0.3f, 0.95f));
        SetBoxState(
            AtkBox,
            new Vector3(0, 0.9f, 0.48f),
            new Vector3(0.25f, 0.25f, 0.95f));
    }

    //--------------------------------
    //ダウンあたり判定
    //
    //使用モーション:ダウン
    //--------------------------------
    void BasicDownCollider()
    {
        HitCollider[4].SetActive(true);
    }

    //--------------------------------
    //受け身あたり判定
    //
    //使用モーション:受け身
    //--------------------------------
    void BasicPassiveCollider()
    {
        HitCollider[5].SetActive(true);
    }

    //--------------------------------
    //昇竜コマンドあたり判定
    //
    //使用モーション:昇竜
    //--------------------------------
    void BasicShoruCollider1()
    {
        HitColliderActive();

        HitCollider[6].SetActive(true);
        HitCollider[7].SetActive(true);
        HitBox = HitCollider[6].GetComponent<BoxCollider>();

        SetBoxState(
            HitBox,
            new Vector3(0, 1.1f, 0.2f),
            new Vector3(0.25f, 0.8f, 0.65f));

        HitBox = HitCollider[7].GetComponent<BoxCollider>();

        SetBoxState(
            HitBox,
            new Vector3(0, 0.47f, -0.1f),
            new Vector3(0.25f, 0.65f, 0.9f));

        AtkColliderActive();
    }
    void BasicShoruCollider2()
    {
        HitColliderActive();

        HitCollider[6].SetActive(true);
        HitBox = HitCollider[6].GetComponent<BoxCollider>();

        SetBoxState(
            HitBox,
            new Vector3(0, 0.85f, 0.1f),
            new Vector3(0.25f, 1.4f, 0.7f));
    }
    void BasicShoruCollider3()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 1.15f, 0.1f),
            new Vector3(0.25f, 0.9f, 0.65f));

        HitCollider[7].SetActive(true);
        HitBox = HitCollider[7].GetComponent<BoxCollider>();

        SetBoxState(
            HitBox,
            new Vector3(0, 0.47f, 0),
            new Vector3(0.25f, 0.75f, 0.9f));

        HitCollider[8].SetActive(true);
        HitBox = HitCollider[8].GetComponent<BoxCollider>();

        SetBoxState(
            HitBox,
            new Vector3(0, 1.15f, 0.55f),
            new Vector3(0.25f, 0.25f, 0.55f));

    }
    void BasicShoruCollider4()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 1.3f, 0.45f),
            new Vector3(0.25f, 0.25f, 0.55f));

        AtkCollider[2].SetActive(true);
    }
    void BasicShoruCollider5()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 1.4f, 0.3f),
            new Vector3(0.25f, 0.3f, 0.55f));
    }
    void BasicShoruCollider6()
    {
        HitColliderActive();
        HitCollider[6].SetActive(true);
        HitCollider[7].SetActive(true);

        AtkColliderActive();
    }

    //--------------------------------
    //波動コマンドあたり判定
    //
    //使用モーション:波動
    //--------------------------------
    void BasicHadouCollider1()
    {
        HitColliderActive();
        HitCollider[9].SetActive(true);
        HitCollider[10].SetActive(true);

        HitBox = HitCollider[9].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.87f, 0),
            new Vector3(0.25f, 1.45f, 0.7f));

        HitBox = HitCollider[10].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 1.3f, 0.35f),
            new Vector3(0.25f, 0.25f, 0.5f));

        AtkColliderActive();

    }

    void BasicHadouCollider2()
    {
        HitCollider[11].SetActive(true);

        HitBox = HitCollider[9].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.93f, 0),
            new Vector3(0.25f, 1.6f, 0.7f));

        HitBox = HitCollider[10].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.38f, 0.35f),
            new Vector3(0.25f, 0.5f, 0.3f));

        HitBox = HitCollider[11].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.26f, 0.45f),
            new Vector3(0.25f, 0.25f, 0.25f));
    }
    void BasicHadouCollider3()
    {
        HitBox = HitCollider[9].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.9f, 0),
            new Vector3(0.25f, 1.5f, 0.6f));

        AtkCollider[3].SetActive(true);
        AtkCollider[4].SetActive(true);
        AtkCollider[5].SetActive(true);
        AtkCollider[6].SetActive(true);
    }

    //--------------------------------
    //しゃがみパンチあたり判定
    //
    //使用モーション:しゃがみパンチ
    //--------------------------------
    void SitPunchCollider()
    {
        HitCollider[12].SetActive(true);

        AtkCollider[7].SetActive(true);
    }

    //--------------------------------
    //しゃがみキックあたり判定
    //
    //使用モーション:しゃがみキック
    //--------------------------------
    void SitKickCollider1()
    {
        HitColliderActive();

        HitCollider[13].SetActive(true);
        HitBox = HitCollider[13].GetComponent<BoxCollider>();

        SetBoxState(
            HitBox,
            new Vector3(0, 1.08f, 0.08f),
            new Vector3(0.25f, 1.1f, 0.5f));

        AtkColliderActive();
    }
    void SitKickCollider2()
    {
        HitCollider[14].SetActive(true);

        SetBoxState(
            HitBox,
            new Vector3(0, 0.95f, -0.15f),
            new Vector3(0.25f, 0.75f, 0.85f));

        AtkCollider[8].SetActive(true);
    }
    void SitKickCollider3()
    {
        HitColliderActive();

        HitCollider[13].SetActive(true);

        SetBoxState(
            HitBox,
            new Vector3(0, 0.95f, -0.1f),
            new Vector3(0.25f, 0.75f, 0.8f));

        AtkColliderActive();
    }
    void SitKickCollider4()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 1, 0),
            new Vector3(0.25f, 0.85f, 0.7f));
    }
    void SitKickCollider5()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 1.08f, 0),
            new Vector3(0.25f, 1, 0.65f));
    }
    void SitKickCollider6()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 1.08f, -0.15f),
            new Vector3(0.25f, 1, 0.8f));

    }

    //--------------------------------
    //ジャンプパンチあたり判定
    //
    //使用モーション:ジャンプパンチ
    //--------------------------------
    void JumpPunchCollider1()
    {
        HitColliderActive();

        HitCollider[15].SetActive(true);
        HitCollider[16].SetActive(true);

        HitBox = HitCollider[15].GetComponent<BoxCollider>();

        SetBoxState(
            HitBox,
            new Vector3(0, 0.9f, 0.1f),
            new Vector3(0.25f, 1.4f, 0.5f));

        HitBox = HitCollider[16].GetComponent<BoxCollider>();

        SetBoxState(
            HitBox,
            new Vector3(0, 0.5f, -0.25f),
            new Vector3(0.25f, 0.8f, 0.4f));

        AtkColliderActive();
    }
    void JumpPunchCollider2()
    {
        HitCollider[17].SetActive(true);
        HitBox = HitCollider[15].GetComponent<BoxCollider>();

        SetBoxState(
            HitBox,
            new Vector3(0, 0.9f, 0),
            new Vector3(0.25f, 1.4f, 0.5f));

        HitBox = HitCollider[16].GetComponent<BoxCollider>();

        SetBoxState(
            HitBox,
            new Vector3(0, 0.5f, -0.35f),
            new Vector3(0.25f, 0.8f, 0.4f));
    }
    void JumpPunchCollider3()
    {
        AtkCollider[9].SetActive(true);
        AtkCollider[10].SetActive(true);
    }

    //--------------------------------
    //ジャンプパンチあたり判定
    //
    //使用モーション:ジャンプパンチ
    //--------------------------------
    void JumpKickCollider1()
    {
        HitColliderActive();
        HitCollider[18].SetActive(true);
        HitBox = HitCollider[18].GetComponent<BoxCollider>();

        SetBoxState(
            HitBox,
            new Vector3(0, 1f, 0),
            new Vector3(0.25f, 1.3f, 0.5f));

        AtkColliderActive();
    }
    void JumpKickCollider2()
    {
        HitCollider[19].SetActive(true);

        SetBoxState(
            HitBox,
            new Vector3(0, 1.05f, 0),
            new Vector3(0.25f, 1.15f, 0.6f));

        HitBox = HitCollider[19].GetComponent<BoxCollider>();
        SetBoxState(
            HitBox,
            new Vector3(0, 0.7f, 0.3f),
            new Vector3(0.25f, 0.35f, 0.6f));
    }
    void JumpKickCollider3()
    {
        SetBoxState(
            HitBox,
            new Vector3(0, 0.6f, 0.3f),
            new Vector3(0.25f, 0.5f, 0.5f));

        AtkCollider[11].SetActive(true);
        AtkCollider[12].SetActive(true);
    }
    void JumpKickCollider4()
    {
        AtkColliderActive();
    }

    //--------------------------------
    //ダッシュあたり判定
    //
    //使用モーション:ダッシュ
    //--------------------------------
    void BasicDashCollider()
    {
        HitColliderActive();
        HitCollider[20].SetActive(true);
        AtkColliderActive();
    }

    //--------------------------------
    //くらい強あたり判定
    //
    //使用モーション:くらい強
    //--------------------------------
    void BasicLDCollider()
    {
        HitColliderActive();
        HitCollider[21].SetActive(true);
        AtkColliderActive();
    }

    //--------------------------------------
    //しゃがみ系あたり判定
    //
    //使用モーション:立ち上がり、しゃがみ中
    //--------------------------------------
    void SitCollider()
    {
        HitColliderActive();
        HitCollider[22].SetActive(true);
        AtkColliderActive();
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
}
