using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamepadInput;
using System;

public class CharacterSelect : MonoBehaviour {
    [SerializeField]
    public int controller=0;
    //　アイコンが1秒間に何ピクセル移動するか
    [SerializeField]
    private float iconSpeed = Screen.width;
    //　アイコンのサイズ取得で使用
    private RectTransform rect;
    //　アイコンが画面内に収まる為のオフセット値
    private Vector2 offset;
    GamepadState state;
    GamepadState state1;
    GamepadState state2;
    Vector2[] framePos = new Vector2[7]
    {
        new Vector2( -70.0f, 140.0f),
        new Vector2(-140.0f,   0.0f),
        new Vector2( -70.0f,-140.0f),
        new Vector2(  70.0f, 140.0f),
        new Vector2( 140.0f,   0.0f),
        new Vector2(  70.0f,-140.0f),
        new Vector2(   0.0f,   0.0f)
    };
    void Start()
    {
        if(controller==1)
        {
            state = GamePad.GetState(GamePad.Index.One);
        }
        else if(controller==2)
        {
            state = GamePad.GetState(GamePad.Index.Two);
        }
        state1 = GamePad.GetState(GamePad.Index.One);
        state2= GamePad.GetState(GamePad.Index.Two);
        rect = GetComponent<RectTransform>();
        //　オフセット値をアイコンのサイズの半分で設定
        offset = new Vector2(rect.sizeDelta.x / 2f, rect.sizeDelta.y / 2f);
    }

    void Update()
    {

        if (controller == 1)
        {
            //　移動キーを押していなければ何もしない
            if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
            {
                return;
            }
            //　移動先を計算
            var pos = rect.anchoredPosition + new Vector2(Input.GetAxis("Horizontal") * iconSpeed, -Input.GetAxis("Vertical") * iconSpeed) * Time.deltaTime;

            //　アイコンが画面外に出ないようにする
            pos.x = Mathf.Clamp(pos.x, -Screen.width * 0.5f + offset.x, Screen.width * 0.5f - offset.x);
            pos.y = Mathf.Clamp(pos.y, -Screen.height * 0.5f + offset.y, Screen.height * 0.5f - offset.y);
            //　アイコン位置を設定
            rect.anchoredPosition = pos;
        }
        else if (controller == 2)
        {
            //　移動キーを押していなければ何もしない
            if (Input.GetAxis("Horizontal2") == 0f && Input.GetAxis("Vertical2") == 0f)
            {
                return;
            }
            //　移動先を計算
            var pos = rect.anchoredPosition + new Vector2(Input.GetAxis("Horizontal2") * iconSpeed, -Input.GetAxis("Vertical2") * iconSpeed) * Time.deltaTime;

            //　アイコンが画面外に出ないようにする
            pos.x = Mathf.Clamp(pos.x, -Screen.width * 0.5f + offset.x, Screen.width * 0.5f - offset.x);
            pos.y = Mathf.Clamp(pos.y, -Screen.height * 0.5f + offset.y, Screen.height * 0.5f - offset.y);
            //　アイコン位置を設定
            rect.anchoredPosition = pos;
        }
    }
    public Vector2 GetFramePos(string name)
    {
        Vector2 pos = new Vector2(0, 0);
        switch(name)
        {
            case "char1":
                pos = framePos[0];
                break;
            case "char2":
                pos = framePos[1];
                break;
            case "char3":
                pos = framePos[2];
                break;
            case "char4":
                pos = framePos[3];
                break;
            case "char5":
                pos = framePos[4];
                break;
            case "char6":
                pos = framePos[5];
                break;
            case "random":
                pos = framePos[6];
                break;
        }
        return pos;
    }
}
