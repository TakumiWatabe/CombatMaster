using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamepadInput;

public class PlayerController : MonoBehaviour
{

    //スピード
    public float speed = 0.1f;
    //重力
    public float gravity = 0.008f;
    //状態
    string state = "Stand";
    //必殺技の状態
    string specialState = "";
    //コマンド入力の猶予
    public int commandCount = 20;
    //入力履歴の数
    public int numInputHistory = 10;
    //コントローラー番号
    public int controller = 0;
    //ダメージ
    public int damage = 0;
    //向き
    int direction = 1;
    //相手
    public GameObject enemy;
    //方向キー
    int inputDKey;
    int inputDKeyOld;

    //これがモデルかどうか
    public bool isModel = false;


    //public Text text;
    //入力履歴
    List<string> history = new List<string>();
    //入力履歴(画面表示用)
    List<string> inputHistory = new List<string>();
    //アニメーター
    Animator animator;
    //最終的な移動距離
    Vector3 finalMove = new Vector3(0, 0, 0);
    //ジャンプをしてから地面につかない間
    int jumpTime = 10;
    int jumpCount = 0;
    //縦方向の速度
    float ySpeed = 0;
    //今の重力
    float nowGravity;

    //キーの定義
    float x = 0;
    float y = 0;

    bool punchKey = false;
    bool kickKey = false;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();

        //入力履歴の設定
        history.Clear();
        for (int i = 0; i < commandCount; i++)
        {
            history.Add("N");
        }

        inputHistory.Clear();
        for (int i = 0; i < numInputHistory; i++)
        {
            inputHistory.Add("");
        }

