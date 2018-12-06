//プレイヤー親のコントローラ
//2018/12/4
//入山奨
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParentController : MonoBehaviour {

    //移動速度
    [SerializeField]
    private float moveSpeed = 0.03f;
    //ジャンプの高さ
    [SerializeField]
    private float jumpSpeed = 0.15f;
    //状態
    [SerializeField]
    private string state = "Stand";
    //必殺技の状態
    [SerializeField]
    private string specialState = "";
    //コントローラー番号
    private int controller = 0;

    //方向キー
    private int inputDKey;
    private int inputDKeyOld;

    //コントローラーの名前
    [SerializeField]
    private string controllerName = "";

    //キーの定義
    private float x = 0;
    private float y = 0;
    private bool punchKey = false;
    private bool kickKey = false;

    //向き
    private int direction = 1;
    //相手
    [SerializeField]
    private GameObject enemy;

    //縦方向の速度
    private float ySpeed = 0;
    //今の重力
    private float nowGravity;

    //操作ができない状態か
    [SerializeField]
    private bool isFreeze = false;

    //キャラクター生成オブジェクト
    private GameObject contl;
    private InstanceScript InScript;

    void Awake()
    {
        contl = GameObject.Find("FighterComtrol");
        InScript = contl.GetComponent<InstanceScript>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public int InputDKey
    {
        get
        {
            return inputDKey;
        }
        set
        {
            inputDKey = value;
        }
    }

    public bool PunchKey
    {
        get
        {
            return punchKey;
        }
        set
        {
            punchKey = value;
        }
    }

    public bool KickKey
    {
        get
        {
            return kickKey;
        }
        set
        {
            kickKey = value;
        }
    }

    public string ControllerName
    {
        get
        {
            return controllerName;
        }
        set
        {
            controllerName = value;
        }
    }

    public string State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
        }
    }

    public string SpecialState
    {
        get
        {
            return specialState;
        }
        set
        {
            specialState = value;
        }
    }

    public int Direction
    {
        get
        {
            return direction;
        }
        set
        {
            direction = value;
        }
    }

    public bool IsFreeze
    {
        get
        {
            return isFreeze;
        }
        set
        {
            isFreeze = value;
        }
    }

    public GameObject fightEnemy { get { return enemy; } }
}
