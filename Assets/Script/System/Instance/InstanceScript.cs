using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanceScript : MonoBehaviour {

    struct InstantFighter
    {
        public GameObject fighter;
        public int playerTag;
    }

    [SerializeField]
    private List<GameObject> charcter;

    private InstantFighter[] fight = new InstantFighter[2];
    private string[] names = new string[2]
    {
        "Aoi" ,
        "Aoi" 
    };


    // Use this for initialization
    void Awake ()
    {
        for (int i = 0; i < fight.Length; i++)
        {
            //選択されたキャラクターの名前で検索
            switch (names[i])
            {
                //一致したキャラを登録
                case "Aoi":
                    fight[i].fighter = Instantiate(charcter[0]);
                    fight[i].playerTag = i + 1;
                    break;
                //case "Hikari":
                //    fight[i].fighter = charcter[1];
                //    fight[i].playerTag = i + 1;
                //    break;
                //default:
                //    break;
            }

            fight[i].fighter.tag = "P" + fight[i].playerTag.ToString();
            fight[i].fighter.transform.GetChild(0).tag = "P" + fight[i].playerTag.ToString();
        }
    }
	
    //キャラクターネーム
    public string charName(int ID) { return names[ID]; }
    //キャラクター取得用
    public GameObject Fighter(int ID) { return fight[ID].fighter; }
    //キャラクターID
    public int FighterID(int ID) { return fight[ID].playerTag; }
}
