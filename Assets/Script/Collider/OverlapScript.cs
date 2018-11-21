﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapScript : MonoBehaviour {
    //--------------------------------------
    //あたり判定設定
    //--------------------------------------

    //押し合い判定
    [SerializeField]
    private List<GameObject> PushCollider;

    BoxCollider[] PushBox;

    int PCnum;

    private const float CSizeZ = 0.25f;

    // Use this for initialization
    void Start ()
    {
        //あたり判定の数
        PCnum = PushCollider.Count;

        PushBox = new BoxCollider[PCnum];

        for(int i=0;i<PCnum;i++)
        {
            PushBox[i] = PushCollider[i].GetComponent<BoxCollider>();
        }

        //押し合い判定初期化
        PushColliderActive();
    }

    //-------------------------------------------------------------------------------------------------------------------
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Aoiあたり判定
    //
    //-------------------------------------------------------
    //立ち押し合い判定
    //
    //使用モーション:立ち,立ちパンチ,波動
    //-------------------------------------------------------
    void IdleOver()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 0.85f, 0),
            new Vector3(CSizeZ, 1.6f, 0.45f));
    }

    //-------------------------------------------------------
    //移動押し合い判定
    //
    //使用モーション:前進、後進
    //-------------------------------------------------------
    void WarkOver()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 0.8f, 0),
            new Vector3(CSizeZ, 1.6f, 0.45f));
    }

    //-------------------------------------------------------
    //立ちガード押し合い判定
    //
    //使用モーション:立ちガード
    //-------------------------------------------------------
    void GuardOver()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 0.88f, 0.1f),
            new Vector3(CSizeZ, 1.5f, 0.5f));
    }

    //-------------------------------------------------------
    //ダメージ押し合い判定
    //
    //使用モーション:ダメージ
    //-------------------------------------------------------
    void DamageOver()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 0.95f, 0.1f),
            new Vector3(CSizeZ, 1.6f, 0.5f));
    }

    //--------------------------------------------------------
    //しゃがみ押し合い判定
    //
    //使用モーション:しゃがみ,しゃがみガード,しゃがみパンチ
    //--------------------------------------------------------
    void SitOver()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 1.08f, 0),
            new Vector3(CSizeZ, 1.15f, 0.4f));
    }

    //---------------------------
    //キック押し合い判定
    //
    //使用モーション:立ちキック
    //---------------------------
    void KickOver()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 0.85f, 0),
            new Vector3(CSizeZ, 1.6f, 0.4f));
    }

    //--------------------------------
    //ダウン押し合い判定
    //
    //使用モーション:ダウン
    //--------------------------------
    void DownOver_1()
    {
        //基本押し合い判定
        PushCollider[1].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 1.2f, 0.35f),
            new Vector3(CSizeZ, 0.6f, 0.3f));
        SetBoxState(PushBox[1],
            new Vector3(0, 0.8f, -0.3f),
            new Vector3(CSizeZ, 0.5f, 1.2f));
    }
    void DownOver_2()
    {
        //基本押し合い判定
        PushCollider[1].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 1.1f, 0.5f),
            new Vector3(CSizeZ, 0.5f, 0.3f));
        SetBoxState(PushBox[1],
            new Vector3(0, 0.9f, -0.2f),
            new Vector3(CSizeZ, 0.35f, 1.2f));

    }
    void DownOver_3()
    {
        //基本押し合い判定
        PushCollider[1].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 0.95f, 0.55f),
            new Vector3(CSizeZ, 0.45f, 0.4f));
        SetBoxState(PushBox[1],
            new Vector3(0, 0.9f, -0.2f),
            new Vector3(CSizeZ, 0.4f, 1.2f));

    }
    void DownOver_4()
    {
        //基本押し合い判定
        PushCollider[1].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 0.85f, 0.55f),
            new Vector3(CSizeZ, 0.4f, 0.5f));
        SetBoxState(PushBox[1],
            new Vector3(0, 0.9f, -0.2f),
            new Vector3(CSizeZ, 0.4f, 1.2f));

    }
    void DownOver_5()
    {
        //基本押し合い判定
        PushCollider[1].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 0.8f, 0.55f),
            new Vector3(CSizeZ, 0.35f, 0.5f));
        SetBoxState(PushBox[1],
            new Vector3(0, 0.9f, -0.2f),
            new Vector3(CSizeZ, 0.4f, 1.2f));

    }
    void DownOver_6()
    {
        //基本押し合い判定
        PushCollider[1].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 0.75f, 0.55f),
            new Vector3(CSizeZ, 0.35f, 0.5f));
        SetBoxState(PushBox[1],
            new Vector3(0, 0.85f, -0.2f),
            new Vector3(CSizeZ, 0.4f, 1.2f));

    }
    void DownOver_7()
    {
        //基本押し合い判定
        PushCollider[1].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 0.85f, 0.55f),
            new Vector3(CSizeZ, 0.35f, 0.5f));
        SetBoxState(PushBox[1],
            new Vector3(0, 0.9f, -0.2f),
            new Vector3(CSizeZ, 0.35f, 1.2f));

    }


    //--------------------------------
    //受け身押し合い判定
    //
    //使用モーション:受け身
    //--------------------------------
    void PassiveOver_1()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 0.85f, 0.1f),
            new Vector3(CSizeZ, 0.5f, 1.25f));
    }
    void PassiveOver_2()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 0.9f, 0.25f),
            new Vector3(CSizeZ, 0.6f, 1.2f));
    }
    void PassiveOver_3()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 1f, 0.4f),
            new Vector3(CSizeZ, 0.6f, 0.9f));
    }

    //--------------------------------
    //昇竜コマンド押し合い判定
    //
    //使用モーション:昇竜
    //--------------------------------
    void ShoryuOver_1()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);
        PushCollider[1].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 1.25f, 0.3f),
            new Vector3(CSizeZ, 0.55f, 0.45f));
        SetBoxState(PushBox[1],
            new Vector3(0, 0.6f, 0f),
            new Vector3(CSizeZ, 0.9f, 0.5f));
    }
    void ShoryuOver_2()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 1.3f, 0.15f),
            new Vector3(CSizeZ, 0.6f, 0.35f));
        SetBoxState(PushBox[1],
            new Vector3(0, 0.6f, 0f),
            new Vector3(CSizeZ, 1f, 0.5f));
    }
    void ShoryuOver_3()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 1.3f, 0.1f),
            new Vector3(CSizeZ, 0.6f, 0.35f));
    }
    void ShoryuOver_4()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 1.3f, 0f),
            new Vector3(CSizeZ, 0.6f, 0.35f));
    }
    void ShoryuOver_5()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 1.3f, 0.05f),
            new Vector3(CSizeZ, 0.6f, 0.35f));
    }

    //--------------------------------
    //しゃがみキック押し合い判定
    //
    //使用モーション:しゃがみキック
    //--------------------------------
    void SKickOver_1()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 1.08f, 0.1f),
            new Vector3(CSizeZ, 1.1f, 0.45f));
    }
    void SKickOver_2()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 1.02f, -0.05f),
            new Vector3(CSizeZ, 0.9f, 0.5f));
    }
    void SKickOver_3()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 1.02f, -0.1f),
            new Vector3(CSizeZ, 0.9f, 0.65f));
    }
    void SKickOver_4()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 0.98f, -0.15f),
            new Vector3(CSizeZ, 0.8f, 0.8f));
    }
    void SKickOver_5()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 0.98f, -0.15f),
            new Vector3(CSizeZ, 0.8f, 0.75f));
    }
    void SKickOver_6()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 1f, -0.05f),
            new Vector3(CSizeZ, 0.85f, 0.5f));
    }

    //--------------------------------
    //ジャンプパンチ押し合い判定
    //
    //使用モーション:ジャンプパンチ
    //--------------------------------
    void JPunchOver()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 1f, 0.05f),
            new Vector3(CSizeZ, 1.2f, 0.35f));
    }

    //--------------------------------
    //ジャンプキック押し合い判定
    //
    //使用モーション:ジャンプキック
    //--------------------------------
    void JKickOver()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 1f, -0.05f),
            new Vector3(CSizeZ, 1.2f, 0.35f));
    }

    //--------------------------------
    //ダッシュ押し合い判定
    //
    //使用モーション:ダッシュ
    //--------------------------------
    void DashOver()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);
        PushCollider[1].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 1.2f, 0.3f),
            new Vector3(CSizeZ, 0.5f, 0.5f));
        SetBoxState(PushBox[1],
            new Vector3(0, 0.6f, 0),
            new Vector3(CSizeZ, 0.85f, 0.4f));
    }

    //--------------------------------
    //くらい強押し合い判定
    //
    //使用モーション:くらい強
    //--------------------------------
    void LDamageOver()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 0.8f, 0.05f),
            new Vector3(CSizeZ, 1.5f, 0.5f));
    }

    //--------------------------------------
    //立ち上がり押し合い判定
    //
    //使用モーション:立ち上がり、しゃがみ中
    //--------------------------------------
    void StandUpOver_1()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 1.05f, 0f),
            new Vector3(CSizeZ, 1.1f, 0.4f));
    }
    void StandUpOver_2()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 1f, 0),
            new Vector3(CSizeZ, 1.2f, 0.4f));
    }
    void StandUpOver_3()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 0.95f, 0),
            new Vector3(CSizeZ, 1.3f, 0.4f));
    }
    void StandUpOver_4()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 0.9f, 0),
            new Vector3(CSizeZ, 1.45f, 0.4f));
    }

    //--------------------------------------
    //しゃがみ最中押し合い判定
    //
    //使用モーション:しゃがみ最中
    //--------------------------------------
    void SitDownOver_1()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 0.85f, 0f),
            new Vector3(CSizeZ, 1.6f, 0.4f));
    }
    void SitDownOver_2()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 0.9f, 0f),
            new Vector3(CSizeZ, 1.4f, 0.4f));
    }
    void SitDownOver_3()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 0.98f, 0f),
            new Vector3(CSizeZ, 1.3f, 0.4f));
    }
    void SitDownOver_4()
    {
        SetBoxState(PushBox[0],
            new Vector3(0, 1.02f, 0f),
            new Vector3(CSizeZ, 1.2f, 0.4f));
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //-------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Hikariあたり判定
    //
    //-------------------------------------------------------
    //立ち押し合い判定
    //
    //使用モーション:立ち
    //-------------------------------------------------------
    void HStandOver()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 0.78f, 0),
            new Vector3(CSizeZ, 1.55f, 0.4f));
    }

    //-------------------------------------------------------
    //前進押し合い判定
    //
    //使用モーション:前進
    //-------------------------------------------------------
    void HFrontOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //-------------------------------------------------------
    //後進押し合い判定
    //
    //使用モーション:後進
    //-------------------------------------------------------
    void HBackOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //-------------------------------------------------------
    //立ちガード押し合い判定
    //
    //使用モーション:立ちガード
    //-------------------------------------------------------
    void HGuardOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //-------------------------------------------------------
    //ダメージ押し合い判定
    //
    //使用モーション:ダメージ
    //-------------------------------------------------------
    void HDamageOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //------------------------------------------------------
    //しゃがみ押し合い判定
    //
    //使用モーション:しゃがみ
    //------------------------------------------------------
    void HSitOver()
    {
        //押し合い判定初期化
        PushColliderActive();
        //基本押し合い判定
        PushCollider[0].SetActive(true);

        SetBoxState(PushBox[0],
            new Vector3(0, 0.78f, 0),
            new Vector3(CSizeZ, 1.55f, 0.4f));
    }

    //------------------------------------------------------
    //しゃがみガード押し合い判定
    //
    //使用モーション:しゃがみガード
    //------------------------------------------------------
    void HSitGuardOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //------------------------------------------------------
    //しゃがみダメージ押し合い判定
    //
    //使用モーション:しゃがみダメ
    //------------------------------------------------------
    void HSitDamegeOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //--------------------------------
    //ダッシュ押し合い判定
    //
    //使用モーション:ダッシュ
    //--------------------------------
    void HDashOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //--------------------------------
    //波動コマンド押し合い判定
    //
    //使用モーション:波動
    //--------------------------------
    void HHadouOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }
 
    //-----------------------------------------
    //ジャンプ押し合い判定
    //
    //使用モーション:ジャンプ
    //-----------------------------------------
    void HJumpOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //-----------------------------------------
    //ジャンプ中押し合い判定
    //
    //使用モーション:ジャンプ中
    //-----------------------------------------
    void HJumpingOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //--------------------------------
    //ジャンプキック押し合い判定
    //
    //使用モーション:ジャンプキック
    //--------------------------------
    void HJumpKickOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //--------------------------------
    //ジャンプパンチ押し合い判定
    //
    //使用モーション:ジャンプパンチ
    //--------------------------------
    void HJumpPunchOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }
 
    //--------------------------------------
    //しゃがみ中押し合い判定
    //
    //使用モーション:しゃがみ中
    //--------------------------------------
    void HSitingOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //--------------------------------
    //しゃがみキック押し合い判定
    //
    //使用モーション:しゃがみキック
    //--------------------------------
    void HSitKickOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //--------------------------------
    //しゃがみパンチ押し合い判定
    //
    //使用モーション:しゃがみパンチ
    //--------------------------------
    void HSitPunchOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //-----------------------------------------
    //立ち上がり押し合い判定
    //
    //使用モーション:立ち上がり
    //-----------------------------------------
    void HStandUpOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //------------------------
    //強攻撃押し合い判定
    //
    //使用モーション:強攻撃
    //------------------------
    void HBaseKickOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //--------------------------------
    //ダウン押し合い判定
    //
    //使用モーション:ダウン
    //--------------------------------
    void HDownOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //--------------------------------
    //昇竜コマンド押し合い判定
    //
    //使用モーション:昇竜
    //--------------------------------
    void HShoruOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }

    //------------------
    //パンチ押し合い判定
    //
    //使用モーション:立ちパンチ　フレーム数:15
    //------------------
    void HPunchOver()
    {
        //基本押し合い判定
        PushCollider[0].SetActive(true);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //-------------------------------------------------------------------------------------------------------------------

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

    public List<GameObject> PClid { get { return PushCollider; } }
}