        inputDKey = 5;
        inputDKeyOld = inputDKey;
    }

    // Update is called once per frame
    void Update()
    {

        //text.text = "";

        //gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed, 0, 0);

        SetDirection();
        InputKey();

        switch (state)
        {
            case "Stand":
                Stand();
                break;
            case "Crouch":
                Crouch();
                break;
            case "Jump":
                Jump();
                break;
            case "Punch":
                Punch();
                break;
            case "Kick":
                Kick();
                break;
            case "Special":
                Special();
                break;

        }

        Jumping();

        FinallyMove();

        InputCommand();

        InputKeyHistory();

        SyoryukenCommand();

        HadokenCommand();

        inputDKeyOld = inputDKey;

    }

    /// <summary>
    /// 敵の位置を見て向きをセット
    /// </summary>
    void SetDirection()
    {
        if (enemy.transform.position.x >= transform.position.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }

    /// <summary>
    /// コントローラの入力を入れる
    /// </summary>
    void InputKey()
    {
        //キーの定義
        x = 0;
        y = 0;

        punchKey = false;
        kickKey = false;

        if (controller == 1)
        {
            // 右・左
            x = GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One).x;
            x += GamePad.GetAxis(GamePad.Axis.Dpad, GamePad.Index.One).x * 1000;

            // 上・下
            y = GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.One).y * 1;
            y += GamePad.GetAxis(GamePad.Axis.Dpad, GamePad.Index.One).y * 1000;

            //パンチ
            punchKey = GamePad.GetButtonDown(GamePad.Button.A, GamePad.Index.One);
            //キック
            kickKey = GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.One);
        }
        else if (controller == 2)
        {
            // 右・左
            x = GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Two).x;
            x += GamePad.GetAxis(GamePad.Axis.Dpad, GamePad.Index.Two).x * 1000;

            // 上・下
            y = GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Two).y * 1;
            y += GamePad.GetAxis(GamePad.Axis.Dpad, GamePad.Index.Two).y * 1000;

            //パンチ
            punchKey = GamePad.GetButtonDown(GamePad.Button.A, GamePad.Index.Two);
            //キック
            kickKey = GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.Two);
        }

        //取得
        if (direction == 1)
        {
            if (x < -0.4f && y < -0.5f) inputDKey = 1;
            if (x < 0.4f && x > -0.4f && y < -0.5f) inputDKey = 2;
            if (x > 0.4f && y < -0.5f) inputDKey = 3;
            if (y < 0.4f && y > -0.5f && x < -0.4f) inputDKey = 4;
            if (x < 0.4f && x > -0.4f && y < 0.4f && y > -0.5f) inputDKey = 5;
            if (y < 0.4f && y > -0.5f && x > 0.4f) inputDKey = 6;
            if (x < -0.4f && y > 0.4f) inputDKey = 7;
            if (x < 0.4f && x > -0.4f && y > 0.4f) inputDKey = 8;
            if (x > 0.4f && y > 0.4f) inputDKey = 9;
        }
        else if (direction == -1)
        {
            if (x < -0.4f && y < -0.5f) inputDKey = 3;
            if (x < 0.4f && x > -0.4f && y < -0.5f) inputDKey = 2;
            if (x > 0.4f && y < -0.5f) inputDKey = 1;
            if (y < 0.4f && y > -0.5f && x < -0.4f) inputDKey = 6;
            if (x < 0.4f && x > -0.4f && y < 0.4f && y > -0.5f) inputDKey = 5;
            if (y < 0.4f && y > -0.5f && x > 0.4f) inputDKey = 4;
            if (x < -0.4f && y > 0.4f) inputDKey = 9;
            if (x < 0.4f && x > -0.4f && y > 0.4f) inputDKey = 8;
            if (x > 0.4f && y > 0.4f) inputDKey = 7;
        }
    }

    /// <summary>
    /// 太刀状態
    /// </summary>
    void Stand()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, 0);

        int move = 0;

        //左右移動する
        if (direction == 1)
        {
            if (inputDKey == 6 || inputDKey == 9) move = 1;
            if (inputDKey == 4 || inputDKey == 7) move = -1;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                move = -1;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                move = 1;
            }
            //右向き
            if (isModel) transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);

        }
        else
        {
            if (inputDKey == 6 || inputDKey == 9) move = -1;
            if (inputDKey == 4 || inputDKey == 7) move = 1;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                move = 1;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                move = -1;
            }
            //左向き
            if(isModel)transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -1);
        }

        //下が押されたらしゃがみ
        if (inputDKey <= 3 || Input.GetKey(KeyCode.DownArrow))
        {
            state = "Crouch";
        }
        //上が押されたらジャンプ
        if (inputDKey >= 7 || Input.GetKey(KeyCode.UpArrow))
        {
            nowGravity = 0;
            state = "Jump";
        }


        // 移動する向きを求める
        finalMove = new Vector3(move, 0, 0).normalized * speed;

        if (direction == 1) animator.SetInteger("Move", move);
        else animator.SetInteger("Move", move * -1);
        animator.SetInteger("Special", 0);
        animator.SetBool("Crouch", false);
        animator.SetBool("Punch", false);
        animator.SetBool("Kick", false);

        //立ち状態時にZを押すとパンチ
        if (Input.GetKeyDown(KeyCode.Z) || punchKey)
        {
            animator.SetBool("Punch", true);
            state = "Punch";
        }
        //立ち状態時にXを押すとキック
        if (Input.GetKeyDown(KeyCode.X) || kickKey)
        {
            animator.SetBool("Kick", true);
            state = "Kick";
        }
    }

    /// <summary>
    /// しゃがみ
    /// </summary>
    void Crouch()
    {
        animator.SetBool("Crouch", true);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, 0);
        finalMove = new Vector3(0, 0, 0);
        //下が離されたら立つ
        if (!Input.GetKey(KeyCode.DownArrow))
        {
            state = "Stand";
        }

        //下が離されたら立つ
        if (inputDKey <= 3)
        {
            state = "Crouch";
        }
        else
        {
            state = "Stand";
        }

        //しゃがみ状態時にZを押すとキック
        if (Input.GetKeyDown(KeyCode.Z) || punchKey)
        {
            animator.SetBool("Punch", true);
            state = "Punch";
        }
        //しゃがみ状態時にXを押すとキック
        if (Input.GetKeyDown(KeyCode.X) || kickKey)
        {
            animator.SetBool("Kick", true);
            state = "Kick";
        }
    }

    /// <summary>
    /// ジャンプ
    /// </summary>
    void Jump()
    {
        jumpCount++;
    }

    /// <summary>
    /// パンチ
    /// </summary>
    void Punch()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, 0);

        damage = 300;
        animator.SetBool("Punch", true);
        finalMove = new Vector3(0, 0, 0);

        //立ち状態時にZを押すとパンチ
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f && (Input.GetKeyDown(KeyCode.Z) || punchKey))
        {
            animator.SetBool("Punch", true);
            state = "Punch";
            animator.Play(animator.GetCurrentAnimatorStateInfo(0).shortNameHash, -1, 0.0f);
        }

        //立ち状態時にXを押すとキック
        if (Input.GetKeyDown(KeyCode.X) || kickKey)
        {
            animator.SetBool("Kick", true);
            state = "Kick";
        }

        //キックしているアニメーションで終わったら戻す
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && animator.GetBool("Punch"))
        {
            animator.SetBool("Punch", false);
            state = "Stand";
        }


    }

    /// <summary>
    /// キック
    /// </summary>
    void Kick()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, 0);
        //キックしているアニメーションで終わったら戻す
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && animator.GetBool("Kick"))
        {
            animator.SetBool("Kick", false);
            state = "Stand";
        }
        damage = 600;
        animator.SetBool("Kick", true);
        finalMove = new Vector3(0, 0, 0);
    }

    /// <summary>
    /// 必殺技
    /// </summary>
    void Special()
    {
        switch (specialState)
        {
            //必殺
            case "Hadoken":
                //Debug.Log("波動拳");
                finalMove = new Vector3(0, 0, 0);
                animator.SetInteger("Special", 1);
                break;
            //必殺
            case "Syoryuken":
                //Debug.Log("昇龍拳");
                finalMove = new Vector3(0, 0, 0);
                animator.SetInteger("Special", 2);
                break;
        }
        //アニメ終了でもどる
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && animator.GetInteger("Special") != 0)
        {
            animator.SetInteger("Special", 0);
            state = "Stand";
        }

    }

    /// <summary>
    /// ジャンプ中
    /// </summary>
    void Jumping()
    {

        //ジャンプしているときに地面に触っておらず一定時間経過していたら終了
        bool jumpEnd = gameObject.transform.position.y <= 0 && state == "Jump" && jumpCount > jumpTime;
        if (jumpEnd)
        {
            jumpCount = 0;
            state = "Stand";
            //freeze = true;
            //recoveryState = "JumpEnd";
        }
        //ジャンプしているときに重力をかける
        bool jumping = gameObject.transform.position.y >= 0 && state == "Jump";
        if (jumping) nowGravity -= gravity;

        //ジャンプしたときのアニメ、ジャンプする動作
        if (state == "Jump")
        {
            animator.SetBool("Jump", true);
            ySpeed = 0.15f;

            //ジャンプキック
            if (Input.GetKeyDown(KeyCode.Z) || punchKey && !animator.GetBool("Punch") && !animator.GetBool("Kick"))
            {
                //animator.SetBool("Punch", true);
                animator.SetBool("Punch", true);
                damage = 500;
            }
            //ジャンプキック
            if (Input.GetKeyDown(KeyCode.X) || kickKey && !animator.GetBool("Punch") && !animator.GetBool("Kick"))
            {
                animator.SetBool("Kick", true);
                damage = 500;
            }
        }
        else
        {
            //ジャンプ終わり
            animator.SetBool("Jump", false);
            ySpeed = 0;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, 0);
        }

        finalMove.y = ySpeed + nowGravity;
    }

    /// <summary>
    /// コマンド入力
    /// </summary>
    void InputCommand()
    {
        //入力
        switch (inputDKey)
        {
            case 1:
                history.RemoveAt(0);
                history.Add("1");
                break;
            case 2:
                history.RemoveAt(0);
                history.Add("2");
                break;
            case 3:
                history.RemoveAt(0);
                history.Add("3");
                break;
            case 4:
                history.RemoveAt(0);
                history.Add("4");
                break;
            case 5:
                history.RemoveAt(0);
                history.Add("5");
                break;
            case 6:
                history.RemoveAt(0);
                history.Add("6");
                break;
            case 7:
                history.RemoveAt(0);
                history.Add("7");
                break;
            case 8:
                history.RemoveAt(0);
                history.Add("8");
                break;
            case 9:
                history.RemoveAt(0);
                history.Add("9");
                break;

        }

        if (punchKey)
        {
            history.RemoveAt(0);
            history.Add("P");
        }
        if (kickKey)
        {
            history.RemoveAt(0);
            history.Add("K");
        }

        for (int i = 0; i < commandCount; i++)
        {
            //text.text += history[i];
        }
    }

    /// <summary>
    /// 入力履歴
    /// </summary>
    void InputKeyHistory()
    {
        //入力履歴
        if (history[commandCount - 1] != "5" && history[commandCount - 1] != history[commandCount - 2])
        {
            inputHistory.RemoveAt(0);
            inputHistory.Add(history[commandCount - 1]);
        }
    }

    /// <summary>
    /// は同県コマンド
    /// </summary>
    void HadokenCommand()
    {
        //は同県
        if (state != "Special")
        {
            string[] hadoken = new string[4];
            hadoken[0] = "2";
            hadoken[1] = "3";
            hadoken[2] = "6";
            hadoken[3] = "P";

            int hadokenCount = 0;

            for (int i = 0; i < commandCount; i++)
            {
                if (hadoken[hadokenCount] == history[i])
                {
                    hadokenCount++;
                    if (hadokenCount > 3)
                    {
                        if (state != "Jump")
                        {
                            specialState = "Hadoken";
                            state = "Special";
                            history.Clear();
                            for (int j = 0; j < commandCount; j++)
                            {
                                history.Add("");
                            }
                            
                        }
                        break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 昇竜拳コマンド
    /// </summary>
    void SyoryukenCommand()
    {
        //昇竜拳
        if (state != "Special")
        {
            string[] syoryu = new string[4];
            syoryu[0] = "6";
            syoryu[1] = "2";
            syoryu[2] = "3";
            syoryu[3] = "P";

            int syoryuCount = 0;

            for (int i = 0; i < commandCount; i++)
            {
                if (syoryu[syoryuCount] == history[i])
                {
                    syoryuCount++;
                    if (syoryuCount > 3)
                    {
                        if (state != "Jump")
                        {
                            specialState = "Syoryuken";
                            state = "Special";
                            history.Clear();
                            for (int j = 0; j < commandCount; j++)
                            {
                                history.Add("");
                            }
                            //break;
                        }
                        break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 最終的な移動
    /// </summary>
    void FinallyMove()
    {
        //最終的な移動
        Vector3 finalPos = finalMove + gameObject.transform.position;
        gameObject.transform.position = finalPos;

        if (state != "Jump") gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, 0);

    }
}
