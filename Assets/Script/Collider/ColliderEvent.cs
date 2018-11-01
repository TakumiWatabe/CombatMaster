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
        HitBox = HitCollider[2].GetComponent<BoxCollider>();

        HitCollider[2].SetActive(true);
        AtkCollider[0].SetActive(true);

        //コライダー設定
        SetBoxState(HitBox,
                    new Vector3(0, 1.2f, 0.25f),
                    new Vector3(0.25f, 0.3f, 0.35f));
    }
    void SetPunchCollider_1()
    {
        //コライダー設定
        SetBoxState(HitBox,
                    new Vector3(0, 1, 0.38f),
                    new Vector3(0.25f, 0.35f, 0.55f));
    }
    void SetPunchCollider_2()
    {
        //コライダー設定
        SetBoxState(HitBox,
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
        HitBox = HitCollider[3].GetComponent<BoxCollider>();
        AtkBox = AtkCollider[1].GetComponent<BoxCollider>();

        HitCollider[3].SetActive(true);
        AtkCollider[1].SetActive(true);

        SetBoxState(HitBox,
                    new Vector3(0, 0.78f, 0.4f),
                    new Vector3(0.25f, 0.3f, 0.55f));
        SetBoxState(AtkBox,
                    new Vector3(0, 0.78f, 0.38f),
                    new Vector3(0.25f, 0.25f, 0.55f));
    }
    void SetKickCollider_1()
    {
        SetBoxState(HitBox,
                    new Vector3(0, 0.78f, 0.4f),
                    new Vector3(0.25f, 0.3f, 0.55f));
        SetBoxState(AtkBox,
                    new Vector3(0, 0.78f, 0.38f),
                    new Vector3(0.25f, 0.25f, 0.55f));
    }
    void SetKickCollider_2()
    {
        SetBoxState(HitBox,
                    new Vector3(0, 0.85f, 0.5f),
                    new Vector3(0.25f, 0.3f, 0.95f));
        SetBoxState(AtkBox,
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
    //使用モーション:受け身
    //--------------------------------
    void BasicShoruCollider()
    {
        HitCollider[6].SetActive(true);
    }


    //--------------------------------
    //しゃがみパンチ状態あたり判定1
    //--------------------------------
    void CrouchPunch_C1()
    {
        //くらい判定
        HitColliderActive();

        //しゃがみパンチくらい判定
        HitCollider[4].SetActive(true);
        HitCollider[5].SetActive(true);

        //攻撃判定
        AtkColliderActive();
    }

    //--------------------------------
    //しゃがみパンチ状態あたり判定2
    //--------------------------------
    void CrouchPunch_C2()
    {
        //くらい判定
        HitColliderActive();

        //しゃがみパンチくらい判定
        HitCollider[6].SetActive(true);
        HitCollider[7].SetActive(true);
        HitCollider[8].SetActive(true);

        //攻撃判定
        AtkColliderActive();
    }

    //--------------------------------
    //しゃがみパンチ状態あたり判定3
    //--------------------------------
    void CrouchPunch_C3()
    {
        //くらい判定
        HitColliderActive();

        //しゃがみパンチくらい判定
        HitCollider[6].SetActive(true);
        HitCollider[7].SetActive(true);
        HitCollider[9].SetActive(true);

        //攻撃判定
        AtkColliderActive();

        //しゃがみパンチ攻撃判定
        AtkCollider[0].SetActive(true);
    }

    //--------------------------------
    //しゃがみパンチ状態あたり判定4
    //--------------------------------
    void CrouchPunch_C4()
    {        
        //くらい判定
        HitColliderActive();

        //しゃがみパンチくらい判定
        HitCollider[6].SetActive(true);
        HitCollider[7].SetActive(true);
        HitCollider[10].SetActive(true);

        //攻撃判定
        AtkColliderActive();

        //攻撃判定
        AtkCollider[1].SetActive(true);
    }

    //--------------------------------
    //しゃがみパンチ状態あたり判定5
    //--------------------------------
    void CrouchPunch_C5()
    {
        //くらい判定
        HitColliderActive();

        //しゃがみパンチくらい判定
        HitCollider[6].SetActive(true);
        HitCollider[7].SetActive(true);

        //攻撃判定
        AtkColliderActive();
    }

    //--------------------------------
    //しゃがみキック状態あたり判定1
    //--------------------------------
    void CrouchKick_C1()
    {
        //くらい判定
        HitColliderActive();

        //しゃがみキックくらい判定
        HitCollider[11].SetActive(true);
        HitCollider[12].SetActive(true);

        //攻撃判定
        AtkColliderActive();
    }

    //--------------------------------
    //しゃがみキック状態あたり判定2
    //--------------------------------
    void CrouchKick_C2()
    {
        //くらい判定
        HitColliderActive();

        //しゃがみキックくらい判定
        HitCollider[13].SetActive(true);
        HitCollider[14].SetActive(true);

        //攻撃判定
        AtkColliderActive();
    }

    //--------------------------------
    //しゃがみキック状態あたり判定3
    //--------------------------------
    void CrouchKick_C3()
    {
        //くらい判定
        HitColliderActive();

        //しゃがみキックくらい判定
        HitCollider[15].SetActive(true);
        HitCollider[16].SetActive(true);
        HitCollider[17].SetActive(true);

        //攻撃判定
        AtkColliderActive();

        //攻撃判定
        AtkCollider[2].SetActive(true);
    }

    //--------------------------------
    //しゃがみキック状態あたり判定4
    //--------------------------------
    void CrouchKick_C4()
    {
        //くらい判定
        HitColliderActive();

        //しゃがみキックくらい判定
        HitCollider[18].SetActive(true);
        HitCollider[19].SetActive(true);
        HitCollider[20].SetActive(true);

        //攻撃判定
        AtkColliderActive();

        //攻撃判定
        AtkCollider[3].SetActive(true);
    }

    //--------------------------------
    //しゃがみキック状態あたり判定5
    //--------------------------------
    void CrouchKick_C5()
    {
        //くらい判定
        HitColliderActive();

        //しゃがみキックくらい判定
        HitCollider[21].SetActive(true);
        HitCollider[22].SetActive(true);
        HitCollider[23].SetActive(true);

        //攻撃判定
        AtkColliderActive();
    }

    //--------------------------------
    //ジャンプキック状態あたり判定1
    //--------------------------------
    void JumpKickCollider1()
    {
        //くらい判定
        HitColliderActive();

        //攻撃判定
        AtkColliderActive();

        //攻撃判定
        AtkCollider[8].SetActive(true);
        AtkCollider[9].SetActive(true);
    }

    //--------------------------------
    //ジャンプキック状態あたり判定2
    //--------------------------------
    void JumpKickCollider2()
    {
        //くらい判定
        HitColliderActive();

        //攻撃判定
        AtkColliderActive();

        //攻撃判定
        AtkCollider[10].SetActive(true);
        AtkCollider[11].SetActive(true);
    }

    //--------------------------------
    //ジャンプキック状態あたり判定3
    //--------------------------------
    void JumpKickCollider3()
    {
        //くらい判定
        HitColliderActive();

        //攻撃判定
        AtkColliderActive();

        //攻撃判定
        AtkCollider[12].SetActive(true);
        AtkCollider[13].SetActive(true);
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
